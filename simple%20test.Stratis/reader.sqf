player sidechat "Let's read!";
_delphiPipe = ["\\.\pipe\delphiPipe"] call jayarma2lib_fnc_openPipe;
_armaPipe = ["\\.\pipe\armaPipe"] call jayarma2lib_fnc_openPipe;
player sidechat "Trying to open pipes";
if(isNil("_armaPipe")) exitWith {
		player sidechat "NO AAR PIPE!!";
		   [_delphiPipe] call jayarma2lib_fnc_closePipe;
   [_armaPipe] call jayarma2lib_fnc_closePipe;
			};
			
if(isNil("_delphiPipe")) exitWith {
		player sidechat "NO CLIENT PIPE!!";
		   [_delphiPipe] call jayarma2lib_fnc_closePipe;
   [_armaPipe] call jayarma2lib_fnc_closePipe;
			};			
			
[_armaPipe, "PLAY"] call jayarma2lib_fnc_writePipe;
player sidechat "wrote play";
sleep 2;	
player sidechat "while start";	
hint format["1%", vrema];	
while {true} do {
   player sidechat "receiving";
     		 hint format["1%", vrema];

      };
   
   player sidechat "closing pipe";

   player sidechat "done";
   hint "END";
      [_armaPipe] call jayarma2lib_fnc_closePipe;
	     [_delphiPipe] call jayarma2lib_fnc_closePipe;
		

