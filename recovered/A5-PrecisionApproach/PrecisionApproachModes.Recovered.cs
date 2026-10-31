using System;
using System.Collections.Generic;
using Recovered.A6;
using Recovered.B5;
using Recovered.B4;
namespace Recovered.A5 {
// E2 P306 computational dispatch extracted from host-specific event method.
// Full original/processed method and CAD transaction retained in evidence.
public static class PrecisionApproachModes {
 public static List<List<TemplatePoint>> Draw(PrecisionApproachForm f){
  f._0087_0091_008F(); // P307 always prepares all common inputs, including IF/fix/PAOAS
  if(f._0087_0092_0097.Checked)return new PaFapGeometry(f._0087_0092_008E,f._0087_0092_0091,f._0087_0092_0090)._0088_0096_008B;
  if(f._0087_0092_0096.Checked)return new PaFafGeometry(f._0087_0092_008E,f._0087_0092_0091,f._0087_0092_0090,RecoveryParse.Cell(f._0087_0095_009D,"FAF定位容差输入有误"))._0088_0095_0090;
  if(f._0087_0092_009A.Checked)return new GpInopGeometry(f._0087_0092_008E,f._0087_0092_0091,f._0087_0092_0090)._0088_0087_0099;
  if(f._0087_0092_0095.Checked)return f._0087_0092_008E._0088_0091_009D;
  if(f._0087_0092_0094.Checked)return f._0087_0092_008F._0088_0094_0093;
  if(f._0087_0092_009B.Checked)return f._0087_0092_008F._0088_0094_0092;
  return new List<List<TemplatePoint>>();
 }
 // P306 transform order: rotate -> translate -> clear Z. No CAD runtime adapter.
 public static List<List<TemplatePoint>> Transform(List<List<TemplatePoint>> p,TemplatePoint thr,TemplatePoint end){
  RunwayFrame f=FrameHelpers._0089_008F(thr,end);
  p=PointLists._008B_008A_0094(p,new TemplatePoint(0,0),f._008A_009D_008A);
  p=PointLists._008B_008A_0096(p,new TemplatePoint(f.X,f.Y));
  return PointLists._008B_008A_009A(p);
 }
}
}
