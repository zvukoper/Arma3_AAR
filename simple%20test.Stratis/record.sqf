aartimer = true;
player sidechat "Let's record!";
player sidechat "Trying to open pipes";
//_counted = count allUnits;
if(isNil("delphiData")) then {
	player sidechat "NO CLIENT PIPE!!";

			};
			
if(isNil("armaData")) then {
	player sidechat "NO AAR PIPE!!";

			};	
player sidechat "Sending RECORDING status";
[armaCom, "RECORDING"] call jayarma2lib_fnc_writePipe;
player sidechat "Starting while";
while{true} do
   {
player sidechat "Waiting for confirmation from client";
   if (recordMode) exitWith {player sidechat "Client confirmed record. Proceeding."; };
   };    
   
//assign a list of units
recUnits  = allUnits;
//recVeh  = vehicles;


{ //assign event handlers for all units
//[unit, causedBy, damage]
_x addEventHandler ["Hit", {[armaData, format['["hit", %1, %2]', _this select 0,_this select 1]] call jayarma2lib_fnc_writePipe; player sidechat "Hit recorded";}];

//[unit, weapon, muzzle, mode, ammo] 
_x addEventHandler ["Fired", {[armaData, format['["fired", %1, "%2", "%3", "%4", "%5"]', _this select 0,_this select 1,_this select 2,_this select 3,_this select 4]] call jayarma2lib_fnc_writePipe; player sidechat "Shot recorded";}];
} forEach recUnits;

   // CONFIRMED!!! CONTINUE!!!
player sidechat "ROGER received, proceeding";
//LAUNCH TIMER FOR SYNC
thisko = [] execVM "timer.sqf";   
			_tmr = ( random 1);
       sleep _tmr;
//player sidechat format["starting while (%1:%2)", Anim select 0, Anim select 1]; 
//  hint format["REC: Current: %1", vrema]; 
       while{true} do
   {   
   
   _write_array = ["data", vrema, vrema];
   _unit_array = [];
//_iko = 0;
	  {	//READ ANIMATIONS
	  //sleep fps;
	
	  //state is dead or not - 1 for dead, 0 for alive
	  _state = 0;
	  if(!alive _x) then {_state = 1;
	  _animate = "0";
	  _CPos = [0,0,0]; _CDir = 0; 
_unit_array = _unit_array + [[_x,_Cpos,_CDir,_animate,_state]];
	  } else {
	  //compare if changed trigger reload
	  //_ammos = _x ammo (primaryWeapon _x);
	  //if (_ammos == 1) then {[armaData, format['["reload", %1]',_x]] call jayarma2lib_fnc_writePipe;};
	  _state = damage _x;
	  _animate = animationState _x;
	  _CPos = getPosATL _x; _CDir = getDir _x; 
_unit_array = _unit_array + [[_x,_Cpos,_CDir,_animate,_state]];
};
	  // waitUntil{_ret};	
	  //_iko = _iko+1;
	  //if(_iko == _counted) then {[armaData, format["[0,%1]",vrema]] call jayarma2lib_fnc_writePipe;};
} forEach recUnits;
_write_array set [1, _unit_array];
[armaData, format["%1",_write_array]] call jayarma2lib_fnc_writePipe;
//hint format["REC: Current: %1", vrema];   
// CHECK IF ALLOWED
if (!recordMode) exitWith {player sidechat "Stop received. Reinitiating."; };
//STOP RECEIVED!!! BREAK!
sleep fps;
   };
   