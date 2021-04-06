#include "script_component.hpp"
private["_ret"];
_ret = nil;
if(jayarma2lib_isRunning) then {
	_ret = player kbAddTopic[(_this select 0), (_this select 1), (_this select 2), (_this select 3)];
} else {

	hintSilent "JayArmA2Lib ERROR:\nFunction called while dsound.dll not loaded properly.";
	
	_ret = nil;
}

_ret