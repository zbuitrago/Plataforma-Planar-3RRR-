% This is a subfunction of rrrproject3.m
% Created by Gan Tao   taogan@eng.buffalo.edu
% Graduate Student of SUNY Buffalo
% Date: Jan.2004
% varmakeup.m is for give the robot a fault data. if there is a data in one
% variable then it won't give fault data.

function k=varmakeup()

global LongitudLadoTriangulo LongitudEslabon1 LongitudEslabon2 
global CoordenadaYMotor1 CoordenadaXMotor1 CoordenadaYMotor2 CoordenadaXMotor2 CoordenadaYMotor3 CoordenadaXMotor3
global CoordenadaXCentro  CoordenadaYCentro  Phi
global S1 S2 S3 
global MostrarAngulo
global CInverCK
global Rec_Movie
if isempty(CoordenadaXCentro )
    CoordenadaXCentro  = 0;
    k = 1;
end

    if isempty(CoordenadaYCentro )
        CoordenadaYCentro  = 0;
        k = k+1;
    end
        if isempty(Phi)
            Phi = pi/4;
            k = k+1;
        end
            if isempty(CoordenadaYMotor1)
                CoordenadaYMotor1 = -8.4;
                k = k+1;
            end
                if isempty(CoordenadaXMotor1)
                    CoordenadaXMotor1 = -1.5;
                    k = k+1;
                end
                    if isempty(CoordenadaYMotor2)
                        CoordenadaYMotor2 = -1.2;
                        k = k+1;
                    end
                        if isempty(CoordenadaXMotor2)
                            CoordenadaXMotor2 = 6.9;
                            k = k+1;
                        end
                            if isempty(CoordenadaXMotor3)
                                CoordenadaXMotor3 = -6.6;
                                k = k+1;
                            end
                                if isempty(CoordenadaYMotor3)
                                    CoordenadaYMotor3 = 2.1;
                                    k = k+1;
                                end
                                    if isempty(LongitudLadoTriangulo)
                                        LongitudLadoTriangulo = 3;
                                        k = k+1;
                                    end
                                        if isempty(LongitudEslabon1)
                                            LongitudEslabon1 = 5;
                                            k = k+1;
                                        end
                                            if isempty(LongitudEslabon2)
                                                LongitudEslabon2 = 4;
                                                k = k+1;
                                            end
                                               if isempty(S1)
                                                   S1= 1;
                                                   k = k+1;
                                               end
                                                  if isempty(S2)
                                                      S2=1;
                                                      k=k+1;
                                                  end
                                                     if isempty(S3)
                                                         S3=1;
                                                         k=k+1;
                                                     end
                                                       if isempty(MostrarAngulo)
                                                           MostrarAngulo = 1;
                                                           k=k+1;
                                                       end
                                                     
                                                           if 1
                                                           CInverCK=0;   
                                                       end 
                                                             if isempty(Rec_Movie)
                                                                 Rec_Movie = 0;
                                                             end
