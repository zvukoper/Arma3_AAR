////////////////////////////////////////////////////////////////////
//DeRap: jayarma2lib_pipe\config.bin
//Produced from mikero's Dos Tools Dll version 7.16
//https://armaservices.maverick-applications.com/Products/MikerosDosTools/default
//'now' is Tue Apr 06 21:31:46 2021 : 'file' last modified on Mon Jan 02 09:25:00 2012
////////////////////////////////////////////////////////////////////

#define _ARMA_

class CfgPatches
{
	class jayarma2lib_pipe
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
	class JayArma2Lib
	{
		class Pipe
		{
			class openPipe
			{
				description = "Opens a named pipe.";
				file = "\x\jayarma2lib\addons\pipe\fnc_openPipe.sqf";
			};
			class writePipe
			{
				description = "Writes to a named pipe.";
				file = "\x\jayarma2lib\addons\pipe\fnc_writePipe.sqf";
			};
			class readPipe
			{
				description = "Reads from a named pipe.";
				file = "\x\jayarma2lib\addons\pipe\fnc_readPipe.sqf";
			};
			class closePipe
			{
				description = "Closes a named pipe.";
				file = "\x\jayarma2lib\addons\pipe\fnc_closePipe.sqf";
			};
		};
	};
};
