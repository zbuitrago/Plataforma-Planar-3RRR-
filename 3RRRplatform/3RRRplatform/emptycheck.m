% This is a subfunction of rrrproject3.m
% Created by Gan Tao        taogan@eng.buffalo.edu
% Graduate Student of SUNY Buffalo
% Date: Jan.2004
% emptycheck.m is for checking wether the variables for inverse kinematic
% are full. If there are enough for the inverse it sends 0 otherwise send
% 1.


function emck=emptycheck()

global LongitudLadoTriangulo LongitudEslabon1 LongitudEslabon2 
global CoordenadaYMotor1 CoordenadaXMotor1 CoordenadaYMotor2 CoordenadaXMotor2 CoordenadaYMotor3 CoordenadaXMotor3
global CoordenadaXCentro  CoordenadaYCentro  Phi
global S1 S2 S3 MostrarAngulo


if isempty(CoordenadaXCentro ) | isempty(CoordenadaYCentro ) | isempty(Phi) | isempty(LongitudLadoTriangulo) | isempty(LongitudEslabon1) | isempty(LongitudEslabon2) | isempty(CoordenadaYMotor1) | isempty(CoordenadaXMotor1) | isempty(CoordenadaXMotor2) | isempty(CoordenadaYMotor2) | isempty(CoordenadaYMotor3) | isempty(CoordenadaXMotor3)...
        isempty(S1)|isempty(S2)|isempty(S3)|isempty(MostrarAngulo)
    

    emck = 1;
    
else 
    emck = 0;
    
end