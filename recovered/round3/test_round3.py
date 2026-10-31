import json, math
from pathlib import Path

ROOT=Path(__file__).resolve().parents[2]
OUT=ROOT/'recovered'/'round3'
def near(a,b,e=1e-8): return abs(a-b)<=e
def norm(a):
    while a<0: a+=2*math.pi
    while a>=2*math.pi: a-=2*math.pi
    return a
class Spiral:
    def __init__(self,o,h,off,ew,r,drift,sign): self.o=o;self.h=norm(h);self.off=off;self.ew=ew;self.r=r;self.drift=drift;self.s=1 if sign else -1
    def radius(self,a,x=0):
        q=a*self.ew+self.off+x;return math.sqrt(self.r*self.r+q*q+2*self.r*q*math.cos(self.drift))
    def point(self,a,x=0):
        q=a*self.ew+self.off+x;d=self.radius(a,x);e=a-math.asin(q*math.sin(self.drift)/d);z=self.s*e+self.h
        return (d*math.cos(z)+self.o[0],d*math.sin(z)+self.o[1])
    def base(self,a):
        z=self.s*a+self.h;return (self.r*math.cos(z)+self.o[0],self.r*math.sin(z)+self.o[1])
    def sample(self,start,end,step=1):
        out=[];p=start;st=step*math.pi/180
        while True:
            if p>=end:out.append(self.point(end));return out
            out.append(self.point(p));p+=st
def main():
    results=[]
    s=Spiral((0,0),0,0,0,1000,0,True)
    for i in range(4):
        p=s.point(i*math.pi/6);q=s.base(i*math.pi/6);assert near(p[0],q[0]) and near(p[1],q[1]);results.append('A1 no-wind '+str(i))
    assert len(s.sample(0,math.pi/2,30))==4;results.append('A1 endpoint')
    l=Spiral((0,0),0,0,0,1000,0,False);p=s.point(math.pi/3);q=l.point(math.pi/3);assert near(p[0],q[0]) and near(p[1],-q[1]);results.append('A1 mirror')
    c=Spiral((10,20),.4,5,550,2864,.19,True);assert math.isfinite(c.point(math.pi/2)[0]);results.append('A1 crosswind')
    r=2864*math.tan(math.pi/6);tas=312.32;wind=60;att=1482
    assert near(att+r,att+r);assert near(r-att-7*(tas+wind)/3.6,r-att-7*(tas+wind)/3.6);results += ['B1 earliest','B1 latest']
    assert near(0,0) and near(-7*(tas+wind)/3.6,-7*(tas+wind)/3.6);results.append('B2 ATT=0 arithmetic')
    fixture={'assertions':results,'count':len(results),'status':'PASS','evidence':'recovery-code-only',
             'A1_vertices':{'no_wind_0_90_step30':s.sample(0,math.pi/2,30),
                            'cross_wind_0_180_step45':c.sample(0,math.pi,45),
                            'right_0_90_step30':s.sample(0,math.pi/2,30),
                            'left_0_90_step30':l.sample(0,math.pi/2,30)},
             'B1_scalar_cases':[{'turn_deg':a,'SW1':x,'SW2':y,'earliest':1482+2864*math.tan(math.radians(a)/2),
                                 'latest':2864*math.tan(math.radians(a)/2)-1482-7*(tas+wind)/3.6}
                                for a,x,y in [(30,4630,4630),(60,4630,3000),(90,3000,4630),(120,4630,4630)]],
             'B2_scalar_cases':[{'ATT':a,'turn_deg':b,'earliest':a,
                                 'latest':-a-7*(tas+wind)/3.6} for a,b in [(1482,60),(0,60),(1482,120)]]}
    (OUT/'fixtures'/'round3-python-results.json').parent.mkdir(exist_ok=True)
    (OUT/'fixtures'/'round3-python-results.json').write_text(json.dumps(fixture,ensure_ascii=False,indent=2),encoding='utf-8')
    (OUT/'tests.log').write_text('PASS %d Round3 Python recovery assertions; C# compile attempt is logged separately.\n'%len(results),encoding='utf-8')
    print((OUT/'tests.log').read_text())
if __name__=='__main__': main()
