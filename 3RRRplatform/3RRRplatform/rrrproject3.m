% This Project is to simulate the 3RRR robot
% Created by Gan Tao          taogan@eng.buffalo.edu
% Graduate Student of SUNY Buffalo
% Date: Jan.2004
% rrrproject3.m is the main programme.
% Contain the subfunctions : angledisply.m 
%                            varmakeup.m 
%                            emptycheck.m
%                            RRRdrawing.m
%                            clickInverse.m
%                            pathtrack.m
%                            startpathtrack.m
%                            stoppathtrack.m
%                            nothingfcn.m
%                            RRRproject3.fig


function varargout = RRRproject3(varargin)

global fig
global CC k
global InVS
% global Rec_Movie
%un cambio
% global Rec_Movie
% RRRPROJECT3 Application M-file for RRRproject3.fig
%    FIG = RRRPROJECT3 launch RRRproject3 GUI.
%    RRRPROJECT3('callback_name', ...) invoke the named callback.

% Last Modified by GUIDE v2.5 02-Apr-2015 21:41:38

% global frameAD
CC = 0;
k  = 1;
InVS= 0;
% Rec_Movie = 0;



if nargin == 0  % LAUNCH GUI
     
%     fig = figure(1)
	fig = openfig(mfilename,'reuse');
    set(fig,'WindowButtonDownFcn',@startpathtrack);
%     set(fig,'WindowButtonMotionFcn',@pathtrack);
    set(fig,'WindowButtonUpFcn',@stoppathtrack);
	% Generate a structure of handles to pass to callbacks, and store it. 
	handles = guihandles(fig);
    handles.number_errors = 0;
	guidata(fig, handles);

	if nargout > 0
		varargout{1} = fig;
	end

elseif ischar(varargin{1}) % INVOKE NAMED SUBFUNCTION OR CALLBACK

	try
		if (nargout)
			[varargout{1:nargout}] = feval(varargin{:}); % FEVAL switchyard
		else
			feval(varargin{:}); % FEVAL switchyard
		end
	catch
		disp(lasterr);
	end

end
% frameAD =uicontrol(fig,'Style','frame','Units','characters', ...
%    	'Position',[9.8 0.9 91.8 7.54],'visible','off');
% frameAD =uicontrol(fig,'Style','frame','Units','characters', ...
%                    'visible','off');

%| ABOUT CALLBACKS:
%| GUIDE automatically appends subfunction prototypes to this file, and 
%| sets objects' callback properties to call them through the FEVAL 
%| switchyard above. This comment describes that mechanism.
%|
%| Each callback subfunction declaration has the following form:
%| <SUBFUNCTION_NAME>(H, EVENTDATA, HANDLES, VARARGIN)
%|
%| The subfunction name is composed using the object's Tag and the 
%| callback type separated by '_', e.g. 'slider2_Callback',
%| 'figure1_CloseRequestFcn', 'axis1_ButtondownFcn'.
%|
%| h is the callback object's handle (obtained using GCBO).
%|
%| EVENTDATA is empty, but reserved for future use.
%|
%| HANDLES is a structure containing handles of components in GUI using
%| tags as fieldnames, e.g. handles.figure1, handles.slider2. This
%| structure is created at GUI startup using GUIHANDLES and stored in
%| the figure's application data using GUIDATA. A copy of the structure
%| is passed to each callback.  You can store additional information in
%| this structure at GUI startup, and you can change the structure
%| during callbacks.  Call guidata(h, handles) after changing your
%| copy to replace the stored original so that subsequent callbacks see
%| the updates. Type "help guihandles" and "help guidata" for more
%| information.
%|
%| VARARGIN contains any extra arguments you have passed to the
%| callback. Specify the extra arguments by editing the callback
%| property in the inspector. By default, GUIDE sets the property to:
%| <MFILENAME>('<SUBFUNCTION_NAME>', gcbo, [], guidata(gcbo))
%| Add any extra arguments after the last argument, before the final
%| closing parenthesis.



% --------------------------------------------------------------------
function varargout = sliderbase1x_Callback(h, eventdata, handles, varargin)

global  CoordenadaXMotor1 CoordenadaYMotor1
global S1 S2 S3
global CoordenadaYMotor2 CoordenadaYMotor3 CoordenadaXMotor2 CoordenadaXMotor3
global CoordenadaXCentro CoordenadaYCentro Phi
global LongitudLadoTriangulo LongitudEslabon1 LongitudEslabon2

set(handles.editbase1x,'String',num2str(get(handles.sliderbase1x,'Value')));
CoordenadaXMotor1 = get(handles.sliderbase1x,'Value');


if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
else
    RRRdrawing(S1,S2,S3)
end

% --------------------------------------------------------------------
function varargout = sliderbase1y_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)

global  CoordenadaXMotor1 CoordenadaYMotor1 k12     % coordinates of each point of the limb1
global  S1 S2 S3
global  MostrarAngulo

set(handles.editbase1y,'String',num2str(get(handles.sliderbase1y,'Value')));
CoordenadaYMotor1 = get(handles.sliderbase1y,'Value');


if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
else
    RRRdrawing(S1,S2,S3)
end



% --------------------------------------------------------------------
function varargout = sliderbase2x_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)
global  CoordenadaXMotor2 CoordenadaYMotor2 k21
global  S1 S2 S3
set(handles.editbase2x,'String',num2str(get(handles.sliderbase2x,'Value')));
CoordenadaXMotor2 = get(handles.sliderbase2x,'Value');

if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
else
    RRRdrawing(S1,S2,S3)
end


% --------------------------------------------------------------------
function varargout = slider4_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)
global  CoordenadaXMotor2 CoordenadaYMotor2 k22
global  S1 S2 S3
set(handles.editbase2y,'String',num2str(get(handles.sliderbase2y,'Value')));
CoordenadaYMotor2 = get(handles.sliderbase2y,'Value');

if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
else
    RRRdrawing(S1,S2,S3)
end
k22 =1;
% --------------------------------------------------------------------
function varargout = slider5_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)
global  CoordenadaXMotor3 CoordenadaYMotor3 k31
global  S1 S2 S3
set(handles.editbase3x,'String',num2str(get(handles.sliderbase3x,'Value')));
CoordenadaXMotor3 = get(handles.sliderbase3x,'Value');

if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
else
    RRRdrawing(S1,S2,S3)
end
k31 = 1;
% --------------------------------------------------------------------
function varargout = slider6_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)
global  CoordenadaXMotor3 CoordenadaYMotor3 k32
global  S1 S2 S3
set(handles.editbase3y,'String',num2str(get(handles.sliderbase3y,'Value')));
CoordenadaYMotor3 = get(handles.sliderbase3y,'Value');

if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
else
    RRRdrawing(S1,S2,S3)
end

k32 = 1;

% --------------------------------------------------------------------
function varargout = editbase1x_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)
global  CoordenadaXMotor1 CoordenadaYMotor1 Xa Ya Xd Yd k11                                             % coordinates of each point of the limb1
global  S1 S2 S3
k11 = 1;
val = str2double(get(handles.editbase1x,'String'));

if isnumeric(val) & length(val)==1 & val >= get(handles.sliderbase1x,'Min') & val <= get(handles.sliderbase1x,'Max')
    
    set(handles.sliderbase1x,'Value',val);
    CoordenadaXMotor1 = val;
    
    if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
    else
      RRRdrawing(S1,S2,S3)
    end

else
    Warnd = text(-10,10,'\fontsize{16} The input is out of range. Try again!','color','r');
    set(Warnd,'visible','on') 

end



% --------------------------------------------------------------------
function varargout = editbase1y_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)
global  CoordenadaXMotor1 CoordenadaYMotor1 Xa Ya Xd Yd k12                                             % coordinates of each point of the limb1
global  S1 S2 S3
k12 = 1;
val = str2double(get(handles.editbase1y,'String'));

if isnumeric(val) & length(val)==1 & val >= get(handles.sliderbase1y,'Min') & val <= get(handles.sliderbase1y,'Max')
    
    set(handles.sliderbase1y,'Value',val);
    CoordenadaYMotor1 = val;
    if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
      else
      RRRdrawing(S1,S2,S3)
     end
else
    
    Warnd = text(-10,10,'\fontsize{16} The input is out of range. Try again!','color','r');
    set(Warnd,'visible','on') 
   
end


% --------------------------------------------------------------------
function varargout = edit3_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)

global  CoordenadaXMotor2 CoordenadaYMotor2 k21
global  S1 S2 S3
k21 = 1;

val = str2double(get(handles.editbase2x,'String'));

if isnumeric(val) & length(val)==1 & val >= get(handles.sliderbase2x,'Min') & val <= get(handles.sliderbase2x,'Max')
    
    set(handles.sliderbase2x,'Value',val);
    CoordenadaXMotor2 = val;
    if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
     else
      RRRdrawing(S1,S2,S3)
     end
else
    
    Warnd = text(-10,10,'\fontsize{16} The input is out of range. Try again!','color','r');
    set(Warnd,'visible','on') 
   
end


% --------------------------------------------------------------------
function varargout = edit4_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)

global  CoordenadaXMotor2 CoordenadaYMotor2 k22
global  S1 S2 S3
k22 = 1;

val = str2double(get(handles.editbase2y,'String'));

if isnumeric(val) & length(val)==1 & val >= get(handles.sliderbase2y,'Min') & val <= get(handles.sliderbase2y,'Max')
    
    set(handles.sliderbase2y,'Value',val);
    CoordenadaYMotor2 = val;
    if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
      else
      RRRdrawing(S1,S2,S3)
    end
else
    
    Warnd = text(-10,10,'\fontsize{16} The input is out of range. Try again!','color','r');
    set(Warnd,'visible','on') 
   
end


% --------------------------------------------------------------------
function varargout = edit5_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)

global  CoordenadaXMotor3 CoordenadaYMotor3 k31
global  S1 S2 S3
k31 = 1;

val = str2double(get(handles.editbase3x,'String'));

if isnumeric(val) & length(val)==1 & val >= get(handles.sliderbase3x,'Min') & val <= get(handles.sliderbase3x,'Max')
    
    set(handles.sliderbase3x,'Value',val);
    CoordenadaXMotor3 = val;
    if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
       else
       RRRdrawing(S1,S2,S3)
       end
else
    
    Warnd = text(-10,10,'\fontsize{16} The input is out of range. Try again!','color','r');
    set(Warnd,'visible','on') 
   
end


% --------------------------------------------------------------------
function varargout = edit6_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)

global  CoordenadaXMotor3 CoordenadaYMotor3 k32
global  S1 S2 S3
k32 = 1;

val = str2double(get(handles.editbase3y,'String'));

if isnumeric(val) & length(val)==1 & val >= get(handles.sliderbase3y,'Min') & val <= get(handles.sliderbase3y,'Max')
    
    set(handles.sliderbase3y,'Value',val);
    CoordenadaYMotor3 = val;
    if emptycheck
    varmakeup;
    RRRdrawing(S1,S2,S3)
    else
      RRRdrawing(S1,S2,S3)
      end
else
    
    Warnd = text(-10,10,'\fontsize{16} The input is out of range. Try again!','color','r');
    set(Warnd,'visible','on') 
   
end



% --------------------------------------------------------------------
function varargout = initialposition_pushbution_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)
global InVS

InVS = 0;

on = [handles.sliderbase1x,handles.sliderbase1y,handles.sliderbase2x,handles.sliderbase2y,...
        handles.sliderbase3x,handles.sliderbase3y,handles.editbase1x,handles.editbase1y,...
        handles.editbase2x,handles.editbase2y,handles.editbase3x,handles.editbase3y,...
        handles.textbase1x,handles.textbase1y,handles.textbase2x,handles.textbase2y,...
        handles.textbase3x,handles.textbase3y,handles.range,handles.pushbuttoninitialized];

visibleon(on);
        
    



off = [handles.framesolutionleg1,handles.radiobuttonsolution1forleg1,handles.radiobuttonsolution2forleg1,handles.textsetsolutionforleg1,...
       handles.framesolutionleg2,handles.radiobuttonsolution1forleg2,handles.radiobuttonsolution2forleg2,...
       handles.textsetsolutionforleg2,handles.framesolutionleg3,handles.radiobuttonsolution1forleg3,...
       handles.radiobuttonsolution2forleg3,handles.textsetsolutionforleg3,handles.togglebuttonclickinverse,handles.popupmenu_record];

visibleoff(off);



% --------------------------------------------------------------------
function varargout = InverseKinematics_pushbutton_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)
global Phi S1 S2 S3
global CoordenadaXCentro CoordenadaYCentro
global MostrarAngulo
global InVS

if emptycheck;
    
    text(0.3,0.5,'You should finish initialization first!','fontsize',15);
else

InVS = 1;
on = [handles.framesolutionleg1,handles.radiobuttonsolution1forleg1,handles.radiobuttonsolution2forleg1,handles.textsetsolutionforleg1,...
       handles.framesolutionleg2,handles.radiobuttonsolution1forleg2,handles.radiobuttonsolution2forleg2,...
       handles.textsetsolutionforleg2,handles.framesolutionleg3,handles.radiobuttonsolution1forleg3,...
       handles.radiobuttonsolution2forleg3,handles.textsetsolutionforleg3,handles.togglebuttonclickinverse,handles.popupmenu_record];

visibleon(on);




off = [handles.sliderbase1x,handles.sliderbase1y,handles.sliderbase2x,handles.sliderbase2y,...
        handles.sliderbase3x,handles.sliderbase3y,handles.editbase1x,handles.editbase1y,...
        handles.editbase2x,handles.editbase2y,handles.editbase3x,handles.editbase3y,...
        handles.textbase1x,handles.textbase1y,handles.textbase2x,handles.textbase2y,...
        handles.textbase3x,handles.textbase3y,handles.range,handles.pushbuttoninitialized];

visibleoff(off);

end




% --------------------------------------------------------------------
function varargout = radiobuttonsolution1forleg1_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)

global  Phi S1 S2 S3
global  CoordenadaXMotor1 CoordenadaYMotor1 Xa Ya Xd Yd 
global  CoordenadaXCentro CoordenadaYCentro

off = [handles.radiobuttonsolution2forleg1];
mutual_exclude(off)
set(handles.radiobuttonsolution1forleg1,'Value',1);
S1 = get(handles.radiobuttonsolution1forleg1,'Value');

RRRdrawing(S1,S2,S3);

% --------------------------------------------------------------------
function varargout = radiobuttonsolution2forleg1_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)

global Phi S1 S2 S3
global  CoordenadaXMotor1 CoordenadaYMotor1 Xa Ya Xd Yd 
global  CoordenadaXCentro CoordenadaYCentro


off = [handles.radiobuttonsolution1forleg1];
mutual_exclude(off)
set(handles.radiobuttonsolution2forleg1,'Value',1);
s1 = get(handles.radiobuttonsolution2forleg1,'Value');
S1 = s1+1;


RRRdrawing(S1,S2,S3);

% --------------------------------------------------------------------
function varargout = radiobuttonsolution1forleg2_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)

global Phi S1 S2 S3
off = [handles.radiobuttonsolution2forleg2];
mutual_exclude(off)
set(handles.radiobuttonsolution1forleg2,'Value',1);
S2 = get(handles.radiobuttonsolution1forleg2,'Value');

RRRdrawing(S1,S2,S3)

% --------------------------------------------------------------------
function varargout = radiobuttonsolution2forleg2_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)

global Phi S1 S2 S3
off = [handles.radiobuttonsolution1forleg2];
mutual_exclude(off)
set(handles.radiobuttonsolution2forleg2,'Value',1);
s2 = get(handles.radiobuttonsolution2forleg2,'Value');
S2 = s2+1;

RRRdrawing(S1,S2,S3)

% --------------------------------------------------------------------
function varargout = radiobuttonsolution1forleg3_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)

global Phi S1 S2 S3

off = [handles.radiobuttonsolution2forleg3];
mutual_exclude(off)
set(handles.radiobuttonsolution1forleg3,'Value',1);
S3 = get(handles.radiobuttonsolution1forleg3,'Value');

RRRdrawing(S1,S2,S3)

% --------------------------------------------------------------------
function varargout = radiobuttonsolution2forleg3_Callback(LongitudLadoTriangulo, eventdata, handles, varargin)
global Phi S1 S2 S3

off = [handles.radiobuttonsolution1forleg3];
mutual_exclude(off)
set(handles.radiobuttonsolution2forleg3,'Value',1);
s3 = get(handles.radiobuttonsolution2forleg3,'Value');
S3 = s3+1;

RRRdrawing(S1,S2,S3)
% --------------------------------------------------------------------
function mutual_exclude(off)

set(off,'Value',0);

% --------------------------------------------------------------------
function visibleoff(off)

set(off,'Visible','off');

% --------------------------------------------------------------------
function visibleon(on)

set(on,'Visible','on');


% --- Executes during object creation, after setting all properties.
function sliderYg_CreateFcn(hObject, eventdata, handles)
% hObject    handle to sliderYg (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: slider controls usually have a light gray background, change
%       'usewhitebg' to 0 to use default.  See ISPC and COMPUTER.
usewhitebg = 1;
if usewhitebg
    set(hObject,'BackgroundColor',[.9 .9 .9]);
else
    set(hObject,'BackgroundColor',get(0,'defaultUicontrolBackgroundColor'));
end


% --- Executes on slider movement.
function sliderYg_Callback(hObject, eventdata, handles)
% hObject    handle to sliderYg (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'Value') returns position of slider
%        get(hObject,'Min') and get(hObject,'Max') to determine range of slider

global CoordenadaYCentro S1 S2 S3
global theta11 theta12 theta21 theta22 theta31 theta32
global TextoMostrarAngulo txRD


set(handles.editYg,'String',num2str(get(handles.sliderYg,'Value')));

CoordenadaYCentro = get(handles.sliderYg,'Value');


RRRdrawing(S1,S2,S3);

set(handles.editYg,'Value', CoordenadaYCentro);


% --- Executes during object creation, after setting all properties.
function editXg_CreateFcn(hObject, eventdata, handles)
% hObject    handle to editXg (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc
    set(hObject,'BackgroundColor','white');
else
    set(hObject,'BackgroundColor',get(0,'defaultUicontrolBackgroundColor'));
end





% --- Executes during object creation, after setting all properties.
function editYg_CreateFcn(hObject, eventdata, handles)
% hObject    handle to editYg (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc
    set(hObject,'BackgroundColor','white');
else
    set(hObject,'BackgroundColor',get(0,'defaultUicontrolBackgroundColor'));
end



function editYg_Callback(hObject, eventdata, handles)
% hObject    handle to editYg (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of editYg as text
%        str2double(get(hObject,'String')) returns contents of editYg as a double
global CoordenadaYCentro S1 S2 S3

val = str2double(get(handles.editYg,'String'));

if isnumeric(val) & length(val)==1 & val >= get(handles.sliderYg,'Min') & val <= get(handles.sliderYg,'Max')
    
    set(handles.sliderYg,'Value',val);
    CoordenadaYCentro = val;
    
%     set(handles.textangle12,'Visible','on','String',num2str(val));
    RRRdrawing(S1,S2,S3);
    
else
    
    Warnd = text(-10,10,'\fontsize{16} The input is out of range. Try again!','color','r');
    set(Warnd,'visible','on') 
   
end

% 
% --- Executes during object creation, after setting all properties.
function popupmenuangleselect_CreateFcn(hObject, eventdata, handles)
% hObject    handle to popupmenuangleselect (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: popupmenu controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc
    set(hObject,'BackgroundColor','white');
else
    set(hObject,'BackgroundColor',get(0,'defaultUicontrolBackgroundColor'));
end





% --- Executes during object creation, after setting all properties.
function popupmenuangledisplay_CreateFcn(hObject, eventdata, handles)
% hObject    handle to popupmenuangledisplay (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: popupmenu controls usually have a white background on Windows.
%       See ISPC and COMPUTER.

if ispc
    set(hObject,'BackgroundColor','white');
else
    set(hObject,'BackgroundColor',get(0,'defaultUicontrolBackgroundColor'));
end


% --- Executes on selection change in popupmenuangledisplay.
function popupmenuangledisplay_Callback(hObject, eventdata, handles)
% hObject    handle to popupmenuangledisplay (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: contents = get(hObject,'String') returns popupmenuangledisplay contents as cell array
%        contents{get(hObject,'Value')} returns selected item from popupmenuangledisplay
global S1 S2 S3
global theta11 theta12 theta21 theta22 theta31 theta32
global diaota1 diaota2 diaota3
global TextoMostrarAngulo txRD MostrarAngulo
% global frameAD
val = get(hObject,'Value');
% [x,y]=get(hObject,'Currentpoint')
switch val
case 1
% The user selected the first item
    if MostrarAngulo==2
    MostrarAngulo = 1;

    set(TextoMostrarAngulo,'Visible','off')

    elseif MostrarAngulo==1
        MostrarAngulo=1;
    end
case 2
    if MostrarAngulo==1
    MostrarAngulo = 2;
    set(TextoMostrarAngulo,'Visible','on')
    elseif MostrarAngulo==2
        MostrarAngulo=2;
    end

    angledisplay(MostrarAngulo)


end


% --- Executes on button press in pushbuttoninitialized.
function pushbuttoninitialized_Callback(hObject, eventdata, handles)
% hObject    handle to pushbuttoninitialized (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global LongitudLadoTriangulo LongitudEslabon1 LongitudEslabon2 
global CoordenadaYMotor1 CoordenadaXMotor1 CoordenadaYMotor2 CoordenadaXMotor2 CoordenadaYMotor3 CoordenadaXMotor3
global CoordenadaXCentro CoordenadaYCentro Phi
global S1 S2 S3
LongitudLadoTriangulo=[];
LongitudEslabon1=[];
LongitudEslabon2=[];
CoordenadaYMotor1=[];
CoordenadaXMotor1=[];
CoordenadaYMotor2=[];
CoordenadaXMotor2=[];
CoordenadaYMotor3=[];
CoordenadaXMotor3=[];
CoordenadaXCentro =[];
CoordenadaYCentro =[];
Phi=[];
S1 =[];
S2 =[];
S3 =[];
varmakeup;
RRRdrawing(S1,S2,S3)
hold on
text(-14,13,'This Software is Created for the 3-RRR Robot.',     'FontSize',8,'color','b');
text(-14,-11,'\phi=pi/4',                   'FontSize',8,'color','r');
text(-14,-13,'Coordinate for Base1,2,3 =[-1.5 -8.4] [6.9 -1.2] [-6.6 2.1]','FontSize',8,'color','r');
hold off



% --- Executes on button press in togglebuttonclickinverse.
function togglebuttonclickinverse_Callback(hObject, eventdata, handles)
% hObject    handle to togglebuttonclickinverse (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of togglebuttonclickinverse
global CInverCK
global InVS

InVS = 1;

CInverCK = get(hObject,'Value');

if CInverCK == 1
set(handles.togglebuttonclickinverse,'String','Point');
elseif CInverCK == 0
    set(handles.togglebuttonclickinverse,'String','Path');
end

    


% --- Executes during object creation, after setting all properties.
function popupmenu_record_CreateFcn(hObject, eventdata, handles)
% hObject    handle to popupmenu_record (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: popupmenu controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc
    set(hObject,'BackgroundColor','white');
else
    set(hObject,'BackgroundColor',get(0,'defaultUicontrolBackgroundColor'));
end


% --- Executes on selection change in popupmenu_record.
function popupmenu_record_Callback(hObject, eventdata, handles)
% hObject    handle to popupmenu_record (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: contents = get(hObject,'String') returns popupmenu_record contents as cell array
%        contents{get(hObject,'Value')} returns selected item from popupmenu_record
global Rec_Movie

val = get(hObject,'Value');
switch val
case 1
   Rec_Movie = 0;
case 2

   Rec_Movie = 1;
end












