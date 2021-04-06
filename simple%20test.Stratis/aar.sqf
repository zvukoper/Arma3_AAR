/*main script*/
hintSilent "LOADING AFTER ACTION REVIEW...";
	/* OPEN PIPES */
	_delphiPipe = ["\\.\pipe\delphiPipe"] call jayarma2lib_fnc_openPipe;
	_armaPipe = ["\\.\pipe\armaPipe"] call jayarma2lib_fnc_openPipe;
	/* IF OPENED */
hintSilent "CONNECTING TO AFTER ACTION REVIEW SERVER...";
sleep 2;
	if((!isNil("_delphiPipe")) && (!isNil("_armaPipe"))) then {
hintSilent "SERVER AVAILABLE. SYNCING.";		
		/* SEND ARMA2 READY */
		[_armaPipe, "ARMA2 READY"] call jayarma2lib_fnc_writePipe;
		/* SENT */
		
			/* IF AAR SAYS AAR READY START MAIN LOOP */
			while {true} do {
			_received = [_delphiPipe] call jayarma2lib_fnc_readPipe;
			if (_received == "AAR READY") exitWith {aarReady = true; hintSilent "CONNECTED. AAR READY.";};
			}
			/* END IF */
				while (aarReady) do {
				/*main loop*/
						
					/* READ AAR COMMAND */
					while {true} do {
					_received = [_delphiPipe] call jayarma2lib_fnc_readPipe;
					if (_received == "PLAYBACK MODE") exitWith {playbackMode = true; recordMode = false; hintSilent "REPLAY";};
					if (_received == "RECORD MODE") exitWith {recordMode = true; playbackMode = false; hintSilent "RECORDING";};

					/* CHECKING CONNECTION */
					if((!isNil("_delphiPipe")) && (!isNil("_armaPipe"))) then {recordMode = false; playbackMode = false; offlineMode = true; aarReady = false; hintSilent "CONNECTION LOST";};
					};
					/* CHECKING CONNECTION */
					
					
						/* IF PLAYBACK */
						if (playbackMode) then {
						_timer = [] execVM "timer.sqf";
							while {playbackMode} do {
								/* STOPPING */
								if (!(playbackMode)) exitWith {[_armaPipe, "PLAYBACK END"] call jayarma2lib_fnc_writePipe; hintSilent "REPLAY STOPPED";};
								/* STOPPING */
									/* CHECKING CONNECTION */
									if((!isNil("_delphiPipe")) && (!isNil("_armaPipe"))) then {recordMode = false; playbackMode = false; offlineMode = true; aarReady = false; hintSilent "CONNECTION LOST";};
									};/* CHECKING CONNECTION */									
										/* ==========THE PLAYBACK========= */
										while {true} do {
											_ddata = [_delphiPipe] call jayarma2lib_fnc_readPipe;
											if(!isNil("_ddata")) then {
											/* STOP RECEIVED*/
											if (_ddata == "STOP") exitWith {playbackMode = false; hintSilent "STOP";};
											/* STOP RECEIVED*/
												_xdata = call compile format["%1",_ddata];
												hint format["Replay time %1. Current time: %2", _xdata select 0, vrema];
												waitUntil {vrema >= _xdata select 0};
												_anim = format["%1", _xdata select 4];
												_curanim = animationState (_xdata select 1);
												if (_anim != _curanim ) then {(_xdata select 1) playMoveNow _anim;};
												(_xdata select 1) setPos [(_xdata select 2) select 0,(_xdata select 2) select 1,(_xdata select 2) select 2]; 
												(_xdata select 1) setDir (_xdata select 3);   
											};
};
										/* ==========THE PLAYBACK========= */
						};/* END PLAYBACK */

						/* IF RECORD */
						if (recordMode) then {
						_timer = [] execVM "timer.sqf";
							/* STOPPING */
								
							if (!(recordMode)) exitWith {[_armaPipe, "RECORD END"] call jayarma2lib_fnc_writePipe; hintSilent "RECORDING STOPPED";};
							/* STOPPING */
								/* CHECKING CONNECTION */
								if((!isNil("_delphiPipe")) && (!isNil("_armaPipe"))) then {recordMode = false; playbackMode = false; offlineMode = true; aarReady = false; hintSilent "CONNECTION LOST";};
								/* CHECKING CONNECTION */
									/* ==========THE RECORD========= */
									while{true} do
									   {   
											{
										  _animate = animationState _x;
										  _CPos = getpos _x; _CDir = getDir _x; CurLine = [_Cpos, _CDir]; fullLine = fullLine + [CurLine];[_armaPipe, format["[%1,%2,%3,%4,'%5']",vrema,_x,CurLine select 0, CurLine select 1,_animate]] call jayarma2lib_fnc_writePipe;
										  Anim = [_x, "0"];
										  } forEach allUnits;
									hint format["Current: %1", vrema];
											/* STOP RECEIVED*/
											_ddata = [_delphiPipe] call jayarma2lib_fnc_readPipe;
											if (_ddata == "STOP") exitWith {recordMode = false; hintSilent "STOP";};
											/* STOP RECEIVED*/
									sleep fps;
									   };
									/* ==========THE RECORD========= */
						};/* END RECORD */
						
						/* IF OFFLINE */
						if (offlineMode) exitWith {[_armaPipe, "GOING OFFLINE"] call jayarma2lib_fnc_writePipe; hintSilent "AAR OFFLINE"; aarReady = false;
							/* close pipes */
							[_armaPipe] call jayarma2lib_fnc_closePipe;
							[_delphiPipe] call jayarma2lib_fnc_closePipe;
							/* close pipes */
							};/* OFFLINE END */
							 
				hintSilent "INITIAL STATE. WAITING FOR COMMANDS.";
				/*main loop*/
				};
	} else { hintSilent "Connection missing. Make sure AAR server started and try again.";};