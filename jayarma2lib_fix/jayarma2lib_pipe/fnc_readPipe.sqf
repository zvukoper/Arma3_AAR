private["_noResponse", "_ret"];

_ret = ["ReadPipe", (_this select 0), "", ""]  call jayarma2lib_fnc_callExtension;
player sidechat _ret;
if(_ret == "_JERR_NULL") then {
	_ret = nil;
};

_ret