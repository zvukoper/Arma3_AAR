player sidechat "AARCOM initiating";
player sidechat format["Recording fps rate is", fps];

aar_ops = [recorder, RU_soldier_5];
isOp = (player in aar_ops);
if (isOp) then {player addAction ["Stop", "close.sqf"];
	player addAction ["Play", "reading.sqf"];
player addAction ["Record", "record.sqf"];};

if(isNil("delphiData")) then {
	
	player sidechat "Reopening pipes.";
	
	delphiCom = ["\\.\pipe\delphiCom"] call jayarma2lib_fnc_openPipe;
	armaCom = ["\\.\pipe\armaCom"] call jayarma2lib_fnc_openPipe;
	delphiData = ["\\.\pipe\delphiData"] call jayarma2lib_fnc_openPipe;
	armaData = ["\\.\pipe\armaData"] call jayarma2lib_fnc_openPipe;
	
	
	} else {
	player sidechat "Pipes present. Proceeding.";
};
player sidechat "Pipes initiated";

while {true} do {
	
	//hintSilent "AARCOM is awaiting commands";
	
	_ddata = [delphiCom] call jayarma2lib_fnc_readPipe;
	if(!isNil("_ddata")) then {
		player sidechat format["delphiCom: %1",_ddata];
		if(!aartimer) then {[armaCom, "STOP"] call jayarma2lib_fnc_writePipe; aartimer = false; sleep 1; recordMode = false; playbackMode = false; aarReady = true; [armaCom, "STOP"] call jayarma2lib_fnc_writePipe; };
		if(_ddata == "ROGER_RECORDING") then {player sidechat "RECORDING CONFIRMED!" ; recordMode = true; playbackMode = false;};
		if(_ddata == "ROGER_PLAYBACK") then {recordMode = false; playbackMode = true;};
		if(_ddata == "ROGER_READY") then {aarReady = true;};
		sleep 3;
	};
};