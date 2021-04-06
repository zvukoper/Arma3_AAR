player sidechat "Go pipes play!";
_delphiPipe= ["\\.\pipe\delphiPipe"] call jayarma2lib_fnc_openPipe;
_armaPipe = ["\\.\pipe\armaPipe"] call jayarma2lib_fnc_openPipe;
player sidechat "opened pipe";
if(isNil("_ReadFromAar")) then {
		player sidechat "NO PIPE!!";
			};
			
[_pipeHandle, "PLAY"] call jayarma2lib_fnc_writePipe;
player sidechat "wrote play";
sleep 2;	
player sidechat "while start";		
While {true} do {
   player sidechat "receive";
   _received = [_ReadFromAar] call jayarma2lib_fnc_readPipe;
   player sidechat "checky";
   if(!isNil("_received")) then // if not empty
      {
	  player sidechat "not empty";
            if(_received = "STOP") OR (_received = "PLAYBACK END") exitWith // on AAR stop command
            {
			player sidechat "ended";
               hint "THE END";   
            }
			player sidechat "compile";
         _data = compile _received; //make array of string
		 player sidechat "moving";
         if(_data select 6 = "move")
         {
		 player sidechat "waitinfor its hour";
            waitUntil {stime >= _data select 0};
			player sidechat "setpos";
               (_data select 1) setPos [_data select 2];
			   player sidechat "setDir";
               (_data select 1) setDir (_data select 3);
			   player sidechat "total hint";
               hint format["1% - 2% setPos 3%, setDir 4%",_data select 0,_data select 1,_data select 2, _data select 3];
         };
		 player sidechat "write read";
         _ret = [_armaPipe, "READ"] call jayarma2lib_fnc_readPipe; // tell AAR that we've read and wait for next
      };
   }
   player sidechat "closing pipe";
   [_ReadFromAar] call jayarma2lib_fnc_closePipe;
   [_armaPipe] call jayarma2lib_fnc_closePipe;
   player sidechat "done";
   hint "END";
		

