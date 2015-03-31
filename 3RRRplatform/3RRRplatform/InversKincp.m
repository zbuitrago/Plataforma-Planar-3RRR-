function InversKin(y)

global CoordenadaXCentro  CoordenadaYCentro 

if y==1
cp=ginput(1)

CoordenadaXCentro  = cp(1,1);
CoordenadaYCentro  = cp(1,2);

RRRdrawing(S1,S2,S3)
end