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
                                                                
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
stoppathtrack
+++++++++++++++++++++++++++++++++++

% This is a subfunction of rrrproject3.m
% Created by Gan Tao   taogan@eng.buffalo.edu
% Graduate Student of SUNY Buffalo
% Date: Jan.2004
% stoppathtrack.m is the stop the path drawing and then ask the robot to
% trace the path.

function stoppathtrack(obj,eventdata)

global CC k
global X Y
global fig
global CoordenadaXCentro  CoordenadaYCentro 
global S1 S2 S3
global InVS
global Rec_Movie
global CInverCK

     cp=get(gca,'CurrentPoint');
     x=cp(1,1);
     y=cp(1,2);
if (x > -15) &  (x < 15) & (y > -15) & (y < 15)
    
    if InVS ==1 & CInverCK == 0
       CC = 0;
       set(fig,'WindowButtonMotionFcn',@nothingfcn);
       size(X);
       size(Y);
              if Rec_Movie == 1
              set(fig,'DoubleBuffer','on');
              set(gca,'xlim',[-15 15],'ylim',[-15 15],...
                      'NextPlot','replace','Visible','off')
              mov = avifile('3RRRrobot_track_path.avi')
       end
          for i=1:1:(k-1)
              CoordenadaXCentro  = X(i);
              CoordenadaYCentro  = Y(i);
              RRRdrawing(S1,S2,S3)
              pause(0.0000000001)
              if Rec_Movie == 1
                 F = getframe(gca);
                 mov = addframe(mov,F);
                 end
        end
              if Rec_Movie == 1
                 mov = close(mov);
              end

       k = 1;
    elseif InVS == 1 & CInverCK == 1
    CC = 0;


    set(fig,'WindowButtonMotionFcn',@nothingfcn);
    end

end
+++++++++++++++++++++++++++++++
startpathtrack
+++++++++++++++++++++++++++++++++++++++++++++++++
% This is a subfunction of rrrproject3.m
% Created by Gan Tao   taogan@eng.buffalo.edu
% Graduate Student of SUNY Buffalo
% Date: Jan.2004
% startpathtrack.m is start paht/point tracking.

function startpathtrack(obj,eventdata)

global CC
global k
global fig
global X Y
global CInverCK
global InVS
global S1 S2 S3


cp=get(gca,'CurrentPoint');
     x=cp(1,1);
     y=cp(1,2);
if (x > -15) &  (x < 15) & (y > -15) & (y < 15)
     if CInverCK == 0 & InVS == 1
    
     CC = 1;
     k = 1;
     RRRdrawing(S1,S2,S3)
     hold on
     set(fig,'WindowButtonMotionFcn',@pathtrack);
     X = [];
     Y = [];
     elseif InVS == 1 & CInverCK == 1

     clickInverse;
     end

end

+++++++++++++++++++++++++++++++
RRRdrawing
+++++++++++++++++++++++++++++
% This is a subfunction of rrrproject3.m
% Created by Gan Tao   taogan@eng.buffalo.edu
% Graduate Student of SUNY Buffalo
% Date: Jan.2004
% RRRdrawing.m is the inverse kinematic and drawing angles computing
% function. One of the thing i want to mention here here is the elbowdown
% and elboup. I set some if command to settle it.

function RRRdrawing(S1,S2,S3)

global LongitudLadoTriangulo LongitudEslabon1 LongitudEslabon2 
global CoordenadaYMotor1 CoordenadaXMotor1 CoordenadaYMotor2 CoordenadaXMotor2 CoordenadaYMotor3 CoordenadaXMotor3
global CoordenadaXCentro  CoordenadaYCentro  Phi
global theta11 theta12 theta21 theta22 theta31 theta32
global diaota1 diaota2 diaota3
global MostrarAngulo 
global k X Y


e  = ((3^0.5)/3)*LongitudLadoTriangulo;
Xa = CoordenadaXCentro -e*cos(Phi+pi/6);
Ya = CoordenadaYCentro -e*sin(Phi+pi/6);

Xd =[ 1/2*(1/(-8*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1+4*Ya^2+4*CoordenadaYMotor1^2+4*Xa^2+4*CoordenadaXMotor1^2)*(-4*CoordenadaYMotor1*LongitudEslabon1^2-4*Ya^2*CoordenadaYMotor1+4*Ya^3+4*CoordenadaXMotor1^2*CoordenadaYMotor1-4*Ya*LongitudEslabon2^2+4*Ya*LongitudEslabon1^2+4*Ya*CoordenadaXMotor1^2+4*LongitudEslabon2^2*CoordenadaYMotor1-4*Ya*CoordenadaYMotor1^2+4*Xa^2*Ya-8*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4*Xa^2*CoordenadaYMotor1-8*CoordenadaXMotor1*Xa*Ya+4*CoordenadaYMotor1^3+4*(-2*Xa^4*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*LongitudEslabon2^4+2*Xa^4*LongitudEslabon2^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon1^2+2*Xa^4*LongitudEslabon1^2-15*Xa^4*CoordenadaXMotor1^2-2*Xa^4*Ya^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon2^2-8*CoordenadaXMotor1*Xa^3*LongitudEslabon2^2+2*CoordenadaXMotor1*Xa*LongitudEslabon1^4+2*Xa^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor1^2*LongitudEslabon2^2*LongitudEslabon1^2-16*Xa^3*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4*CoordenadaXMotor1*Xa*LongitudEslabon2^2*LongitudEslabon1^2+8*CoordenadaYMotor1*LongitudEslabon1^2*CoordenadaXMotor1*Xa*Ya-4*Ya*LongitudEslabon2^2*Xa^2*CoordenadaYMotor1+8*Ya*LongitudEslabon2^2*CoordenadaXMotor1*Xa*CoordenadaYMotor1-4*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1*Xa-4*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa-4*LongitudEslabon2^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1^3*CoordenadaXMotor1*Xa+8*Ya^2*CoordenadaXMotor1^3*Xa-Xa^6-CoordenadaXMotor1^6-4*CoordenadaYMotor1*LongitudEslabon1^2*Ya*CoordenadaXMotor1^2-4*CoordenadaYMotor1*LongitudEslabon1^2*Xa^2*Ya-4*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa+12*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1*Xa-4*CoordenadaXMotor1^2*CoordenadaYMotor1*Ya*LongitudEslabon2^2+24*CoordenadaXMotor1^2*CoordenadaYMotor1*Xa^2*Ya-16*CoordenadaXMotor1^3*CoordenadaYMotor1*Xa*Ya-Ya^4*CoordenadaXMotor1^2-Ya^4*Xa^2-2*CoordenadaXMotor1^4*CoordenadaYMotor1^2-CoordenadaXMotor1^2*CoordenadaYMotor1^4-2*Ya^2*CoordenadaXMotor1^4-Xa^2*CoordenadaYMotor1^4+6*CoordenadaXMotor1*Xa^5+6*CoordenadaXMotor1^5*Xa+20*CoordenadaXMotor1^3*Xa^3-15*CoordenadaXMotor1^4*Xa^2-Xa^2*LongitudEslabon2^4-Xa^2*LongitudEslabon1^4-CoordenadaXMotor1^2*LongitudEslabon2^4-CoordenadaXMotor1^2*LongitudEslabon1^4+2*CoordenadaXMotor1^4*LongitudEslabon2^2+2*CoordenadaXMotor1^4*LongitudEslabon1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*Xa^2-6*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*Xa^2-6*Ya^2*CoordenadaYMotor1^2*Xa^2+2*Ya^4*CoordenadaXMotor1*Xa+4*CoordenadaXMotor1^4*CoordenadaYMotor1*Ya+2*CoordenadaXMotor1^2*CoordenadaYMotor1^2*LongitudEslabon2^2+4*CoordenadaXMotor1^2*CoordenadaYMotor1^3*Ya+8*CoordenadaXMotor1^3*CoordenadaYMotor1^2*Xa-12*CoordenadaXMotor1^2*CoordenadaYMotor1^2*Xa^2+2*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon2^2*Xa^2+2*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon1^2*Xa^2-12*Ya^2*CoordenadaXMotor1^2*Xa^2+2*LongitudEslabon2^2*CoordenadaYMotor1^2*Xa^2+4*Ya*CoordenadaYMotor1^3*Xa^2+4*Xa^4*Ya*CoordenadaYMotor1+8*Xa^3*Ya^2*CoordenadaXMotor1+8*CoordenadaXMotor1*Xa^3*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*CoordenadaYMotor1^4-8*CoordenadaXMotor1*Xa^3*LongitudEslabon1^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon2^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon1^2)^(1/2))*CoordenadaYMotor1-1/(-8*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1+4*Ya^2+4*CoordenadaYMotor1^2+4*Xa^2+4*CoordenadaXMotor1^2)*(-4*CoordenadaYMotor1*LongitudEslabon1^2-4*Ya^2*CoordenadaYMotor1+4*Ya^3+4*CoordenadaXMotor1^2*CoordenadaYMotor1-4*Ya*LongitudEslabon2^2+4*Ya*LongitudEslabon1^2+4*Ya*CoordenadaXMotor1^2+4*LongitudEslabon2^2*CoordenadaYMotor1-4*Ya*CoordenadaYMotor1^2+4*Xa^2*Ya-8*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4*Xa^2*CoordenadaYMotor1-8*CoordenadaXMotor1*Xa*Ya+4*CoordenadaYMotor1^3+4*(-2*Xa^4*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*LongitudEslabon2^4+2*Xa^4*LongitudEslabon2^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon1^2+2*Xa^4*LongitudEslabon1^2-15*Xa^4*CoordenadaXMotor1^2-2*Xa^4*Ya^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon2^2-8*CoordenadaXMotor1*Xa^3*LongitudEslabon2^2+2*CoordenadaXMotor1*Xa*LongitudEslabon1^4+2*Xa^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor1^2*LongitudEslabon2^2*LongitudEslabon1^2-16*Xa^3*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4*CoordenadaXMotor1*Xa*LongitudEslabon2^2*LongitudEslabon1^2+8*CoordenadaYMotor1*LongitudEslabon1^2*CoordenadaXMotor1*Xa*Ya-4*Ya*LongitudEslabon2^2*Xa^2*CoordenadaYMotor1+8*Ya*LongitudEslabon2^2*CoordenadaXMotor1*Xa*CoordenadaYMotor1-4*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1*Xa-4*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa-4*LongitudEslabon2^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1^3*CoordenadaXMotor1*Xa+8*Ya^2*CoordenadaXMotor1^3*Xa-Xa^6-CoordenadaXMotor1^6-4*CoordenadaYMotor1*LongitudEslabon1^2*Ya*CoordenadaXMotor1^2-4*CoordenadaYMotor1*LongitudEslabon1^2*Xa^2*Ya-4*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa+12*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1*Xa-4*CoordenadaXMotor1^2*CoordenadaYMotor1*Ya*LongitudEslabon2^2+24*CoordenadaXMotor1^2*CoordenadaYMotor1*Xa^2*Ya-16*CoordenadaXMotor1^3*CoordenadaYMotor1*Xa*Ya-Ya^4*CoordenadaXMotor1^2-Ya^4*Xa^2-2*CoordenadaXMotor1^4*CoordenadaYMotor1^2-CoordenadaXMotor1^2*CoordenadaYMotor1^4-2*Ya^2*CoordenadaXMotor1^4-Xa^2*CoordenadaYMotor1^4+6*CoordenadaXMotor1*Xa^5+6*CoordenadaXMotor1^5*Xa+20*CoordenadaXMotor1^3*Xa^3-15*CoordenadaXMotor1^4*Xa^2-Xa^2*LongitudEslabon2^4-Xa^2*LongitudEslabon1^4-CoordenadaXMotor1^2*LongitudEslabon2^4-CoordenadaXMotor1^2*LongitudEslabon1^4+2*CoordenadaXMotor1^4*LongitudEslabon2^2+2*CoordenadaXMotor1^4*LongitudEslabon1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*Xa^2-6*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*Xa^2-6*Ya^2*CoordenadaYMotor1^2*Xa^2+2*Ya^4*CoordenadaXMotor1*Xa+4*CoordenadaXMotor1^4*CoordenadaYMotor1*Ya+2*CoordenadaXMotor1^2*CoordenadaYMotor1^2*LongitudEslabon2^2+4*CoordenadaXMotor1^2*CoordenadaYMotor1^3*Ya+8*CoordenadaXMotor1^3*CoordenadaYMotor1^2*Xa-12*CoordenadaXMotor1^2*CoordenadaYMotor1^2*Xa^2+2*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon2^2*Xa^2+2*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon1^2*Xa^2-12*Ya^2*CoordenadaXMotor1^2*Xa^2+2*LongitudEslabon2^2*CoordenadaYMotor1^2*Xa^2+4*Ya*CoordenadaYMotor1^3*Xa^2+4*Xa^4*Ya*CoordenadaYMotor1+8*Xa^3*Ya^2*CoordenadaXMotor1+8*CoordenadaXMotor1*Xa^3*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*CoordenadaYMotor1^4-8*CoordenadaXMotor1*Xa^3*LongitudEslabon1^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon2^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon1^2)^(1/2))*Ya+Xa^2+Ya^2-LongitudEslabon2^2-CoordenadaXMotor1^2-CoordenadaYMotor1^2+LongitudEslabon1^2)/(Xa-CoordenadaXMotor1);
      1/2*(1/(-8*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1+4*Ya^2+4*CoordenadaYMotor1^2+4*Xa^2+4*CoordenadaXMotor1^2)*(-4*CoordenadaYMotor1*LongitudEslabon1^2-4*Ya^2*CoordenadaYMotor1+4*Ya^3+4*CoordenadaXMotor1^2*CoordenadaYMotor1-4*Ya*LongitudEslabon2^2+4*Ya*LongitudEslabon1^2+4*Ya*CoordenadaXMotor1^2+4*LongitudEslabon2^2*CoordenadaYMotor1-4*Ya*CoordenadaYMotor1^2+4*Xa^2*Ya-8*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4*Xa^2*CoordenadaYMotor1-8*CoordenadaXMotor1*Xa*Ya+4*CoordenadaYMotor1^3-4*(-2*Xa^4*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*LongitudEslabon2^4+2*Xa^4*LongitudEslabon2^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon1^2+2*Xa^4*LongitudEslabon1^2-15*Xa^4*CoordenadaXMotor1^2-2*Xa^4*Ya^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon2^2-8*CoordenadaXMotor1*Xa^3*LongitudEslabon2^2+2*CoordenadaXMotor1*Xa*LongitudEslabon1^4+2*Xa^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor1^2*LongitudEslabon2^2*LongitudEslabon1^2-16*Xa^3*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4*CoordenadaXMotor1*Xa*LongitudEslabon2^2*LongitudEslabon1^2+8*CoordenadaYMotor1*LongitudEslabon1^2*CoordenadaXMotor1*Xa*Ya-4*Ya*LongitudEslabon2^2*Xa^2*CoordenadaYMotor1+8*Ya*LongitudEslabon2^2*CoordenadaXMotor1*Xa*CoordenadaYMotor1-4*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1*Xa-4*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa-4*LongitudEslabon2^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1^3*CoordenadaXMotor1*Xa+8*Ya^2*CoordenadaXMotor1^3*Xa-Xa^6-CoordenadaXMotor1^6-4*CoordenadaYMotor1*LongitudEslabon1^2*Ya*CoordenadaXMotor1^2-4*CoordenadaYMotor1*LongitudEslabon1^2*Xa^2*Ya-4*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa+12*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1*Xa-4*CoordenadaXMotor1^2*CoordenadaYMotor1*Ya*LongitudEslabon2^2+24*CoordenadaXMotor1^2*CoordenadaYMotor1*Xa^2*Ya-16*CoordenadaXMotor1^3*CoordenadaYMotor1*Xa*Ya-Ya^4*CoordenadaXMotor1^2-Ya^4*Xa^2-2*CoordenadaXMotor1^4*CoordenadaYMotor1^2-CoordenadaXMotor1^2*CoordenadaYMotor1^4-2*Ya^2*CoordenadaXMotor1^4-Xa^2*CoordenadaYMotor1^4+6*CoordenadaXMotor1*Xa^5+6*CoordenadaXMotor1^5*Xa+20*CoordenadaXMotor1^3*Xa^3-15*CoordenadaXMotor1^4*Xa^2-Xa^2*LongitudEslabon2^4-Xa^2*LongitudEslabon1^4-CoordenadaXMotor1^2*LongitudEslabon2^4-CoordenadaXMotor1^2*LongitudEslabon1^4+2*CoordenadaXMotor1^4*LongitudEslabon2^2+2*CoordenadaXMotor1^4*LongitudEslabon1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*Xa^2-6*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*Xa^2-6*Ya^2*CoordenadaYMotor1^2*Xa^2+2*Ya^4*CoordenadaXMotor1*Xa+4*CoordenadaXMotor1^4*CoordenadaYMotor1*Ya+2*CoordenadaXMotor1^2*CoordenadaYMotor1^2*LongitudEslabon2^2+4*CoordenadaXMotor1^2*CoordenadaYMotor1^3*Ya+8*CoordenadaXMotor1^3*CoordenadaYMotor1^2*Xa-12*CoordenadaXMotor1^2*CoordenadaYMotor1^2*Xa^2+2*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon2^2*Xa^2+2*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon1^2*Xa^2-12*Ya^2*CoordenadaXMotor1^2*Xa^2+2*LongitudEslabon2^2*CoordenadaYMotor1^2*Xa^2+4*Ya*CoordenadaYMotor1^3*Xa^2+4*Xa^4*Ya*CoordenadaYMotor1+8*Xa^3*Ya^2*CoordenadaXMotor1+8*CoordenadaXMotor1*Xa^3*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*CoordenadaYMotor1^4-8*CoordenadaXMotor1*Xa^3*LongitudEslabon1^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon2^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon1^2)^(1/2))*CoordenadaYMotor1-1/(-8*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1+4*Ya^2+4*CoordenadaYMotor1^2+4*Xa^2+4*CoordenadaXMotor1^2)*(-4*CoordenadaYMotor1*LongitudEslabon1^2-4*Ya^2*CoordenadaYMotor1+4*Ya^3+4*CoordenadaXMotor1^2*CoordenadaYMotor1-4*Ya*LongitudEslabon2^2+4*Ya*LongitudEslabon1^2+4*Ya*CoordenadaXMotor1^2+4*LongitudEslabon2^2*CoordenadaYMotor1-4*Ya*CoordenadaYMotor1^2+4*Xa^2*Ya-8*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4*Xa^2*CoordenadaYMotor1-8*CoordenadaXMotor1*Xa*Ya+4*CoordenadaYMotor1^3-4*(-2*Xa^4*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*LongitudEslabon2^4+2*Xa^4*LongitudEslabon2^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon1^2+2*Xa^4*LongitudEslabon1^2-15*Xa^4*CoordenadaXMotor1^2-2*Xa^4*Ya^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon2^2-8*CoordenadaXMotor1*Xa^3*LongitudEslabon2^2+2*CoordenadaXMotor1*Xa*LongitudEslabon1^4+2*Xa^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor1^2*LongitudEslabon2^2*LongitudEslabon1^2-16*Xa^3*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4*CoordenadaXMotor1*Xa*LongitudEslabon2^2*LongitudEslabon1^2+8*CoordenadaYMotor1*LongitudEslabon1^2*CoordenadaXMotor1*Xa*Ya-4*Ya*LongitudEslabon2^2*Xa^2*CoordenadaYMotor1+8*Ya*LongitudEslabon2^2*CoordenadaXMotor1*Xa*CoordenadaYMotor1-4*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1*Xa-4*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa-4*LongitudEslabon2^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1^3*CoordenadaXMotor1*Xa+8*Ya^2*CoordenadaXMotor1^3*Xa-Xa^6-CoordenadaXMotor1^6-4*CoordenadaYMotor1*LongitudEslabon1^2*Ya*CoordenadaXMotor1^2-4*CoordenadaYMotor1*LongitudEslabon1^2*Xa^2*Ya-4*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa+12*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1*Xa-4*CoordenadaXMotor1^2*CoordenadaYMotor1*Ya*LongitudEslabon2^2+24*CoordenadaXMotor1^2*CoordenadaYMotor1*Xa^2*Ya-16*CoordenadaXMotor1^3*CoordenadaYMotor1*Xa*Ya-Ya^4*CoordenadaXMotor1^2-Ya^4*Xa^2-2*CoordenadaXMotor1^4*CoordenadaYMotor1^2-CoordenadaXMotor1^2*CoordenadaYMotor1^4-2*Ya^2*CoordenadaXMotor1^4-Xa^2*CoordenadaYMotor1^4+6*CoordenadaXMotor1*Xa^5+6*CoordenadaXMotor1^5*Xa+20*CoordenadaXMotor1^3*Xa^3-15*CoordenadaXMotor1^4*Xa^2-Xa^2*LongitudEslabon2^4-Xa^2*LongitudEslabon1^4-CoordenadaXMotor1^2*LongitudEslabon2^4-CoordenadaXMotor1^2*LongitudEslabon1^4+2*CoordenadaXMotor1^4*LongitudEslabon2^2+2*CoordenadaXMotor1^4*LongitudEslabon1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*Xa^2-6*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*Xa^2-6*Ya^2*CoordenadaYMotor1^2*Xa^2+2*Ya^4*CoordenadaXMotor1*Xa+4*CoordenadaXMotor1^4*CoordenadaYMotor1*Ya+2*CoordenadaXMotor1^2*CoordenadaYMotor1^2*LongitudEslabon2^2+4*CoordenadaXMotor1^2*CoordenadaYMotor1^3*Ya+8*CoordenadaXMotor1^3*CoordenadaYMotor1^2*Xa-12*CoordenadaXMotor1^2*CoordenadaYMotor1^2*Xa^2+2*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon2^2*Xa^2+2*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon1^2*Xa^2-12*Ya^2*CoordenadaXMotor1^2*Xa^2+2*LongitudEslabon2^2*CoordenadaYMotor1^2*Xa^2+4*Ya*CoordenadaYMotor1^3*Xa^2+4*Xa^4*Ya*CoordenadaYMotor1+8*Xa^3*Ya^2*CoordenadaXMotor1+8*CoordenadaXMotor1*Xa^3*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*CoordenadaYMotor1^4-8*CoordenadaXMotor1*Xa^3*LongitudEslabon1^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon2^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon1^2)^(1/2))*Ya+Xa^2+Ya^2-LongitudEslabon2^2-CoordenadaXMotor1^2-CoordenadaYMotor1^2+LongitudEslabon1^2)/(Xa-CoordenadaXMotor1)];
Yd =[ 1/2/(-8*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1+4*Ya^2+4*CoordenadaYMotor1^2+4*Xa^2+4*CoordenadaXMotor1^2)*(-4*CoordenadaYMotor1*LongitudEslabon1^2-4*Ya^2*CoordenadaYMotor1+4*Ya^3+4*CoordenadaXMotor1^2*CoordenadaYMotor1-4*Ya*LongitudEslabon2^2+4*Ya*LongitudEslabon1^2+4*Ya*CoordenadaXMotor1^2+4*LongitudEslabon2^2*CoordenadaYMotor1-4*Ya*CoordenadaYMotor1^2+4*Xa^2*Ya-8*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4*Xa^2*CoordenadaYMotor1-8*CoordenadaXMotor1*Xa*Ya+4*CoordenadaYMotor1^3+4*(-2*Xa^4*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*LongitudEslabon2^4+2*Xa^4*LongitudEslabon2^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon1^2+2*Xa^4*LongitudEslabon1^2-15*Xa^4*CoordenadaXMotor1^2-2*Xa^4*Ya^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon2^2-8*CoordenadaXMotor1*Xa^3*LongitudEslabon2^2+2*CoordenadaXMotor1*Xa*LongitudEslabon1^4+2*Xa^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor1^2*LongitudEslabon2^2*LongitudEslabon1^2-16*Xa^3*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4*CoordenadaXMotor1*Xa*LongitudEslabon2^2*LongitudEslabon1^2+8*CoordenadaYMotor1*LongitudEslabon1^2*CoordenadaXMotor1*Xa*Ya-4*Ya*LongitudEslabon2^2*Xa^2*CoordenadaYMotor1+8*Ya*LongitudEslabon2^2*CoordenadaXMotor1*Xa*CoordenadaYMotor1-4*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1*Xa-4*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa-4*LongitudEslabon2^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1^3*CoordenadaXMotor1*Xa+8*Ya^2*CoordenadaXMotor1^3*Xa-Xa^6-CoordenadaXMotor1^6-4*CoordenadaYMotor1*LongitudEslabon1^2*Ya*CoordenadaXMotor1^2-4*CoordenadaYMotor1*LongitudEslabon1^2*Xa^2*Ya-4*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa+12*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1*Xa-4*CoordenadaXMotor1^2*CoordenadaYMotor1*Ya*LongitudEslabon2^2+24*CoordenadaXMotor1^2*CoordenadaYMotor1*Xa^2*Ya-16*CoordenadaXMotor1^3*CoordenadaYMotor1*Xa*Ya-Ya^4*CoordenadaXMotor1^2-Ya^4*Xa^2-2*CoordenadaXMotor1^4*CoordenadaYMotor1^2-CoordenadaXMotor1^2*CoordenadaYMotor1^4-2*Ya^2*CoordenadaXMotor1^4-Xa^2*CoordenadaYMotor1^4+6*CoordenadaXMotor1*Xa^5+6*CoordenadaXMotor1^5*Xa+20*CoordenadaXMotor1^3*Xa^3-15*CoordenadaXMotor1^4*Xa^2-Xa^2*LongitudEslabon2^4-Xa^2*LongitudEslabon1^4-CoordenadaXMotor1^2*LongitudEslabon2^4-CoordenadaXMotor1^2*LongitudEslabon1^4+2*CoordenadaXMotor1^4*LongitudEslabon2^2+2*CoordenadaXMotor1^4*LongitudEslabon1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*Xa^2-6*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*Xa^2-6*Ya^2*CoordenadaYMotor1^2*Xa^2+2*Ya^4*CoordenadaXMotor1*Xa+4*CoordenadaXMotor1^4*CoordenadaYMotor1*Ya+2*CoordenadaXMotor1^2*CoordenadaYMotor1^2*LongitudEslabon2^2+4*CoordenadaXMotor1^2*CoordenadaYMotor1^3*Ya+8*CoordenadaXMotor1^3*CoordenadaYMotor1^2*Xa-12*CoordenadaXMotor1^2*CoordenadaYMotor1^2*Xa^2+2*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon2^2*Xa^2+2*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon1^2*Xa^2-12*Ya^2*CoordenadaXMotor1^2*Xa^2+2*LongitudEslabon2^2*CoordenadaYMotor1^2*Xa^2+4*Ya*CoordenadaYMotor1^3*Xa^2+4*Xa^4*Ya*CoordenadaYMotor1+8*Xa^3*Ya^2*CoordenadaXMotor1+8*CoordenadaXMotor1*Xa^3*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*CoordenadaYMotor1^4-8*CoordenadaXMotor1*Xa^3*LongitudEslabon1^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon2^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon1^2)^(1/2));
      1/2/(-8*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1+4*Ya^2+4*CoordenadaYMotor1^2+4*Xa^2+4*CoordenadaXMotor1^2)*(-4*CoordenadaYMotor1*LongitudEslabon1^2-4*Ya^2*CoordenadaYMotor1+4*Ya^3+4*CoordenadaXMotor1^2*CoordenadaYMotor1-4*Ya*LongitudEslabon2^2+4*Ya*LongitudEslabon1^2+4*Ya*CoordenadaXMotor1^2+4*LongitudEslabon2^2*CoordenadaYMotor1-4*Ya*CoordenadaYMotor1^2+4*Xa^2*Ya-8*CoordenadaXMotor1*Xa*CoordenadaYMotor1+4*Xa^2*CoordenadaYMotor1-8*CoordenadaXMotor1*Xa*Ya+4*CoordenadaYMotor1^3-4*(-2*Xa^4*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*LongitudEslabon2^4+2*Xa^4*LongitudEslabon2^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon1^2+2*Xa^4*LongitudEslabon1^2-15*Xa^4*CoordenadaXMotor1^2-2*Xa^4*Ya^2+12*CoordenadaXMotor1^2*Xa^2*LongitudEslabon2^2-8*CoordenadaXMotor1*Xa^3*LongitudEslabon2^2+2*CoordenadaXMotor1*Xa*LongitudEslabon1^4+2*Xa^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor1^2*LongitudEslabon2^2*LongitudEslabon1^2-16*Xa^3*Ya*CoordenadaXMotor1*CoordenadaYMotor1-4*CoordenadaXMotor1*Xa*LongitudEslabon2^2*LongitudEslabon1^2+8*CoordenadaYMotor1*LongitudEslabon1^2*CoordenadaXMotor1*Xa*Ya-4*Ya*LongitudEslabon2^2*Xa^2*CoordenadaYMotor1+8*Ya*LongitudEslabon2^2*CoordenadaXMotor1*Xa*CoordenadaYMotor1-4*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1*Xa-4*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa-4*LongitudEslabon2^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya*CoordenadaYMotor1^3*CoordenadaXMotor1*Xa+8*Ya^2*CoordenadaXMotor1^3*Xa-Xa^6-CoordenadaXMotor1^6-4*CoordenadaYMotor1*LongitudEslabon1^2*Ya*CoordenadaXMotor1^2-4*CoordenadaYMotor1*LongitudEslabon1^2*Xa^2*Ya-4*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1*Xa+12*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1*Xa-8*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1*Xa-4*CoordenadaXMotor1^2*CoordenadaYMotor1*Ya*LongitudEslabon2^2+24*CoordenadaXMotor1^2*CoordenadaYMotor1*Xa^2*Ya-16*CoordenadaXMotor1^3*CoordenadaYMotor1*Xa*Ya-Ya^4*CoordenadaXMotor1^2-Ya^4*Xa^2-2*CoordenadaXMotor1^4*CoordenadaYMotor1^2-CoordenadaXMotor1^2*CoordenadaYMotor1^4-2*Ya^2*CoordenadaXMotor1^4-Xa^2*CoordenadaYMotor1^4+6*CoordenadaXMotor1*Xa^5+6*CoordenadaXMotor1^5*Xa+20*CoordenadaXMotor1^3*Xa^3-15*CoordenadaXMotor1^4*Xa^2-Xa^2*LongitudEslabon2^4-Xa^2*LongitudEslabon1^4-CoordenadaXMotor1^2*LongitudEslabon2^4-CoordenadaXMotor1^2*LongitudEslabon1^4+2*CoordenadaXMotor1^4*LongitudEslabon2^2+2*CoordenadaXMotor1^4*LongitudEslabon1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*CoordenadaYMotor1^2*LongitudEslabon1^2*Xa^2-6*Ya^2*CoordenadaYMotor1^2*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*CoordenadaXMotor1^2+4*Ya^3*CoordenadaYMotor1*Xa^2-6*Ya^2*CoordenadaYMotor1^2*Xa^2+2*Ya^4*CoordenadaXMotor1*Xa+4*CoordenadaXMotor1^4*CoordenadaYMotor1*Ya+2*CoordenadaXMotor1^2*CoordenadaYMotor1^2*LongitudEslabon2^2+4*CoordenadaXMotor1^2*CoordenadaYMotor1^3*Ya+8*CoordenadaXMotor1^3*CoordenadaYMotor1^2*Xa-12*CoordenadaXMotor1^2*CoordenadaYMotor1^2*Xa^2+2*Ya^2*LongitudEslabon2^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon2^2*Xa^2+2*Ya^2*LongitudEslabon1^2*CoordenadaXMotor1^2+2*Ya^2*LongitudEslabon1^2*Xa^2-12*Ya^2*CoordenadaXMotor1^2*Xa^2+2*LongitudEslabon2^2*CoordenadaYMotor1^2*Xa^2+4*Ya*CoordenadaYMotor1^3*Xa^2+4*Xa^4*Ya*CoordenadaYMotor1+8*Xa^3*Ya^2*CoordenadaXMotor1+8*CoordenadaXMotor1*Xa^3*CoordenadaYMotor1^2+2*CoordenadaXMotor1*Xa*CoordenadaYMotor1^4-8*CoordenadaXMotor1*Xa^3*LongitudEslabon1^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon2^2-8*CoordenadaXMotor1^3*Xa*LongitudEslabon1^2)^(1/2))];
  


axis([-15 15 -15 15])

Xb = Xa+LongitudLadoTriangulo*cos(Phi);
Yb = Ya+LongitudLadoTriangulo*sin(Phi);


Xdb = [ -1/2*(-1/(-8*CoordenadaYMotor2*Yb-8*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^2+4*Yb^2+4*CoordenadaXMotor2^2+4*Xb^2)*(-8*Xb*CoordenadaXMotor2*Yb+4*CoordenadaYMotor2^3+4*Xb^2*Yb+4*Yb^3+4*CoordenadaYMotor2*Xb^2+4*CoordenadaXMotor2^2*CoordenadaYMotor2-8*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4*CoordenadaYMotor2*LongitudEslabon2^2+4*CoordenadaXMotor2^2*Yb-4*CoordenadaYMotor2*Yb^2+4*LongitudEslabon1^2*Yb-4*Yb*LongitudEslabon2^2-4*CoordenadaYMotor2*LongitudEslabon1^2-4*CoordenadaYMotor2^2*Yb+4*(-8*Xb^3*CoordenadaXMotor2*LongitudEslabon1^2-8*Xb^3*CoordenadaXMotor2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*LongitudEslabon2^2*LongitudEslabon1^2+20*Xb^3*CoordenadaXMotor2^3-15*Xb^2*CoordenadaXMotor2^4+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon1^2+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon2^2-4*CoordenadaXMotor2^2*CoordenadaYMotor2*LongitudEslabon1^2*Yb-4*CoordenadaXMotor2^2*CoordenadaYMotor2*Yb*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon1^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon2^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon1^2+8*CoordenadaXMotor2^3*CoordenadaYMotor2^2*Xb+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon2^2+4*CoordenadaXMotor2^4*CoordenadaYMotor2*Yb-6*CoordenadaXMotor2^2*CoordenadaYMotor2^2*Yb^2+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon1^2-2*CoordenadaYMotor2^2*Xb^4-2*CoordenadaXMotor2^4*CoordenadaYMotor2^2-2*CoordenadaXMotor2^4*Yb^2+4*Xb^2*Yb^3*CoordenadaYMotor2+2*Xb^2*Yb^2*LongitudEslabon1^2+2*Xb^2*Yb^2*LongitudEslabon2^2-6*Xb^2*Yb^2*CoordenadaYMotor2^2+4*Yb^3*CoordenadaXMotor2^2*CoordenadaYMotor2-12*CoordenadaYMotor2^2*Xb^2*CoordenadaXMotor2^2+8*CoordenadaYMotor2^2*Xb^3*CoordenadaXMotor2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-2*Xb^4*Yb^2-Xb^2*Yb^4-Yb^4*CoordenadaXMotor2^2+2*CoordenadaYMotor2^4*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^3*CoordenadaXMotor2^2*Yb+4*Xb^4*Yb*CoordenadaYMotor2+24*Xb^2*CoordenadaXMotor2^2*Yb*CoordenadaYMotor2-CoordenadaYMotor2^4*CoordenadaXMotor2^2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-8*Xb*CoordenadaXMotor2*Yb^3*CoordenadaYMotor2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon2^2+12*Xb*CoordenadaXMotor2*Yb^2*CoordenadaYMotor2^2-16*Xb*CoordenadaXMotor2^3*Yb*CoordenadaYMotor2-Xb^6-12*Xb^2*CoordenadaXMotor2^2*Yb^2+8*Xb^3*CoordenadaXMotor2*Yb^2+2*Xb*CoordenadaXMotor2*Yb^4+8*Xb*CoordenadaXMotor2^3*Yb^2+4*CoordenadaYMotor2^3*Xb^2*Yb-CoordenadaXMotor2^6-CoordenadaYMotor2^4*Xb^2-8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2^3-16*Xb^3*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2*Xb^4*LongitudEslabon2^2+2*Xb^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon2^2-Xb^2*LongitudEslabon2^4-Xb^2*LongitudEslabon1^4+2*Xb^4*LongitudEslabon1^2-CoordenadaXMotor2^2*LongitudEslabon2^4-CoordenadaXMotor2^2*LongitudEslabon1^4+2*CoordenadaXMotor2^2*LongitudEslabon2^2*LongitudEslabon1^2-15*Xb^4*CoordenadaXMotor2^2+6*Xb*CoordenadaXMotor2^5+6*Xb^5*CoordenadaXMotor2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon2^2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon1^2+2*Xb*CoordenadaXMotor2*LongitudEslabon2^4+2*Xb*CoordenadaXMotor2*LongitudEslabon1^4-8*Xb*CoordenadaXMotor2^3*LongitudEslabon1^2-8*Xb*CoordenadaXMotor2^3*LongitudEslabon2^2)^(1/2))*CoordenadaYMotor2+1/(-8*CoordenadaYMotor2*Yb-8*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^2+4*Yb^2+4*CoordenadaXMotor2^2+4*Xb^2)*(-8*Xb*CoordenadaXMotor2*Yb+4*CoordenadaYMotor2^3+4*Xb^2*Yb+4*Yb^3+4*CoordenadaYMotor2*Xb^2+4*CoordenadaXMotor2^2*CoordenadaYMotor2-8*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4*CoordenadaYMotor2*LongitudEslabon2^2+4*CoordenadaXMotor2^2*Yb-4*CoordenadaYMotor2*Yb^2+4*LongitudEslabon1^2*Yb-4*Yb*LongitudEslabon2^2-4*CoordenadaYMotor2*LongitudEslabon1^2-4*CoordenadaYMotor2^2*Yb+4*(-8*Xb^3*CoordenadaXMotor2*LongitudEslabon1^2-8*Xb^3*CoordenadaXMotor2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*LongitudEslabon2^2*LongitudEslabon1^2+20*Xb^3*CoordenadaXMotor2^3-15*Xb^2*CoordenadaXMotor2^4+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon1^2+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon2^2-4*CoordenadaXMotor2^2*CoordenadaYMotor2*LongitudEslabon1^2*Yb-4*CoordenadaXMotor2^2*CoordenadaYMotor2*Yb*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon1^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon2^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon1^2+8*CoordenadaXMotor2^3*CoordenadaYMotor2^2*Xb+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon2^2+4*CoordenadaXMotor2^4*CoordenadaYMotor2*Yb-6*CoordenadaXMotor2^2*CoordenadaYMotor2^2*Yb^2+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon1^2-2*CoordenadaYMotor2^2*Xb^4-2*CoordenadaXMotor2^4*CoordenadaYMotor2^2-2*CoordenadaXMotor2^4*Yb^2+4*Xb^2*Yb^3*CoordenadaYMotor2+2*Xb^2*Yb^2*LongitudEslabon1^2+2*Xb^2*Yb^2*LongitudEslabon2^2-6*Xb^2*Yb^2*CoordenadaYMotor2^2+4*Yb^3*CoordenadaXMotor2^2*CoordenadaYMotor2-12*CoordenadaYMotor2^2*Xb^2*CoordenadaXMotor2^2+8*CoordenadaYMotor2^2*Xb^3*CoordenadaXMotor2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-2*Xb^4*Yb^2-Xb^2*Yb^4-Yb^4*CoordenadaXMotor2^2+2*CoordenadaYMotor2^4*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^3*CoordenadaXMotor2^2*Yb+4*Xb^4*Yb*CoordenadaYMotor2+24*Xb^2*CoordenadaXMotor2^2*Yb*CoordenadaYMotor2-CoordenadaYMotor2^4*CoordenadaXMotor2^2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-8*Xb*CoordenadaXMotor2*Yb^3*CoordenadaYMotor2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon2^2+12*Xb*CoordenadaXMotor2*Yb^2*CoordenadaYMotor2^2-16*Xb*CoordenadaXMotor2^3*Yb*CoordenadaYMotor2-Xb^6-12*Xb^2*CoordenadaXMotor2^2*Yb^2+8*Xb^3*CoordenadaXMotor2*Yb^2+2*Xb*CoordenadaXMotor2*Yb^4+8*Xb*CoordenadaXMotor2^3*Yb^2+4*CoordenadaYMotor2^3*Xb^2*Yb-CoordenadaXMotor2^6-CoordenadaYMotor2^4*Xb^2-8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2^3-16*Xb^3*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2*Xb^4*LongitudEslabon2^2+2*Xb^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon2^2-Xb^2*LongitudEslabon2^4-Xb^2*LongitudEslabon1^4+2*Xb^4*LongitudEslabon1^2-CoordenadaXMotor2^2*LongitudEslabon2^4-CoordenadaXMotor2^2*LongitudEslabon1^4+2*CoordenadaXMotor2^2*LongitudEslabon2^2*LongitudEslabon1^2-15*Xb^4*CoordenadaXMotor2^2+6*Xb*CoordenadaXMotor2^5+6*Xb^5*CoordenadaXMotor2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon2^2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon1^2+2*Xb*CoordenadaXMotor2*LongitudEslabon2^4+2*Xb*CoordenadaXMotor2*LongitudEslabon1^4-8*Xb*CoordenadaXMotor2^3*LongitudEslabon1^2-8*Xb*CoordenadaXMotor2^3*LongitudEslabon2^2)^(1/2))*Yb+CoordenadaXMotor2^2+CoordenadaYMotor2^2-LongitudEslabon1^2-Xb^2-Yb^2+LongitudEslabon2^2)/(-CoordenadaXMotor2+Xb);
        -1/2*(-1/(-8*CoordenadaYMotor2*Yb-8*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^2+4*Yb^2+4*CoordenadaXMotor2^2+4*Xb^2)*(-8*Xb*CoordenadaXMotor2*Yb+4*CoordenadaYMotor2^3+4*Xb^2*Yb+4*Yb^3+4*CoordenadaYMotor2*Xb^2+4*CoordenadaXMotor2^2*CoordenadaYMotor2-8*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4*CoordenadaYMotor2*LongitudEslabon2^2+4*CoordenadaXMotor2^2*Yb-4*CoordenadaYMotor2*Yb^2+4*LongitudEslabon1^2*Yb-4*Yb*LongitudEslabon2^2-4*CoordenadaYMotor2*LongitudEslabon1^2-4*CoordenadaYMotor2^2*Yb-4*(-8*Xb^3*CoordenadaXMotor2*LongitudEslabon1^2-8*Xb^3*CoordenadaXMotor2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*LongitudEslabon2^2*LongitudEslabon1^2+20*Xb^3*CoordenadaXMotor2^3-15*Xb^2*CoordenadaXMotor2^4+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon1^2+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon2^2-4*CoordenadaXMotor2^2*CoordenadaYMotor2*LongitudEslabon1^2*Yb-4*CoordenadaXMotor2^2*CoordenadaYMotor2*Yb*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon1^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon2^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon1^2+8*CoordenadaXMotor2^3*CoordenadaYMotor2^2*Xb+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon2^2+4*CoordenadaXMotor2^4*CoordenadaYMotor2*Yb-6*CoordenadaXMotor2^2*CoordenadaYMotor2^2*Yb^2+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon1^2-2*CoordenadaYMotor2^2*Xb^4-2*CoordenadaXMotor2^4*CoordenadaYMotor2^2-2*CoordenadaXMotor2^4*Yb^2+4*Xb^2*Yb^3*CoordenadaYMotor2+2*Xb^2*Yb^2*LongitudEslabon1^2+2*Xb^2*Yb^2*LongitudEslabon2^2-6*Xb^2*Yb^2*CoordenadaYMotor2^2+4*Yb^3*CoordenadaXMotor2^2*CoordenadaYMotor2-12*CoordenadaYMotor2^2*Xb^2*CoordenadaXMotor2^2+8*CoordenadaYMotor2^2*Xb^3*CoordenadaXMotor2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-2*Xb^4*Yb^2-Xb^2*Yb^4-Yb^4*CoordenadaXMotor2^2+2*CoordenadaYMotor2^4*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^3*CoordenadaXMotor2^2*Yb+4*Xb^4*Yb*CoordenadaYMotor2+24*Xb^2*CoordenadaXMotor2^2*Yb*CoordenadaYMotor2-CoordenadaYMotor2^4*CoordenadaXMotor2^2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-8*Xb*CoordenadaXMotor2*Yb^3*CoordenadaYMotor2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon2^2+12*Xb*CoordenadaXMotor2*Yb^2*CoordenadaYMotor2^2-16*Xb*CoordenadaXMotor2^3*Yb*CoordenadaYMotor2-Xb^6-12*Xb^2*CoordenadaXMotor2^2*Yb^2+8*Xb^3*CoordenadaXMotor2*Yb^2+2*Xb*CoordenadaXMotor2*Yb^4+8*Xb*CoordenadaXMotor2^3*Yb^2+4*CoordenadaYMotor2^3*Xb^2*Yb-CoordenadaXMotor2^6-CoordenadaYMotor2^4*Xb^2-8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2^3-16*Xb^3*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2*Xb^4*LongitudEslabon2^2+2*Xb^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon2^2-Xb^2*LongitudEslabon2^4-Xb^2*LongitudEslabon1^4+2*Xb^4*LongitudEslabon1^2-CoordenadaXMotor2^2*LongitudEslabon2^4-CoordenadaXMotor2^2*LongitudEslabon1^4+2*CoordenadaXMotor2^2*LongitudEslabon2^2*LongitudEslabon1^2-15*Xb^4*CoordenadaXMotor2^2+6*Xb*CoordenadaXMotor2^5+6*Xb^5*CoordenadaXMotor2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon2^2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon1^2+2*Xb*CoordenadaXMotor2*LongitudEslabon2^4+2*Xb*CoordenadaXMotor2*LongitudEslabon1^4-8*Xb*CoordenadaXMotor2^3*LongitudEslabon1^2-8*Xb*CoordenadaXMotor2^3*LongitudEslabon2^2)^(1/2))*CoordenadaYMotor2+1/(-8*CoordenadaYMotor2*Yb-8*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^2+4*Yb^2+4*CoordenadaXMotor2^2+4*Xb^2)*(-8*Xb*CoordenadaXMotor2*Yb+4*CoordenadaYMotor2^3+4*Xb^2*Yb+4*Yb^3+4*CoordenadaYMotor2*Xb^2+4*CoordenadaXMotor2^2*CoordenadaYMotor2-8*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4*CoordenadaYMotor2*LongitudEslabon2^2+4*CoordenadaXMotor2^2*Yb-4*CoordenadaYMotor2*Yb^2+4*LongitudEslabon1^2*Yb-4*Yb*LongitudEslabon2^2-4*CoordenadaYMotor2*LongitudEslabon1^2-4*CoordenadaYMotor2^2*Yb-4*(-8*Xb^3*CoordenadaXMotor2*LongitudEslabon1^2-8*Xb^3*CoordenadaXMotor2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*LongitudEslabon2^2*LongitudEslabon1^2+20*Xb^3*CoordenadaXMotor2^3-15*Xb^2*CoordenadaXMotor2^4+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon1^2+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon2^2-4*CoordenadaXMotor2^2*CoordenadaYMotor2*LongitudEslabon1^2*Yb-4*CoordenadaXMotor2^2*CoordenadaYMotor2*Yb*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon1^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon2^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon1^2+8*CoordenadaXMotor2^3*CoordenadaYMotor2^2*Xb+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon2^2+4*CoordenadaXMotor2^4*CoordenadaYMotor2*Yb-6*CoordenadaXMotor2^2*CoordenadaYMotor2^2*Yb^2+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon1^2-2*CoordenadaYMotor2^2*Xb^4-2*CoordenadaXMotor2^4*CoordenadaYMotor2^2-2*CoordenadaXMotor2^4*Yb^2+4*Xb^2*Yb^3*CoordenadaYMotor2+2*Xb^2*Yb^2*LongitudEslabon1^2+2*Xb^2*Yb^2*LongitudEslabon2^2-6*Xb^2*Yb^2*CoordenadaYMotor2^2+4*Yb^3*CoordenadaXMotor2^2*CoordenadaYMotor2-12*CoordenadaYMotor2^2*Xb^2*CoordenadaXMotor2^2+8*CoordenadaYMotor2^2*Xb^3*CoordenadaXMotor2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-2*Xb^4*Yb^2-Xb^2*Yb^4-Yb^4*CoordenadaXMotor2^2+2*CoordenadaYMotor2^4*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^3*CoordenadaXMotor2^2*Yb+4*Xb^4*Yb*CoordenadaYMotor2+24*Xb^2*CoordenadaXMotor2^2*Yb*CoordenadaYMotor2-CoordenadaYMotor2^4*CoordenadaXMotor2^2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-8*Xb*CoordenadaXMotor2*Yb^3*CoordenadaYMotor2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon2^2+12*Xb*CoordenadaXMotor2*Yb^2*CoordenadaYMotor2^2-16*Xb*CoordenadaXMotor2^3*Yb*CoordenadaYMotor2-Xb^6-12*Xb^2*CoordenadaXMotor2^2*Yb^2+8*Xb^3*CoordenadaXMotor2*Yb^2+2*Xb*CoordenadaXMotor2*Yb^4+8*Xb*CoordenadaXMotor2^3*Yb^2+4*CoordenadaYMotor2^3*Xb^2*Yb-CoordenadaXMotor2^6-CoordenadaYMotor2^4*Xb^2-8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2^3-16*Xb^3*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2*Xb^4*LongitudEslabon2^2+2*Xb^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon2^2-Xb^2*LongitudEslabon2^4-Xb^2*LongitudEslabon1^4+2*Xb^4*LongitudEslabon1^2-CoordenadaXMotor2^2*LongitudEslabon2^4-CoordenadaXMotor2^2*LongitudEslabon1^4+2*CoordenadaXMotor2^2*LongitudEslabon2^2*LongitudEslabon1^2-15*Xb^4*CoordenadaXMotor2^2+6*Xb*CoordenadaXMotor2^5+6*Xb^5*CoordenadaXMotor2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon2^2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon1^2+2*Xb*CoordenadaXMotor2*LongitudEslabon2^4+2*Xb*CoordenadaXMotor2*LongitudEslabon1^4-8*Xb*CoordenadaXMotor2^3*LongitudEslabon1^2-8*Xb*CoordenadaXMotor2^3*LongitudEslabon2^2)^(1/2))*Yb+CoordenadaXMotor2^2+CoordenadaYMotor2^2-LongitudEslabon1^2-Xb^2-Yb^2+LongitudEslabon2^2)/(-CoordenadaXMotor2+Xb)];

Ydb = [ 1/2/(-8*CoordenadaYMotor2*Yb-8*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^2+4*Yb^2+4*CoordenadaXMotor2^2+4*Xb^2)*(-8*Xb*CoordenadaXMotor2*Yb+4*CoordenadaYMotor2^3+4*Xb^2*Yb+4*Yb^3+4*CoordenadaYMotor2*Xb^2+4*CoordenadaXMotor2^2*CoordenadaYMotor2-8*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4*CoordenadaYMotor2*LongitudEslabon2^2+4*CoordenadaXMotor2^2*Yb-4*CoordenadaYMotor2*Yb^2+4*LongitudEslabon1^2*Yb-4*Yb*LongitudEslabon2^2-4*CoordenadaYMotor2*LongitudEslabon1^2-4*CoordenadaYMotor2^2*Yb+4*(-8*Xb^3*CoordenadaXMotor2*LongitudEslabon1^2-8*Xb^3*CoordenadaXMotor2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*LongitudEslabon2^2*LongitudEslabon1^2+20*Xb^3*CoordenadaXMotor2^3-15*Xb^2*CoordenadaXMotor2^4+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon1^2+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon2^2-4*CoordenadaXMotor2^2*CoordenadaYMotor2*LongitudEslabon1^2*Yb-4*CoordenadaXMotor2^2*CoordenadaYMotor2*Yb*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon1^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon2^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon1^2+8*CoordenadaXMotor2^3*CoordenadaYMotor2^2*Xb+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon2^2+4*CoordenadaXMotor2^4*CoordenadaYMotor2*Yb-6*CoordenadaXMotor2^2*CoordenadaYMotor2^2*Yb^2+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon1^2-2*CoordenadaYMotor2^2*Xb^4-2*CoordenadaXMotor2^4*CoordenadaYMotor2^2-2*CoordenadaXMotor2^4*Yb^2+4*Xb^2*Yb^3*CoordenadaYMotor2+2*Xb^2*Yb^2*LongitudEslabon1^2+2*Xb^2*Yb^2*LongitudEslabon2^2-6*Xb^2*Yb^2*CoordenadaYMotor2^2+4*Yb^3*CoordenadaXMotor2^2*CoordenadaYMotor2-12*CoordenadaYMotor2^2*Xb^2*CoordenadaXMotor2^2+8*CoordenadaYMotor2^2*Xb^3*CoordenadaXMotor2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-2*Xb^4*Yb^2-Xb^2*Yb^4-Yb^4*CoordenadaXMotor2^2+2*CoordenadaYMotor2^4*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^3*CoordenadaXMotor2^2*Yb+4*Xb^4*Yb*CoordenadaYMotor2+24*Xb^2*CoordenadaXMotor2^2*Yb*CoordenadaYMotor2-CoordenadaYMotor2^4*CoordenadaXMotor2^2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-8*Xb*CoordenadaXMotor2*Yb^3*CoordenadaYMotor2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon2^2+12*Xb*CoordenadaXMotor2*Yb^2*CoordenadaYMotor2^2-16*Xb*CoordenadaXMotor2^3*Yb*CoordenadaYMotor2-Xb^6-12*Xb^2*CoordenadaXMotor2^2*Yb^2+8*Xb^3*CoordenadaXMotor2*Yb^2+2*Xb*CoordenadaXMotor2*Yb^4+8*Xb*CoordenadaXMotor2^3*Yb^2+4*CoordenadaYMotor2^3*Xb^2*Yb-CoordenadaXMotor2^6-CoordenadaYMotor2^4*Xb^2-8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2^3-16*Xb^3*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2*Xb^4*LongitudEslabon2^2+2*Xb^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon2^2-Xb^2*LongitudEslabon2^4-Xb^2*LongitudEslabon1^4+2*Xb^4*LongitudEslabon1^2-CoordenadaXMotor2^2*LongitudEslabon2^4-CoordenadaXMotor2^2*LongitudEslabon1^4+2*CoordenadaXMotor2^2*LongitudEslabon2^2*LongitudEslabon1^2-15*Xb^4*CoordenadaXMotor2^2+6*Xb*CoordenadaXMotor2^5+6*Xb^5*CoordenadaXMotor2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon2^2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon1^2+2*Xb*CoordenadaXMotor2*LongitudEslabon2^4+2*Xb*CoordenadaXMotor2*LongitudEslabon1^4-8*Xb*CoordenadaXMotor2^3*LongitudEslabon1^2-8*Xb*CoordenadaXMotor2^3*LongitudEslabon2^2)^(1/2));
        1/2/(-8*CoordenadaYMotor2*Yb-8*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^2+4*Yb^2+4*CoordenadaXMotor2^2+4*Xb^2)*(-8*Xb*CoordenadaXMotor2*Yb+4*CoordenadaYMotor2^3+4*Xb^2*Yb+4*Yb^3+4*CoordenadaYMotor2*Xb^2+4*CoordenadaXMotor2^2*CoordenadaYMotor2-8*Xb*CoordenadaXMotor2*CoordenadaYMotor2+4*CoordenadaYMotor2*LongitudEslabon2^2+4*CoordenadaXMotor2^2*Yb-4*CoordenadaYMotor2*Yb^2+4*LongitudEslabon1^2*Yb-4*Yb*LongitudEslabon2^2-4*CoordenadaYMotor2*LongitudEslabon1^2-4*CoordenadaYMotor2^2*Yb-4*(-8*Xb^3*CoordenadaXMotor2*LongitudEslabon1^2-8*Xb^3*CoordenadaXMotor2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*LongitudEslabon2^2*LongitudEslabon1^2+20*Xb^3*CoordenadaXMotor2^3-15*Xb^2*CoordenadaXMotor2^4+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon1^2+2*CoordenadaXMotor2^2*Yb^2*LongitudEslabon2^2-4*CoordenadaXMotor2^2*CoordenadaYMotor2*LongitudEslabon1^2*Yb-4*CoordenadaXMotor2^2*CoordenadaYMotor2*Yb*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon2^2-4*Xb*CoordenadaXMotor2*CoordenadaYMotor2^2*LongitudEslabon1^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon2^2+2*CoordenadaYMotor2^2*Xb^2*LongitudEslabon1^2+8*CoordenadaXMotor2^3*CoordenadaYMotor2^2*Xb+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon2^2+4*CoordenadaXMotor2^4*CoordenadaYMotor2*Yb-6*CoordenadaXMotor2^2*CoordenadaYMotor2^2*Yb^2+2*CoordenadaXMotor2^2*CoordenadaYMotor2^2*LongitudEslabon1^2-2*CoordenadaYMotor2^2*Xb^4-2*CoordenadaXMotor2^4*CoordenadaYMotor2^2-2*CoordenadaXMotor2^4*Yb^2+4*Xb^2*Yb^3*CoordenadaYMotor2+2*Xb^2*Yb^2*LongitudEslabon1^2+2*Xb^2*Yb^2*LongitudEslabon2^2-6*Xb^2*Yb^2*CoordenadaYMotor2^2+4*Yb^3*CoordenadaXMotor2^2*CoordenadaYMotor2-12*CoordenadaYMotor2^2*Xb^2*CoordenadaXMotor2^2+8*CoordenadaYMotor2^2*Xb^3*CoordenadaXMotor2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-4*Xb^2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-2*Xb^4*Yb^2-Xb^2*Yb^4-Yb^4*CoordenadaXMotor2^2+2*CoordenadaYMotor2^4*Xb*CoordenadaXMotor2+4*CoordenadaYMotor2^3*CoordenadaXMotor2^2*Yb+4*Xb^4*Yb*CoordenadaYMotor2+24*Xb^2*CoordenadaXMotor2^2*Yb*CoordenadaYMotor2-CoordenadaYMotor2^4*CoordenadaXMotor2^2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon2^2-8*Xb*CoordenadaXMotor2*Yb^3*CoordenadaYMotor2+8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon1^2-4*Xb*CoordenadaXMotor2*Yb^2*LongitudEslabon2^2+12*Xb*CoordenadaXMotor2*Yb^2*CoordenadaYMotor2^2-16*Xb*CoordenadaXMotor2^3*Yb*CoordenadaYMotor2-Xb^6-12*Xb^2*CoordenadaXMotor2^2*Yb^2+8*Xb^3*CoordenadaXMotor2*Yb^2+2*Xb*CoordenadaXMotor2*Yb^4+8*Xb*CoordenadaXMotor2^3*Yb^2+4*CoordenadaYMotor2^3*Xb^2*Yb-CoordenadaXMotor2^6-CoordenadaYMotor2^4*Xb^2-8*Xb*CoordenadaXMotor2*Yb*CoordenadaYMotor2^3-16*Xb^3*CoordenadaXMotor2*Yb*CoordenadaYMotor2+2*Xb^4*LongitudEslabon2^2+2*Xb^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon1^2+2*CoordenadaXMotor2^4*LongitudEslabon2^2-Xb^2*LongitudEslabon2^4-Xb^2*LongitudEslabon1^4+2*Xb^4*LongitudEslabon1^2-CoordenadaXMotor2^2*LongitudEslabon2^4-CoordenadaXMotor2^2*LongitudEslabon1^4+2*CoordenadaXMotor2^2*LongitudEslabon2^2*LongitudEslabon1^2-15*Xb^4*CoordenadaXMotor2^2+6*Xb*CoordenadaXMotor2^5+6*Xb^5*CoordenadaXMotor2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon2^2+12*Xb^2*CoordenadaXMotor2^2*LongitudEslabon1^2+2*Xb*CoordenadaXMotor2*LongitudEslabon2^4+2*Xb*CoordenadaXMotor2*LongitudEslabon1^4-8*Xb*CoordenadaXMotor2^3*LongitudEslabon1^2-8*Xb*CoordenadaXMotor2^3*LongitudEslabon2^2)^(1/2))];

axis([-15 15 -15 15])


Xc = Xa+LongitudLadoTriangulo*cos(Phi+pi/3);
Yc = Ya+LongitudLadoTriangulo*sin(Phi+pi/3);

Xdc = [ -1/2*(1/(-8*Yc*CoordenadaYMotor3-8*CoordenadaXMotor3*Xc+4*Yc^2+4*CoordenadaYMotor3^2+4*Xc^2+4*CoordenadaXMotor3^2)*(-4*Yc*CoordenadaYMotor3^2+4*Yc^3-8*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4*CoordenadaYMotor3^3-4*CoordenadaYMotor3*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc*Yc+4*Yc*CoordenadaXMotor3^2+4*Yc*LongitudEslabon1^2+4*Xc^2*Yc-4*Yc*LongitudEslabon2^2-4*Yc^2*CoordenadaYMotor3+4*LongitudEslabon2^2*CoordenadaYMotor3+4*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Xc^2*CoordenadaYMotor3+4*(-6*Yc^2*CoordenadaYMotor3^2*Xc^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*Xc^2+4*Yc*CoordenadaXMotor3^4*CoordenadaYMotor3+2*Yc^2*LongitudEslabon1^2*Xc^2+2*Xc^2*Yc^2*LongitudEslabon2^2+4*Xc^4*Yc*CoordenadaYMotor3-4*CoordenadaYMotor3*LongitudEslabon1^2*Xc^2*Yc-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon2^2-4*Yc*CoordenadaXMotor3^2*LongitudEslabon2^2*CoordenadaYMotor3-4*Xc^2*Yc*LongitudEslabon2^2*CoordenadaYMotor3+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon1^2+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon2^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*CoordenadaXMotor3^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*Xc^2-12*CoordenadaXMotor3^2*Xc^2*Yc^2+8*CoordenadaXMotor3^3*Xc*Yc^2+8*CoordenadaXMotor3*Xc^3*Yc^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon1^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon2^2+24*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3*Yc-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon2^2-4*CoordenadaYMotor3*LongitudEslabon1^2*Yc*CoordenadaXMotor3^2-8*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3*Xc+12*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3*Xc-8*Yc^3*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon1^2-6*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*Xc^2+2*Yc^4*CoordenadaXMotor3*Xc-Xc^6-CoordenadaXMotor3^6-Yc^4*CoordenadaXMotor3^2-Yc^4*Xc^2-CoordenadaYMotor3^4*CoordenadaXMotor3^2-CoordenadaYMotor3^4*Xc^2-2*Yc^2*CoordenadaXMotor3^4-2*Xc^4*Yc^2-2*CoordenadaXMotor3^4*CoordenadaYMotor3^2-2*Xc^4*CoordenadaYMotor3^2+6*CoordenadaXMotor3*Xc^5+6*CoordenadaXMotor3^5*Xc+20*CoordenadaXMotor3^3*Xc^3-15*CoordenadaXMotor3^2*Xc^4-15*CoordenadaXMotor3^4*Xc^2-Xc^2*LongitudEslabon2^4-Xc^2*LongitudEslabon1^4+2*Xc^4*LongitudEslabon2^2+2*Xc^4*LongitudEslabon1^2-CoordenadaXMotor3^2*LongitudEslabon2^4-CoordenadaXMotor3^2*LongitudEslabon1^4+2*CoordenadaXMotor3^4*LongitudEslabon2^2+2*CoordenadaXMotor3^4*LongitudEslabon1^2+4*Yc^3*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Yc^3*Xc^2*CoordenadaYMotor3-12*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*CoordenadaYMotor3^4+8*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3^2+8*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*LongitudEslabon2^4+2*CoordenadaXMotor3*Xc*LongitudEslabon1^4+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon2^2+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon2^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon1^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon2^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*LongitudEslabon2^2*LongitudEslabon1^2+2*Xc^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor3^2*LongitudEslabon2^2*LongitudEslabon1^2)^(1/2))*Yc-1/(-8*Yc*CoordenadaYMotor3-8*CoordenadaXMotor3*Xc+4*Yc^2+4*CoordenadaYMotor3^2+4*Xc^2+4*CoordenadaXMotor3^2)*(-4*Yc*CoordenadaYMotor3^2+4*Yc^3-8*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4*CoordenadaYMotor3^3-4*CoordenadaYMotor3*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc*Yc+4*Yc*CoordenadaXMotor3^2+4*Yc*LongitudEslabon1^2+4*Xc^2*Yc-4*Yc*LongitudEslabon2^2-4*Yc^2*CoordenadaYMotor3+4*LongitudEslabon2^2*CoordenadaYMotor3+4*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Xc^2*CoordenadaYMotor3+4*(-6*Yc^2*CoordenadaYMotor3^2*Xc^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*Xc^2+4*Yc*CoordenadaXMotor3^4*CoordenadaYMotor3+2*Yc^2*LongitudEslabon1^2*Xc^2+2*Xc^2*Yc^2*LongitudEslabon2^2+4*Xc^4*Yc*CoordenadaYMotor3-4*CoordenadaYMotor3*LongitudEslabon1^2*Xc^2*Yc-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon2^2-4*Yc*CoordenadaXMotor3^2*LongitudEslabon2^2*CoordenadaYMotor3-4*Xc^2*Yc*LongitudEslabon2^2*CoordenadaYMotor3+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon1^2+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon2^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*CoordenadaXMotor3^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*Xc^2-12*CoordenadaXMotor3^2*Xc^2*Yc^2+8*CoordenadaXMotor3^3*Xc*Yc^2+8*CoordenadaXMotor3*Xc^3*Yc^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon1^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon2^2+24*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3*Yc-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon2^2-4*CoordenadaYMotor3*LongitudEslabon1^2*Yc*CoordenadaXMotor3^2-8*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3*Xc+12*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3*Xc-8*Yc^3*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon1^2-6*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*Xc^2+2*Yc^4*CoordenadaXMotor3*Xc-Xc^6-CoordenadaXMotor3^6-Yc^4*CoordenadaXMotor3^2-Yc^4*Xc^2-CoordenadaYMotor3^4*CoordenadaXMotor3^2-CoordenadaYMotor3^4*Xc^2-2*Yc^2*CoordenadaXMotor3^4-2*Xc^4*Yc^2-2*CoordenadaXMotor3^4*CoordenadaYMotor3^2-2*Xc^4*CoordenadaYMotor3^2+6*CoordenadaXMotor3*Xc^5+6*CoordenadaXMotor3^5*Xc+20*CoordenadaXMotor3^3*Xc^3-15*CoordenadaXMotor3^2*Xc^4-15*CoordenadaXMotor3^4*Xc^2-Xc^2*LongitudEslabon2^4-Xc^2*LongitudEslabon1^4+2*Xc^4*LongitudEslabon2^2+2*Xc^4*LongitudEslabon1^2-CoordenadaXMotor3^2*LongitudEslabon2^4-CoordenadaXMotor3^2*LongitudEslabon1^4+2*CoordenadaXMotor3^4*LongitudEslabon2^2+2*CoordenadaXMotor3^4*LongitudEslabon1^2+4*Yc^3*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Yc^3*Xc^2*CoordenadaYMotor3-12*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*CoordenadaYMotor3^4+8*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3^2+8*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*LongitudEslabon2^4+2*CoordenadaXMotor3*Xc*LongitudEslabon1^4+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon2^2+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon2^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon1^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon2^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*LongitudEslabon2^2*LongitudEslabon1^2+2*Xc^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor3^2*LongitudEslabon2^2*LongitudEslabon1^2)^(1/2))*CoordenadaYMotor3-Xc^2-Yc^2+LongitudEslabon2^2+CoordenadaXMotor3^2+CoordenadaYMotor3^2-LongitudEslabon1^2)/(Xc-CoordenadaXMotor3);
        -1/2*(1/(-8*Yc*CoordenadaYMotor3-8*CoordenadaXMotor3*Xc+4*Yc^2+4*CoordenadaYMotor3^2+4*Xc^2+4*CoordenadaXMotor3^2)*(-4*Yc*CoordenadaYMotor3^2+4*Yc^3-8*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4*CoordenadaYMotor3^3-4*CoordenadaYMotor3*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc*Yc+4*Yc*CoordenadaXMotor3^2+4*Yc*LongitudEslabon1^2+4*Xc^2*Yc-4*Yc*LongitudEslabon2^2-4*Yc^2*CoordenadaYMotor3+4*LongitudEslabon2^2*CoordenadaYMotor3+4*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Xc^2*CoordenadaYMotor3-4*(-6*Yc^2*CoordenadaYMotor3^2*Xc^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*Xc^2+4*Yc*CoordenadaXMotor3^4*CoordenadaYMotor3+2*Yc^2*LongitudEslabon1^2*Xc^2+2*Xc^2*Yc^2*LongitudEslabon2^2+4*Xc^4*Yc*CoordenadaYMotor3-4*CoordenadaYMotor3*LongitudEslabon1^2*Xc^2*Yc-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon2^2-4*Yc*CoordenadaXMotor3^2*LongitudEslabon2^2*CoordenadaYMotor3-4*Xc^2*Yc*LongitudEslabon2^2*CoordenadaYMotor3+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon1^2+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon2^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*CoordenadaXMotor3^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*Xc^2-12*CoordenadaXMotor3^2*Xc^2*Yc^2+8*CoordenadaXMotor3^3*Xc*Yc^2+8*CoordenadaXMotor3*Xc^3*Yc^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon1^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon2^2+24*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3*Yc-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon2^2-4*CoordenadaYMotor3*LongitudEslabon1^2*Yc*CoordenadaXMotor3^2-8*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3*Xc+12*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3*Xc-8*Yc^3*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon1^2-6*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*Xc^2+2*Yc^4*CoordenadaXMotor3*Xc-Xc^6-CoordenadaXMotor3^6-Yc^4*CoordenadaXMotor3^2-Yc^4*Xc^2-CoordenadaYMotor3^4*CoordenadaXMotor3^2-CoordenadaYMotor3^4*Xc^2-2*Yc^2*CoordenadaXMotor3^4-2*Xc^4*Yc^2-2*CoordenadaXMotor3^4*CoordenadaYMotor3^2-2*Xc^4*CoordenadaYMotor3^2+6*CoordenadaXMotor3*Xc^5+6*CoordenadaXMotor3^5*Xc+20*CoordenadaXMotor3^3*Xc^3-15*CoordenadaXMotor3^2*Xc^4-15*CoordenadaXMotor3^4*Xc^2-Xc^2*LongitudEslabon2^4-Xc^2*LongitudEslabon1^4+2*Xc^4*LongitudEslabon2^2+2*Xc^4*LongitudEslabon1^2-CoordenadaXMotor3^2*LongitudEslabon2^4-CoordenadaXMotor3^2*LongitudEslabon1^4+2*CoordenadaXMotor3^4*LongitudEslabon2^2+2*CoordenadaXMotor3^4*LongitudEslabon1^2+4*Yc^3*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Yc^3*Xc^2*CoordenadaYMotor3-12*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*CoordenadaYMotor3^4+8*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3^2+8*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*LongitudEslabon2^4+2*CoordenadaXMotor3*Xc*LongitudEslabon1^4+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon2^2+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon2^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon1^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon2^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*LongitudEslabon2^2*LongitudEslabon1^2+2*Xc^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor3^2*LongitudEslabon2^2*LongitudEslabon1^2)^(1/2))*Yc-1/(-8*Yc*CoordenadaYMotor3-8*CoordenadaXMotor3*Xc+4*Yc^2+4*CoordenadaYMotor3^2+4*Xc^2+4*CoordenadaXMotor3^2)*(-4*Yc*CoordenadaYMotor3^2+4*Yc^3-8*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4*CoordenadaYMotor3^3-4*CoordenadaYMotor3*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc*Yc+4*Yc*CoordenadaXMotor3^2+4*Yc*LongitudEslabon1^2+4*Xc^2*Yc-4*Yc*LongitudEslabon2^2-4*Yc^2*CoordenadaYMotor3+4*LongitudEslabon2^2*CoordenadaYMotor3+4*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Xc^2*CoordenadaYMotor3-4*(-6*Yc^2*CoordenadaYMotor3^2*Xc^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*Xc^2+4*Yc*CoordenadaXMotor3^4*CoordenadaYMotor3+2*Yc^2*LongitudEslabon1^2*Xc^2+2*Xc^2*Yc^2*LongitudEslabon2^2+4*Xc^4*Yc*CoordenadaYMotor3-4*CoordenadaYMotor3*LongitudEslabon1^2*Xc^2*Yc-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon2^2-4*Yc*CoordenadaXMotor3^2*LongitudEslabon2^2*CoordenadaYMotor3-4*Xc^2*Yc*LongitudEslabon2^2*CoordenadaYMotor3+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon1^2+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon2^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*CoordenadaXMotor3^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*Xc^2-12*CoordenadaXMotor3^2*Xc^2*Yc^2+8*CoordenadaXMotor3^3*Xc*Yc^2+8*CoordenadaXMotor3*Xc^3*Yc^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon1^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon2^2+24*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3*Yc-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon2^2-4*CoordenadaYMotor3*LongitudEslabon1^2*Yc*CoordenadaXMotor3^2-8*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3*Xc+12*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3*Xc-8*Yc^3*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon1^2-6*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*Xc^2+2*Yc^4*CoordenadaXMotor3*Xc-Xc^6-CoordenadaXMotor3^6-Yc^4*CoordenadaXMotor3^2-Yc^4*Xc^2-CoordenadaYMotor3^4*CoordenadaXMotor3^2-CoordenadaYMotor3^4*Xc^2-2*Yc^2*CoordenadaXMotor3^4-2*Xc^4*Yc^2-2*CoordenadaXMotor3^4*CoordenadaYMotor3^2-2*Xc^4*CoordenadaYMotor3^2+6*CoordenadaXMotor3*Xc^5+6*CoordenadaXMotor3^5*Xc+20*CoordenadaXMotor3^3*Xc^3-15*CoordenadaXMotor3^2*Xc^4-15*CoordenadaXMotor3^4*Xc^2-Xc^2*LongitudEslabon2^4-Xc^2*LongitudEslabon1^4+2*Xc^4*LongitudEslabon2^2+2*Xc^4*LongitudEslabon1^2-CoordenadaXMotor3^2*LongitudEslabon2^4-CoordenadaXMotor3^2*LongitudEslabon1^4+2*CoordenadaXMotor3^4*LongitudEslabon2^2+2*CoordenadaXMotor3^4*LongitudEslabon1^2+4*Yc^3*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Yc^3*Xc^2*CoordenadaYMotor3-12*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*CoordenadaYMotor3^4+8*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3^2+8*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*LongitudEslabon2^4+2*CoordenadaXMotor3*Xc*LongitudEslabon1^4+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon2^2+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon2^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon1^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon2^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*LongitudEslabon2^2*LongitudEslabon1^2+2*Xc^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor3^2*LongitudEslabon2^2*LongitudEslabon1^2)^(1/2))*CoordenadaYMotor3-Xc^2-Yc^2+LongitudEslabon2^2+CoordenadaXMotor3^2+CoordenadaYMotor3^2-LongitudEslabon1^2)/(Xc-CoordenadaXMotor3)];
 
 
Ydc = [ 1/2/(-8*Yc*CoordenadaYMotor3-8*CoordenadaXMotor3*Xc+4*Yc^2+4*CoordenadaYMotor3^2+4*Xc^2+4*CoordenadaXMotor3^2)*(-4*Yc*CoordenadaYMotor3^2+4*Yc^3-8*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4*CoordenadaYMotor3^3-4*CoordenadaYMotor3*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc*Yc+4*Yc*CoordenadaXMotor3^2+4*Yc*LongitudEslabon1^2+4*Xc^2*Yc-4*Yc*LongitudEslabon2^2-4*Yc^2*CoordenadaYMotor3+4*LongitudEslabon2^2*CoordenadaYMotor3+4*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Xc^2*CoordenadaYMotor3+4*(-6*Yc^2*CoordenadaYMotor3^2*Xc^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*Xc^2+4*Yc*CoordenadaXMotor3^4*CoordenadaYMotor3+2*Yc^2*LongitudEslabon1^2*Xc^2+2*Xc^2*Yc^2*LongitudEslabon2^2+4*Xc^4*Yc*CoordenadaYMotor3-4*CoordenadaYMotor3*LongitudEslabon1^2*Xc^2*Yc-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon2^2-4*Yc*CoordenadaXMotor3^2*LongitudEslabon2^2*CoordenadaYMotor3-4*Xc^2*Yc*LongitudEslabon2^2*CoordenadaYMotor3+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon1^2+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon2^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*CoordenadaXMotor3^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*Xc^2-12*CoordenadaXMotor3^2*Xc^2*Yc^2+8*CoordenadaXMotor3^3*Xc*Yc^2+8*CoordenadaXMotor3*Xc^3*Yc^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon1^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon2^2+24*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3*Yc-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon2^2-4*CoordenadaYMotor3*LongitudEslabon1^2*Yc*CoordenadaXMotor3^2-8*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3*Xc+12*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3*Xc-8*Yc^3*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon1^2-6*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*Xc^2+2*Yc^4*CoordenadaXMotor3*Xc-Xc^6-CoordenadaXMotor3^6-Yc^4*CoordenadaXMotor3^2-Yc^4*Xc^2-CoordenadaYMotor3^4*CoordenadaXMotor3^2-CoordenadaYMotor3^4*Xc^2-2*Yc^2*CoordenadaXMotor3^4-2*Xc^4*Yc^2-2*CoordenadaXMotor3^4*CoordenadaYMotor3^2-2*Xc^4*CoordenadaYMotor3^2+6*CoordenadaXMotor3*Xc^5+6*CoordenadaXMotor3^5*Xc+20*CoordenadaXMotor3^3*Xc^3-15*CoordenadaXMotor3^2*Xc^4-15*CoordenadaXMotor3^4*Xc^2-Xc^2*LongitudEslabon2^4-Xc^2*LongitudEslabon1^4+2*Xc^4*LongitudEslabon2^2+2*Xc^4*LongitudEslabon1^2-CoordenadaXMotor3^2*LongitudEslabon2^4-CoordenadaXMotor3^2*LongitudEslabon1^4+2*CoordenadaXMotor3^4*LongitudEslabon2^2+2*CoordenadaXMotor3^4*LongitudEslabon1^2+4*Yc^3*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Yc^3*Xc^2*CoordenadaYMotor3-12*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*CoordenadaYMotor3^4+8*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3^2+8*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*LongitudEslabon2^4+2*CoordenadaXMotor3*Xc*LongitudEslabon1^4+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon2^2+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon2^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon1^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon2^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*LongitudEslabon2^2*LongitudEslabon1^2+2*Xc^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor3^2*LongitudEslabon2^2*LongitudEslabon1^2)^(1/2));
        1/2/(-8*Yc*CoordenadaYMotor3-8*CoordenadaXMotor3*Xc+4*Yc^2+4*CoordenadaYMotor3^2+4*Xc^2+4*CoordenadaXMotor3^2)*(-4*Yc*CoordenadaYMotor3^2+4*Yc^3-8*CoordenadaXMotor3*Xc*CoordenadaYMotor3+4*CoordenadaYMotor3^3-4*CoordenadaYMotor3*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc*Yc+4*Yc*CoordenadaXMotor3^2+4*Yc*LongitudEslabon1^2+4*Xc^2*Yc-4*Yc*LongitudEslabon2^2-4*Yc^2*CoordenadaYMotor3+4*LongitudEslabon2^2*CoordenadaYMotor3+4*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Xc^2*CoordenadaYMotor3-4*(-6*Yc^2*CoordenadaYMotor3^2*Xc^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+2*LongitudEslabon2^2*CoordenadaYMotor3^2*Xc^2+4*Yc*CoordenadaXMotor3^4*CoordenadaYMotor3+2*Yc^2*LongitudEslabon1^2*Xc^2+2*Xc^2*Yc^2*LongitudEslabon2^2+4*Xc^4*Yc*CoordenadaYMotor3-4*CoordenadaYMotor3*LongitudEslabon1^2*Xc^2*Yc-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*Yc^2*LongitudEslabon2^2-4*Yc*CoordenadaXMotor3^2*LongitudEslabon2^2*CoordenadaYMotor3-4*Xc^2*Yc*LongitudEslabon2^2*CoordenadaYMotor3+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon1^2+8*CoordenadaXMotor3*Xc*CoordenadaYMotor3*Yc*LongitudEslabon2^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*CoordenadaXMotor3^2+2*CoordenadaYMotor3^2*LongitudEslabon1^2*Xc^2-12*CoordenadaXMotor3^2*Xc^2*Yc^2+8*CoordenadaXMotor3^3*Xc*Yc^2+8*CoordenadaXMotor3*Xc^3*Yc^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon1^2+2*Yc^2*CoordenadaXMotor3^2*LongitudEslabon2^2+24*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3*Yc-16*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3*Yc-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon2^2-4*CoordenadaYMotor3*LongitudEslabon1^2*Yc*CoordenadaXMotor3^2-8*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3*Xc+12*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3*Xc-8*Yc^3*CoordenadaXMotor3*Xc*CoordenadaYMotor3-4*CoordenadaXMotor3*Xc*CoordenadaYMotor3^2*LongitudEslabon1^2-6*Yc^2*CoordenadaYMotor3^2*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*CoordenadaXMotor3^2+4*Yc*CoordenadaYMotor3^3*Xc^2+2*Yc^4*CoordenadaXMotor3*Xc-Xc^6-CoordenadaXMotor3^6-Yc^4*CoordenadaXMotor3^2-Yc^4*Xc^2-CoordenadaYMotor3^4*CoordenadaXMotor3^2-CoordenadaYMotor3^4*Xc^2-2*Yc^2*CoordenadaXMotor3^4-2*Xc^4*Yc^2-2*CoordenadaXMotor3^4*CoordenadaYMotor3^2-2*Xc^4*CoordenadaYMotor3^2+6*CoordenadaXMotor3*Xc^5+6*CoordenadaXMotor3^5*Xc+20*CoordenadaXMotor3^3*Xc^3-15*CoordenadaXMotor3^2*Xc^4-15*CoordenadaXMotor3^4*Xc^2-Xc^2*LongitudEslabon2^4-Xc^2*LongitudEslabon1^4+2*Xc^4*LongitudEslabon2^2+2*Xc^4*LongitudEslabon1^2-CoordenadaXMotor3^2*LongitudEslabon2^4-CoordenadaXMotor3^2*LongitudEslabon1^4+2*CoordenadaXMotor3^4*LongitudEslabon2^2+2*CoordenadaXMotor3^4*LongitudEslabon1^2+4*Yc^3*CoordenadaXMotor3^2*CoordenadaYMotor3+4*Yc^3*Xc^2*CoordenadaYMotor3-12*CoordenadaXMotor3^2*Xc^2*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*CoordenadaYMotor3^4+8*CoordenadaXMotor3^3*Xc*CoordenadaYMotor3^2+8*CoordenadaXMotor3*Xc^3*CoordenadaYMotor3^2+2*CoordenadaXMotor3*Xc*LongitudEslabon2^4+2*CoordenadaXMotor3*Xc*LongitudEslabon1^4+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon2^2+12*CoordenadaXMotor3^2*Xc^2*LongitudEslabon1^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon2^2-8*CoordenadaXMotor3*Xc^3*LongitudEslabon1^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon2^2-8*CoordenadaXMotor3^3*Xc*LongitudEslabon1^2-4*CoordenadaXMotor3*Xc*LongitudEslabon2^2*LongitudEslabon1^2+2*Xc^2*LongitudEslabon2^2*LongitudEslabon1^2+2*CoordenadaXMotor3^2*LongitudEslabon2^2*LongitudEslabon1^2)^(1/2))];

R1 = isreal(Xd);
R2 = isreal(Yd);
R3 = isreal(Xdb);
R4 = isreal(Ydb);
R5 = isreal(Xdc);
R6 = isreal(Ydc);




if R1 & R2 & R3 & R4 & R5 & R6





if (CoordenadaXMotor1 > Xa)&(S1==1)                                           % solve the elbowup and elbowdown problem

elseif (CoordenadaXMotor1 < Xa)&(S1==1)
    S1=2;

elseif (CoordenadaXMotor1 > Xa)&(S1==2)

elseif (CoordenadaXMotor1 < Xa)&(S1==2)
    S1=1;

end

if (CoordenadaXMotor2 > Xb)&(S2==1)                                           % solve the elbowup and elbowdown problem

elseif (CoordenadaXMotor2<Xb)&(S2==1)
    S2 = 2;

elseif (CoordenadaXMotor2>Xb)&(S2==2)

elseif (CoordenadaXMotor2<Xb)&(S2==2)
    S2 = 1;

end

if (CoordenadaXMotor3>Xc)&(S3==1)

elseif (CoordenadaXMotor3<Xc)&(S3==1)
    S3=2;

elseif (CoordenadaXMotor3>Xc)&(S3==2)
    
elseif (CoordenadaXMotor3<Xc)&(S3==2)
    S3=1;

end
    L11 = plot([CoordenadaXMotor1 Xd(S1)],[CoordenadaYMotor1 Yd(S1)],'Linewidth',2,'Marker','O');
    text(CoordenadaXMotor1-1,CoordenadaYMotor1-1,'Base1','color','g');

    hold on
    L12 = plot([Xd(S1),Xa],[Yd(S1) Ya],'Linewidth',2,'Marker','O');

    hold on
    L21 = plot([CoordenadaXMotor2 Xdb(S2)],[CoordenadaYMotor2 Ydb(S2)],'Linewidth',2,'Marker','O');
    text(CoordenadaXMotor2-1,CoordenadaYMotor2-1,'Base2','color','r');

    hold on
    L22 = plot([Xdb(S2),Xb],[Ydb(S2) Yb],'Linewidth',2,'Marker','O');

    hold on
    L31 = plot([CoordenadaXMotor3 Xdc(S3)],[CoordenadaYMotor3 Ydc(S3)],'Linewidth',2,'Marker','O');
    text(CoordenadaXMotor3-1,CoordenadaYMotor3+1,'Base3','color',[0.9 0.7 0]);

    hold on 
    L32 = plot([Xdc(S3),Xc],[Ydc(S3) Yc],'Linewidth',2,'color','c','Marker','d');

    hold on

L41 = plot([Xa Xb],[Ya Yb],'color','r','Linewidth',3);
Horz= plot([Xa abs(Xb)+abs(LongitudLadoTriangulo*sin(Phi))],[Ya Ya],'color','b','LineStyle','--','color',[0 0.25 0.5]);
      text(Xa+0.7,Ya+0.5*sign(sin(Phi)),'\phi','color',[0.5 0.25 0])

hold on
L42 = plot([Xb Xc],[Yb Yc],'color','y','Linewidth',3);

hold on
L43 = plot([Xc Xa],[Yc Ya],'color','g','Linewidth',3);
Center = plot(CoordenadaXCentro ,CoordenadaYCentro ,'o','color',[0.5 0 0.25]);


if (isempty(X)==0) & (isempty(Y)==0)
   for i=1:1:k-1
       hold on
       plot(X(i),Y(i),'m','marker','*')
       end
end 


axis([-15 15 -15 15])
grid on
hold off

if Yd(S1)>=CoordenadaYMotor1
theta11 = acos((Xd(S1)-CoordenadaXMotor1)/LongitudEslabon1);
elseif Yd(S1)<CoordenadaYMotor1
    theta11 = 2*pi-acos((Xd(S1)-CoordenadaXMotor1)/LongitudEslabon1);
end

if Ya>=Yd(S1)
theta12 = acos((Xa-Xd(S1))/LongitudEslabon2);
elseif Ya<Yd(S1)
    theta12 = 2*pi-acos((Xa-Xd(S1))/LongitudEslabon2);
end

if Ydb(S2)>=CoordenadaYMotor2
theta21 = acos((Xdb(S2)-CoordenadaXMotor2)/LongitudEslabon1);
elseif Ydb(S2)<CoordenadaYMotor2
    theta21 = 2*pi-acos((Xdb(S2)-CoordenadaXMotor2)/LongitudEslabon1);
end

if Yb>=Ydb(S2)
theta22 = acos((Xb-Xdb(S2))/LongitudEslabon2);
elseif Yb<Ydb(S2)
    theta22 = 2*pi-acos((Xb-Xdb(S2))/LongitudEslabon2);
end

if Ydc(S3)>=CoordenadaYMotor3
theta31 = acos((Xdc(S3)-CoordenadaXMotor3)/LongitudEslabon1);
elseif Ydc(S3)<CoordenadaYMotor3
    theta31 = 2*pi-acos((Xdc(S3)-CoordenadaXMotor3)/LongitudEslabon1);
end

if Yc>=Ydc(S3)
theta32 = acos((Xc-Xdc(S3))/LongitudEslabon2);
elseif Yc<Ydc(S3)
    theta32 = 2*pi-acos((Xc-Xdc(S3))/LongitudEslabon2);
end



if (Xd(S1)>Xa) & (Yd(S1)<Ya)
    diaota1 = theta11-theta12;
elseif (Xd(S1)<Xa) & (Yd(S1)<Ya)
    diaota1 = theta11+theta12;
elseif (Xd(S1)<Xa) & (Yd(S1)>Ya)
    diaota1 = theta12-theta11;
elseif (Xd(S1)>Xa) & (Yd(S1)>Ya)
    diaota1 = pi-(theta11-theta12);
end



if (Xdb>Xb) & (Ydb<Yb)
    diaota2 = theta21-theta22;
elseif (Xdb<Xb) & (Ydb<Yb)
    diaota2 = theta21+theta22;
elseif (Xdb<Xb) & (Ydb>Yb)
    diaota2 = theta22-theta21;
elseif (Xdb>Xb) & (Ydb>Yb)
    diaota2 = pi-(theta21-theta22);
end

if (Xdc>Xc) & (Ydc<Yc)
    diaota3 = theta31-theta32;
elseif (Xdc<Xc) & (Ydc<Yc)
    diaota3 = theta31+theta32;
elseif (Xdc<Xc) & (Ydc>Yc)
    diaota3 = theta32-theta31;
elseif (Xdc>Xc) & (Ydc>Yc)
    diaota3 = pi-(theta31-theta32);
end

angledisplay(MostrarAngulo)
else 
    
    warning('You facd a singularity. Please change the variables to solve it.')
    Warnd = text(-10,10,'You facd a singularity. Please change the variables to solve it.','color','b');
    set(Warnd,'visible','on')
    clc
end
++++++++++++++++++++++++
pathtrack
++++++++++++++++++++
% This is a subfunction of rrrproject3.m
% Created by Gan Tao   taogan@eng.buffalo.edu
% Date: Jan.2004

function pathtrack(obj,eventdata)
global CC k
global X Y
global CoordenadaXCentro  CoordenadaYCentro 
global S1 S2 S3
global InVS

if CC==1 & InVS ==1

    cp=get(gca,'CurrentPoint');
    disp(cp);
    if (cp(1,1) > -15)&(cp(1,2) > -15)&(cp(1,1) < 15)&(cp(1,2) < 15)
     X(k)=cp(1,1);
     Y(k)=cp(1,2);
     plot(X(k),Y(k),'m','Marker','+')
     axis([-15 15 -15 15])
     hold on
     k = k+1;
    end

end
+++++++++++++++++++++++++
InversKincp
+++++++++++++++++++++++++
function InversKin(y)

global CoordenadaXCentro  CoordenadaYCentro 

if y==1
cp=ginput(1)

CoordenadaXCentro  = cp(1,1);
CoordenadaYCentro  = cp(1,2);

RRRdrawing(S1,S2,S3)
end
++++++++++++++++++++
emptycheck
++++++++++++++++++++
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
+++++++++++++++++++++
clickInverse
+++++++++++++++++++
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

++++++++++++++++++++++++++++
angledisplay
++++++++++++++++++++++++++++++
% This is a subfunction of rrrproject3.m
% Created by Gan Tao   taogan@eng.buffalo.edu
% Graduate Student of SUNY Buffalo
% Date: Jan.2004
% angledisplay.m is to display the absolutes angle of each link and the
% relative angles. But the relative one has not been finished yet. Sorry!

function []=angledisplay(MostrarAngulo)

global TextoMostrarAngulo txRD
global theta11 theta12 theta21 theta22 theta31 theta32 
global diaota1 diaota2 diaota3



if MostrarAngulo==2

TextoMostrarAngulo(1) = text(-10,-22,['\theta_{11}=',num2str(theta11*180/pi)]);
TextoMostrarAngulo(2) = text(  0,-22,['\theta_{12}=',num2str(theta12*180/pi)]);
TextoMostrarAngulo(3) = text(-10,-24,['\theta_{21}=',num2str(theta21*180/pi)]);
TextoMostrarAngulo(4) = text(  0,-24,['\theta_{22}=',num2str(theta22*180/pi)]);
TextoMostrarAngulo(5) = text(-10,-26,['\theta_{31}=',num2str(theta31*180/pi)]);
TextoMostrarAngulo(6) = text(  0,-26,['\theta_{32}=',num2str(theta32*180/pi)]);



elseif MostrarAngulo == 1


else
    warning('You faced a error. Try to reopen it again, or mail to taogan@eng.buffalo.edu')
    
end

++++++++++++++++++++++++++++++++



    
    
    
    

    
   
    
    


                                                                 