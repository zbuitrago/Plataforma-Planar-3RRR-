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

PosicionMouse=get(gca,'CurrentPoint');

PosicionMouseX = PosicionMouse(1,1);
PosicionMouseY = PosicionMouse(1,2);
NumeroDePasos = 20;
DistanciaPosicionMouseXAlCentro = (PosicionMouseX-CoordenadaXCentro )/NumeroDePasos;
DistanciaPosicionMouseYAlCentro = (PosicionMouseY-CoordenadaYCentro )/NumeroDePasos;
CoordenadaXCentroActual = CoordenadaXCentro ;
CoordenadaYCentroActual = CoordenadaYCentro ;

if (-15 < PosicionMouseX)&&(PosicionMouseX < 15)&&(-15 < PosicionMouseY)&&(PosicionMouseY < 15)
if CInverCK
for k=1:NumeroDePasos
    
    CoordenadaXCentro  = CoordenadaXCentroActual+k*DistanciaPosicionMouseXAlCentro;
    CoordenadaYCentro  = CoordenadaYCentroActual+k*DistanciaPosicionMouseYAlCentro;
    RRRdrawing(S1,S2,S3)
    pause(0.000001)
end

else
    text(-10,10,'Please click the Click to Inverse','FontSize',15,'color','r');
end
end