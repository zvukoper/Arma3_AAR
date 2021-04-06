////////////////////////////////////////////////////////////////////
//DeRap: jayarma2lib_common\config.bin
//Produced from mikero's Dos Tools Dll version 7.16
//https://armaservices.maverick-applications.com/Products/MikerosDosTools/default
//'now' is Tue Apr 06 07:30:08 2021 : 'file' last modified on Mon Jan 02 09:25:27 2012
////////////////////////////////////////////////////////////////////

#define _ARMA_

class CfgPatches
{
	class jayarma2lib_common
	{
		units[] = {};
		requiredVersion = 1.01;
		requiredAddons[] = {"jayarma2lib_main"};
		version = "1.3.3.100";
		author[] = {"Jaynus","Nou"};
		authorUrl = "http:\/\/dev-heaven.net/projects/jayarma2lib";
	};
};
class CfgFunctions
{
	class kbAddTopicProxy
	{
		description = "Proxy for kbAddTopic.";
		file = "\x\jayarma2lib\addons\common\fnc_kbAddTopicProxy.sqf";
	};
	class JayArma2Lib
	{
		class Common
		{
			class testFunc
			{
				description = "Test function.";
				file = "\x\jayarma2lib\addons\common\fnc_testFunc.sqf";
			};
			class writeLog
			{
				description = "Writes a string out to the log file.";
				file = "\x\jayarma2lib\addons\common\fnc_writeLog.sqf";
			};
			class getLocaltime
			{
				description = "Gets the local time of the machine.";
				file = "\x\jayarma2lib\addons\common\fnc_getLocalTime.sqf";
			};
		};
	};
};
class Extended_PreInit_EventHandlers
{
	class jayarma2lib_common
	{
		init = "call ('\x\jayarma2lib\addons\common\XEH_preinit.sqf' call SLX_XEH_COMPILE)";
	};
};
