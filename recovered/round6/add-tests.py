from pathlib import Path
p=Path('recovered/round6/Round6.Tests.cs');s=p.read_text(encoding='utf-8')
mark='  foreach(var kv in counts)Console.WriteLine'
extra='''  // Record adapters test recovered text grammar and XY writer inputs, not AutoCAD transactions.
  var state=new[]{new KeyValuePair<string,string>("tabControl1.groupBox1.textBoxZ1","50"),new KeyValuePair<string,string>("tabControl1.groupBox2.comboBoxCat","3")};
  string saved=RnpApchStateText.Save(state);Check("serialization","header and traversal order",saved=="FormApvEvl\\ntabControl1.groupBox1.textBoxZ1:50\\ntabControl1.groupBox2.comboBoxCat:3\\n");
  var loaded=new Dictionary<string,string>{{state[0].Key,"0"},{state[1].Key,"0"}};RnpApchStateText.Load(saved,loaded);
  Check("serialization","roundtrip supported flat controls",loaded[state[0].Key]=="50"&&loaded[state[1].Key]=="3");
  RnpApchStateText.Load("FormApvEvl\\nmissing:100\\n "+state[0].Key+" : 60:discarded\\n",loaded);
  Check("serialization","unknown skipped and colon truncation",loaded[state[0].Key]=="60"&&loaded.Count==2);
  RnpApchStateText.Load("WrongForm\\n"+state[0].Key+":99",loaded);Check("serialization","wrong header leaves state",loaded[state[0].Key]=="60");
  bool malformed=false;try{RnpApchStateText.Load("FormApvEvl\\nmalformed",loaded);}catch(IndexOutOfRangeException){malformed=true;}Check("serialization","missing colon throws",malformed);
  bool empty=false;try{RnpApchStateText.Load("",loaded);}catch(IndexOutOfRangeException){empty=true;}Check("serialization","empty text throws",empty);
  Save("state_text","serialization",new{saved},new{loaded,malformed,empty,limitation="Flat supported-control adapter, not WinForms typed setter execution"});
  var cad=RnpApchCad.Record(ln,frame,saved);Check("geometry","four polyline writer inputs",cad.Count==4);
  for(int i=0;i<4;i++){Check("geometry","six vertices open zero bulge",cad[i].XY.Count==6&&!cad[i].Closed&&cad[i].Bulge==0);Check("serialization","full control state XData",cad[i].XDataApplication=="WsObject"&&cad[i].XDataText==saved);Check("geometry","writer loses Z",cad[i].XY.All(p=>p.Z==0));}
  Near("geometry","reverse-bearing rotation X",cad[0].XY[0].X,100-ln._0089_009C_0096[0][0].X);Near("geometry","reverse-bearing rotation Y",cad[0].XY[0].Y,200-ln._0089_009C_0096[0][0].Y);
  Save("cad_record","geometry+serialization",new{thr=Pt(frame),state=saved},cad.Select(l=>new{l.Closed,l.Bulge,l.XDataApplication,l.XDataText,vertices=l.XY.Select(Pt).ToArray()}).ToArray());
  var eq=typeof(RnpApchApv).GetMethod("_008A_008B_009C",BindingFlags.Instance|BindingFlags.NonPublic);
  foreach(double fraction in new[]{1.0,.5}){var ob=new RnpApchApvObstacle(new TemplatePoint(-2000,0,200));ob._0088_0090_008D=fraction;object[] arr={ob};eq.Invoke(ap,arr);ob=(RnpApchApvObstacle)arr[0];double offset=30*(1-fraction);double wantHa=Math.Ceiling(((200-offset)/.025-2000+1400)/(1/Math.Tan(Math.PI/60)+1/.025));Near("formula","APV penetrating equivalent Ha",ob._0088_0090_008E,wantHa);Near("formula","penetrating full HL even secondary",ob._0088_0090_008D,49);Near("formula","equivalent OCH",ob._0088_0090_0090,wantHa+49);Save("apv_equivalent_"+fraction,"formula",new{x=-2000,z=200,fraction},Result(ob));}
  var zg=new RnpApchApv(10000,900,0,3,15,75,0,10000,0,-20,"D");var zo=new RnpApchApvObstacle(new TemplatePoint(-2000,0,200));zo._0088_0090_008D=1;object[] zargs={zo};eq.Invoke(zg,zargs);zo=(RnpApchApvObstacle)zargs[0];Check("degenerate","zero MCG equivalent Ha NaN",double.IsNaN(zo._0088_0090_008E));Save("apv_zero_mcg","degenerate",new{g=0},Result(zo));
  Near("degenerate","zero HL display retained",RnpApchMissed.HlDisplay(0,0,1800),0);Near("degenerate","negative HL display retained",RnpApchMissed.HlDisplay(-10,0,0),-10);Check("degenerate","NaN elevation HL retained",double.IsNaN(RnpApchApv._008A_008B_009A("D",double.NaN,3)));
  var stale=new RnpApchApvObstacle(new TemplatePoint(1,0,100));stale._0088_0090_008A="previous";stale._0088_0090_008B=321;object[] st={stale,new TemplatePoint(0,200,10),75.0,new TemplatePoint(-1000,400,30),100.0};ac.Invoke(ap,st);stale=(RnpApchApvObstacle)st[0];Check("degenerate","invalid classifier retains old values",stale._0088_0090_008A=="previous"&&stale._0088_0090_008B==321);Save("apv_invalid_domain_stale","degenerate",new{x=1},Result(stale));
  var same1=new RnpApchObstacle(new TemplatePoint(1000,0,100));var same2=new RnpApchApvObstacle(new TemplatePoint(1000,0,100));ln._0089_009C_0086(ref same1);ap._008A_008B_0096(ref same2);Check("invariant","same obstacle independent area records",same1._0088_0090_0086==175&&same2._0088_0090_0090==149);Save("same_obstacle_two_classes","invariant",new{x=1000,y=0,z=100},new{lnav=Result(same1),apv=Result(same2),merged=false});
'''
assert mark in s;s=s.replace(mark,extra+mark);p.write_text(s,encoding='utf-8')
p=Path('recovered/round6/build.py');s=p.read_text(encoding='utf-8');s=s.replace('print(log);raise SystemExit(p.returncode)','print("\\n".join(x for x in log.splitlines() if x.startswith("PASS ") or "Exception" in x));raise SystemExit(p.returncode)');p.write_text(s,encoding='utf-8')
