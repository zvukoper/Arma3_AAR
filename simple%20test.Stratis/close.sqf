if(recordMode) then {[armaData, "EOF"] call jayarma2lib_fnc_writePipe; [armaCom, "STOP"] call jayarma2lib_fnc_writePipe;};
[armaCom, "STOP"] call jayarma2lib_fnc_writePipe;
player sidechat "Stopping!";
aartimer = false;
playbackMode = false;
recordMode = false;
offlineMode = false;
aarReady = true;

  // disableUserInput false;

{_x enableAI "AUTOTARGET";
_x enableAI "MOVE";
_x enableAI "TARGET";
_x enableAI "AUTOTARGET";
_x allowDamage true;
} forEach allUnits;