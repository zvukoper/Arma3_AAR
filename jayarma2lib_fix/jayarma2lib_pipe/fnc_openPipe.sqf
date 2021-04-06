private["_badRet", "_pipeHandle"];

_pipeHandle = ["OpenPipe", (_this select 0),"", ""] call jayarma2lib_fnc_callExtension;

if(_pipeHandle == "_JERR_ERR_NOT_ENOUGH_ARGS" || _pipeHandle == "_JERR_NULL" || _pipeHandle == "_JERR_ERR_U") then {
	_pipeHandle = nil;
};

_pipeHandle

