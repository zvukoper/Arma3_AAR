#include "script_component.hpp"


jayarma2lib_isRunning = false;

jayarma2lib_fnc_callExtension = {
	private ["_functionName", "_args", "_return", "_call"];
	_functionName = _this select 0;
	_args = "";
	_argSize = "";
	for "_i" from 1 to 3 do {
		_str = "";
		if((count _this) >= _i) then {
			_str = format["%1", (_this select _i)];
		};
		_count = (count (toArray _str));
		_argSize = _argSize + format["%1", _count];
		if(_i <= 2) then {
			_argSize = _argSize + ",";
		};
		_args = _args + _str;
		
	};
	_return = "_JERR_ERR_U";
	_call = _functionName + "," + _argSize + "|" + _args;
	_call = _call + toString[0];
	if((count (toArray _call) > 4096)) then {
		diag_log text format["JAYARMA2LIB WARNING!: CALL TO '%1' EXCEDED 4096 CHARACTER LIMIT", _functionName];
	} else {
		// player sideChat format["call: %1", _call];
		_return = "JayArma2Extension" callExtension _call;
	};
	_return;
};

[] spawn {
	private["_returnValueTest"];
	waitUntil { !(isNil "jayarma2lib_fnc_testFunc") };

	_returnValueTest = nil;
	_returnValueTest = call jayarma2lib_fnc_testFunc;

	if(!isNil "_returnValueTest") then {
		switch (_returnValueTest) do {
			case "AA": {
				diag_log "JayArmA2Lib: ACTIVE";
				jayarma2lib_isRunning = true;
			};
			default {
				diag_log "!!! WARNING !!! JayArmA2Lib dsound.dll not loaded properly";
			};
		};
	} else {
		diag_log "!!! WARNING !!! JayArmA2Lib dsound.dll not loaded properly";
	};
};

