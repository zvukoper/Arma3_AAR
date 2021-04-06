//disableUserInput true;

{_x disableAI "AUTOTARGET";
_x disableAI "MOVE";
_x disableAI "TARGET";
_x disableAI "AUTOTARGET";
_x disableAI "ANIM";
_x allowDamage false;
_x setDamage 0;
} forEach allUnits;


aartimer = true;
player sidechat "Let's try PLAYBACKING!";
player sidechat "Trying to open pipes";
if(isNil("delphiData")) then {
	player sidechat "NO CLIENT PIPE!!";

			};
			
if(isNil("armaData")) then {
	player sidechat "NO AAR PIPE!!";

			};	

[armaCom, "PLAYBACK"] call jayarma2lib_fnc_writePipe;
while{true} do
   {if (playbackMode) exitWith {player sidechat "Client confirmed playback. Proceeding."; };};    
_timer = [] execVM "timer.sqf";
player sidechat "playback while cycle starting";	

while {true} do {
_ddata = [delphiData] call jayarma2lib_fnc_readPipe;

if(!isNil("_ddata")) then {
//compile th read data
_xdata = call compile format["%1",_ddata];

//catch fired event
//fire [muzzle, mode, magazine]
//[unit, weapon, muzzle, mode, ammo]
//["fired", recorder, "AK_107_pso", "AK_107_pso", "FullAuto", "B_545x39_Ball"]
_type = format["%1",(_xdata select 0)];
if(_type == "fired") then {
//_muzzle = format["%1",(_xdata select 3)];
shoot action ["useWeapon",(_xdata select 1),(_xdata select 1),0]; 

//recorder action ["useWeapon",recorder,recorder,0]; 
(_xdata select 1) fire _muzzle;
//(_xdata select 1) fire [_xdata select 3, _xdata select 4, _xdata select 5];
player sidechat format["%1 fires %2", _xdata select 1, _xdata select 2];
};

//catch hit event
//hit [unit, causedBy, damage]
if(_type == "hit") then {
//(_xdata select 1) fire [_xdata select 3, _xdata select 4, _xdata select 5];
(_xdata select 2) doTarget (_xdata select 1);
player sidechat format["%1 hit by %2", _xdata select 1, _xdata select 2];
};

if(_type == "reload") then {
reload (_xdata select 1);
player sidechat format["%1 reloading", _xdata select 1];
};

if(_type == "data") then {
				{//hintSilent format["PLAY: %1. Current time: %2", _xdata select 0, vrema];
waitUntil {vrema >= _xdata select 2};
//player sidechat format["%1", (_xdata select 1) select 0];

if((_x select 4) != 1) then {
			_anim = format["%1", _x select 3];
			_curanim = animationState (_x select 0);
			if (_anim != _curanim ) then {(_x select 0) playMoveNow _anim;};
			(_x select 0) setPosATL [(_x select 1) select 0,(_x select 1) select 1,(_x select 1) select 2]; 
			(_x select 0) setDir (_x select 2);
			_ammos = (_x select 0) ammo (primaryWeapon (_x select 0));
	  if (_ammos <= 1) then { reload (_x select 0);};
							} else {(_x select 0) setDamage (_x select 4);};
				} forEach (_xdata select 1);
}						
	};
   if (!playbackMode) exitWith {player sidechat "Reading ended"; };
   if (_ddata == "EOF") exitWith {player sidechat "Reading ended"; vrema = 0; playbackMode = false; aartimer = false;};
   };
//disableUserInput false;