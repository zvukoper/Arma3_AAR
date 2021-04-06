vrema = 0;
player sidechat "timer started";
While {true} do {
titleText [format["%1 (at %2 FPS)",vrema, fps], "PLAIN DOWN", 0.5];
if (!aartimer) exitWith {titleText [format["timer stopped at %1", vrema], "PLAIN DOWN"]; vrema = 0; };
vrema = vrema + 1;
sleep fps;
}; 