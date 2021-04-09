# After Action Review 3 — battle replays in ARMA 3

## "Record. Replay. Learn."

BI forum thread - https://forums.bohemia.net/forums/topic/234176-after-action-review-3-%E2%80%94-battle-replays-in-arma-3/

### Roadmap:

* :ballot_box_with_check: Custom dll to link Arma3 with AARecorder.
* :black_square_button: Custom software to write replay files to disk directly from Arma3.
* :black_square_button: Recreate the app for 64-bit and with filename generation.
* :black_square_button: Record a replay into an .aar file: unit actions, including gear, animations, unit model, shooting, death, vehicle operation, commands.
* :black_square_button: Playback a replay file with the ability to spectate.
* :black_square_button: Documentation: How to install and use.
* :black_square_button: Unit and event icons on the map.
* :black_square_button: Pause and resume a replay.
* :black_square_button: Draw ballistic lines for projectiles colored by unit squad\faction.
* :black_square_button: Filename generation for new replay files.
* :black_square_button: Record ingame chat and system messages.
* :black_square_button: User-defined filenames.
* :black_square_button: Rewind and fastforward a replay.
* :black_square_button: Set playback start time.
* :black_square_button: Extended options: simplified playback (no models, no units, only icons moving and shooting).
* :black_square_button: Breakpoints with focus: define the event and the replay will pause automatically.
* :black_square_button: Display mission date\time and playback time.
* :black_square_button: Unit and event overlay icons visible when spectating.
* :black_square_button: Icon cleanup delay time: a setting defining how long icons stay on the map before being deleted.
* :black_square_button: Icon decay time: Icons turn transparent and grey after the set time to still inform you visually, but without making distraction.
* :black_square_button: Extended options: event and unit filtering (what to record, what to playback)
* :black_square_button: Convert the replay file into a standalone html file, that can be played back in the map mode in a browser\published online.
* :black_square_button: Playback: add a global comment in the replay or a map marker comment.
* :black_square_button: Convert the replay to a log with the selected events.


### Known bugs fixing:

* :ballot_box_with_check: Software works only with 32-bit Arma3
* :warning: Some errors in scripts prevent playback



### Thanks to:

* Cupcake Punisher for bringing the idea back to life after 10 years.
* dalber24 for sharing the backup files.
* Sickboy for all the help with scripting, hosting, etc.
* Jaynus for his revolutionary arma2lib.
* Maca134 for his DLL export templates https://github.com/maca134/Maca134.Arma.DllExport
* BIS for ... for everything :)
* CBA team for CBA mod.
* -=Russian Alliance=- squad for all the painful testing of the system back in Arma2.
* All people out there on the forums who answered all my silly scripting questions.

This project is an attempt top revive the system from Arma2 https://github.com/zvukoper/Arma2AAR
