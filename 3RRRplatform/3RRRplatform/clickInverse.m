% This is a subfunction of rrrproject3.m
% Created by Gan Tao   taogan@eng.buffalo.edu
% Date: Jan.2004

function clickInverse(obj,eventdata)
global CoordenadaXCentro  CoordenadaYCentro 
global S1 S2 S3
global CInverCK
% t=1:0.01:10;
% y = sin(t);
% plot(t,y,'b--')
% axis([-1 15 -2 2])

cp=get(gca,'CurrentPoint');

Xcp = cp(1,1);
Ycp = cp(1,2);
step = 20;
Xcpinter = (Xcp-CoordenadaXCentro )/step;
Ycpinter = (Ycp-CoordenadaYCentro )/step;
Xg_last = CoordenadaXCentro ;
Yg_last = CoordenadaYCentro ;

if (-15 < Xcp)&&(Xcp < 15)&&(-15 < Ycp)&&(Ycp < 15)
if CInverCK
for k=1:step
    
    CoordenadaXCentro  = Xg_last+k*Xcpinter;
    CoordenadaYCentro  = Yg_last+k*Ycpinter;
    RRRdrawing(S1,S2,S3)
    pause(0.000001)
end

else
    text(-10,10,'Please click the Click to Inverse','FontSize',15,'color','r');
end
end