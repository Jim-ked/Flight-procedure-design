using System;
using System.IO;
using System.Text;
using System.Globalization;
// Concrete outputs for audit; not an original runtime capture or a mathematical oracle.
public static class Round2Artifacts {
    static string N(double n){return n.ToString("R",CultureInfo.InvariantCulture);}
    static string P(RePoint p){return N(p.X)+","+N(p.Y)+","+N(p.Z);}
    public static void Write(OmniDepartureRecovered omni,PointDepartureRecovered point,AltitudeDepartureRecovered alt,DmeArcRecovered dme){
        string dir=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"fixtures");Directory.CreateDirectory(dir);
        var s=new StringBuilder("mode,path,vertex,x,y,z\n");
        var modes=new[]{point.Boundaries,alt.Boundaries,omni.Boundaries};string[] names={"point","altitude","omni"};
        for(int m=0;m<modes.Length;m++)for(int i=0;i<modes[m].Count;i++)for(int j=0;j<modes[m][i].Count;j++)s.AppendLine(names[m]+","+i+","+j+","+P(modes[m][i][j]));
        File.WriteAllText(Path.Combine(dir,"departure-control-points.csv"),s.ToString(),Encoding.UTF8);
        s=new StringBuilder("x,y,z,area,dr,do,moc,oca,pda,required\n");
        foreach(var p in new[]{new RePoint(-1500,200,50),new RePoint(-700,200,50),new RePoint(1500,1000,50),new RePoint(6500,4000,50),new RePoint(omni.F.X+100,omni.F.Y+100,50)}){
            var r=omni.Evaluate(p);s.AppendLine(P(p)+","+r.Area+","+N(r.Dr)+","+N(r.D0)+","+N(r.MOC)+","+N(r.OCA)+","+N(r.AllowableAltitude)+","+N(r.RequiredGradient));
        }
        File.WriteAllText(Path.Combine(dir,"omni-C1-C5.csv"),s.ToString(),Encoding.UTF8);
        s=new StringBuilder("index,cx,cy,cz,radius,start,end\n");int n=0;foreach(var a in dme.Drawing.Arcs)s.AppendLine(n+++","+P(a.Center)+","+N(a.Radius)+","+N(a.StartAngle)+","+N(a.EndAngle));
        File.WriteAllText(Path.Combine(dir,"dme-construction-arcs.csv"),s.ToString(),Encoding.UTF8);
        s=new StringBuilder("entity,vertex,x,y,z,bulge,startWidth,endWidth,closed\n");n=0;foreach(var e in dme.Drawing.Entities){var poly=e as RePolyline;if(poly!=null)for(int i=0;i<poly.Vertices.Count;i++){var v=poly.Vertices[i];s.AppendLine(n+","+i+","+P(v.Point)+","+N(v.Bulge)+","+N(v.StartWidth)+","+N(v.EndWidth)+","+poly.Closed);}n++;}
        File.WriteAllText(Path.Combine(dir,"dme-polyline-vertices.csv"),s.ToString(),Encoding.UTF8);
    }
}
