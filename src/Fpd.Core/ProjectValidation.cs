namespace Fpd.Core;

public static class ProjectValidation
{
    public static void Coordinates(double latitude, double longitude, double? elevation)
    {
        if (!double.IsFinite(latitude) || latitude <= -90 || latitude >= 90 ||
            !double.IsFinite(longitude) || longitude < -180 || longitude > 180 ||
            (elevation.HasValue && !double.IsFinite(elevation.Value)))
            throw new ArgumentException("经纬度须为有限十进制度（纬度 -90° 至 90°之间、经度 ±180°）；高程须为有限米值。");
    }

    public static void Fix(FixData fix)
    {
        if (fix is null || string.IsNullOrWhiteSpace(fix.Ident)) throw new InvalidDataException("定位点标识不能为空。");
        Coordinates(fix.Latitude, fix.Longitude, fix.Elevation);
    }

    public static void Project(ProjectData project)
    {
        if (project is null || string.IsNullOrWhiteSpace(project.ProjectId) || string.IsNullOrWhiteSpace(project.Name) ||
            project.Airport is null || project.Fixes is null || project.Procedures is null || project.Obstacles is null || project.Runways is null || project.Navaids is null)
            throw new InvalidDataException("项目标识、名称、机场或数据列表无效。");
        var airport = project.Airport;
        if (airport.ArpLatitude.HasValue != airport.ArpLongitude.HasValue)
            throw new InvalidDataException("ARP 经纬度须同时填写或同时留空。");
        if (airport.ArpLatitude.HasValue)
        {
            Coordinates(airport.ArpLatitude.Value, airport.ArpLongitude!.Value, airport.ArpElevation);
            Cgcs2000Projection.ZoneForLongitude(airport.ArpLongitude.Value);
        }
        if (airport.ArpElevation.HasValue && !double.IsFinite(airport.ArpElevation.Value))
            throw new InvalidDataException("ARP 高程无效。");
        var identifiers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var fix in project.Fixes)
        {
            Fix(fix);
            if (!identifiers.Add(fix.Ident)) throw new InvalidDataException($"定位点标识重复：{fix.Ident}");
        }
        foreach (var procedure in project.Procedures)
        {
            if (procedure is null || string.IsNullOrWhiteSpace(procedure.Name) || !Enum.IsDefined(procedure.Kind) || procedure.FixIdents is null || procedure.Sections is null)
                throw new InvalidDataException("程序名称、类型或定位点顺序无效。");
            foreach (var ident in procedure.FixIdents)
                if (ident is null || !identifiers.Contains(ident)) throw new InvalidDataException($"程序引用未知定位点：{ident}");
            var names=new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach(var section in procedure.Sections)
            {
                if(section is null || string.IsNullOrWhiteSpace(section.Name) || !names.Add(section.Name) || !Enum.IsDefined(section.Stage) || !Enum.IsDefined(section.Branch) || section.FixIdents is null)
                    throw new InvalidDataException("程序段名称、阶段或分支无效/重复。");
                if(section.Stage==ProcedureStage.Missed && procedure.Kind!=ProcedureKind.Approach) throw new InvalidDataException("Missed仅属于Approach程序。");
                foreach(var ident in section.FixIdents) if(ident is null || !identifiers.Contains(ident)) throw new InvalidDataException($"程序段引用未知Fix：{ident}");
            }
        }
        identifiers.Clear();
        foreach (var obstacle in project.Obstacles)
        {
            Obstacle(obstacle);
            if (!identifiers.Add(obstacle.Ident)) throw new InvalidDataException($"障碍物标识重复：{obstacle.Ident}");
        }
        identifiers.Clear(); var ends=new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach(var runway in project.Runways)
        {
            Runway(runway);
            if(!identifiers.Add(runway.Ident) || !ends.Add(runway.EndA.Designator) || !ends.Add(runway.EndB.Designator)) throw new InvalidDataException("跑道或端标识重复。");
        }
        identifiers.Clear();
        foreach(var navaid in project.Navaids) { Navaid(navaid); if(!identifiers.Add(navaid.Ident)) throw new InvalidDataException("设施标识重复："+navaid.Ident); }
    }

    public static void Position(GeoPosition position)
    {
        if(position is null) throw new InvalidDataException("位置缺失。");
        Coordinates(position.Latitude,position.Longitude,position.Elevation);
    }
    public static void Runway(RunwayData runway)
    {
        if(runway is null || string.IsNullOrWhiteSpace(runway.Ident) || !double.IsFinite(runway.Width) || runway.Width<=0 || runway.EndA is null || runway.EndB is null)
            throw new InvalidDataException("跑道标识、宽度或端资料无效。");
        foreach(var end in new[] { runway.EndA,runway.EndB })
        {
            if(string.IsNullOrWhiteSpace(end.Designator)) throw new InvalidDataException("跑道端标识不能为空。");
            Position(end.PhysicalEnd); Position(end.Threshold); Position(end.DepartureEnd);
        }
        if(runway.EndA.Designator.Equals(runway.EndB.Designator,StringComparison.OrdinalIgnoreCase)) throw new InvalidDataException("两端标识不能相同。");
        var cm=Cgcs2000Projection.ZoneForLongitude(runway.EndA.PhysicalEnd.Longitude).CentralMeridian;
        var a=AirportGeometry.Project(runway.EndA.PhysicalEnd,cm); var b=AirportGeometry.Project(runway.EndB.PhysicalEnd,cm);
        var dx=b.Easting-a.Easting; var dy=b.Northing-a.Northing; var length=Math.Sqrt(dx*dx+dy*dy);
        if(length<1) throw new InvalidDataException("实际跑道两端不能重合。");
        foreach(var end in new[] { runway.EndA,runway.EndB }) foreach(var position in new[] { end.Threshold,end.DepartureEnd })
        {
            var p=AirportGeometry.Project(position,cm);
            var across=Math.Abs((p.Easting-a.Easting)*dy-(p.Northing-a.Northing)*dx)/length;
            if(across>runway.Width/2) throw new InvalidDataException("THR/DER横向位置超出跑道宽度，请核对资料。");
        }
    }
    public static void Navaid(NavaidData navaid)
    {
        if(navaid is null || string.IsNullOrWhiteSpace(navaid.Ident) || !Enum.IsDefined(navaid.Kind)) throw new InvalidDataException("设施标识或类型无效。");
        Position(navaid.Position);
        foreach(var number in new[] { navaid.FrequencyMHz,navaid.FrequencyKHz,navaid.MagneticVariation,navaid.GlidePathAngle })
            if(number.HasValue && !double.IsFinite(number.Value)) throw new InvalidDataException("设施参数须为有限数值。");
        if(navaid.FrequencyMHz<=0 || navaid.FrequencyKHz<=0 || navaid.GlidePathAngle<=0 || navaid.GlidePathAngle>=90 || Math.Abs(navaid.MagneticVariation??0)>180) throw new InvalidDataException("频率、GP角度或磁差范围无效。");
        if(navaid.Kind==NavaidKind.NDB && navaid.FrequencyMHz.HasValue || navaid.Kind!=NavaidKind.NDB && navaid.FrequencyKHz.HasValue) throw new InvalidDataException("NDB使用kHz，VOR/DME/ILS使用MHz，不能混用。");
        if(navaid.Kind!=NavaidKind.DME && !string.IsNullOrWhiteSpace(navaid.Channel) || navaid.Kind!=NavaidKind.VOR && navaid.MagneticVariation.HasValue || navaid.Kind!=NavaidKind.ILS && (navaid.GlidePathPosition is not null || navaid.GlidePathAngle.HasValue)) throw new InvalidDataException("存在与设施类型不符的参数。");
        if(navaid.GlidePathPosition is not null) Position(navaid.GlidePathPosition);
    }

    public static void Obstacle(ObstacleData obstacle)
    {
        if (obstacle is null || string.IsNullOrWhiteSpace(obstacle.Ident)) throw new InvalidDataException("障碍物标识不能为空。");
        Coordinates(obstacle.Latitude, obstacle.Longitude, obstacle.TopElevation);
        if (obstacle.Height.HasValue && (!double.IsFinite(obstacle.Height.Value) || obstacle.Height < 0) ||
            obstacle.GroundElevation.HasValue && !double.IsFinite(obstacle.GroundElevation.Value))
            throw new InvalidDataException("障碍物自身高度须为非负有限米值，地面高程须为有限米值。");
    }
}
