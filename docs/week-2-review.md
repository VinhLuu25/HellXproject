# Week 2 Review

## Completed Work

- Main menu scene target exists at `client/Assets/Scenes/MainMenu.unity`.
- First room scene target exists at `client/Assets/Scenes/Chapter01_Room01.unity`.
- Player movement, clue pickup, inventory state, journal state, puzzle state, checkpoint trigger, and local save payload scripts are in place.
- The room scene builder can update the menu and first room through Unity Editor APIs.
- The client has a backend flow for health check, test session, save write, and save load.
- The backend has validated save write/load/reset routes backed by an in-memory save store.
- Prisma schema has player, session, and save slot models aligned to the save shape.
- Manual checklist and demo script now describe the Week 2 slice.

## Partial Work

- Save persistence is process memory only. It is not database-backed.
- Client save/load flow has scripts and scene wiring, but manual play mode verification was not performed.
- Puzzle and checkpoint behavior are implemented in code and scene wiring, but no manual Unity playthrough was recorded.
- WebGL build readiness is documented, but no exported build was produced.

## Skipped Work

- Production login was skipped.
- Database migrations were skipped.
- Dashboard work was skipped.
- Enemy systems, new chapters, and larger puzzle systems were skipped.
- WebGL build export and browser playthrough were skipped.

## Known Risks

- Unity play mode has not been used to verify collider sizes, trigger order, UI binding, or keyboard interaction.
- The current backend save store resets when the process restarts.
- The client and backend use a test session path only.
- Some older Unity metadata and a solution file change remain unstaged from recovery and were not included in Day commits.

## Checks Passed

- `git diff --check` passed before each Day commit after cleanup.
- Path trace check passed before each Day commit after dependency output cleanup.
- Staged blocked-word trace check produced no output before each Day commit.
- Day 12 backend checks passed:
  - `npm install`
  - `npm run build`
  - `npm test`
  - `npx prisma validate`
- Day 13 backend checks passed:
  - `npm install`
  - `npm run build`
  - `npm test`
- Unity scene builder exited successfully for Day 11 and Day 13.

## Checks That Could Not Run

- Manual Unity play mode verification was not run.
- WebGL build verification was not run.
- PostgreSQL-backed persistence was not run.
- Prisma migration was not run.

## Unity Editor Status

- `UNITY_EDITOR` was set to `/Applications/Unity/Hub/Editor/6000.3.11f1/Unity.app/Contents/MacOS/Unity`.
- `client/ProjectSettings/ProjectVersion.txt` exists.
- Day 10 first Unity attempt failed because Unity Package Manager could not open `/tmp/Unity-Upm-69808.sock`.
- Day 10 retry timed out after 480 seconds while the Unity Licensing Client was reconnecting.
- Day 11 Unity scene builder completed successfully.
- Day 13 Unity scene builder completed successfully.
- Unity log path: `/tmp/hellx-week2-scenes.log`.

## Actual Scene Creation Status

- `client/Assets/Scenes/MainMenu.unity` was updated by Unity.
- `client/Assets/Scenes/Chapter01_Room01.unity` was created and updated by Unity.
- `client/ProjectSettings/EditorBuildSettings.asset` includes the Week 2 room scene.

## Demo Readiness Status

- The repository is ready for a code-and-doc demo of the Week 2 vertical slice.
- A live gameplay demo still needs a manual Unity play mode pass.
- A save/load demo can be attempted with the backend running locally, but it should be described as test-session and in-memory persistence.

## Next Decisions

- Decide whether Week 3 prioritizes manual play verification first or database-backed saves first.
- Decide whether to keep the current scene-builder approach for more rooms.
- Decide when to introduce a visible UI control for save/load testing instead of inspector-triggered calls.
