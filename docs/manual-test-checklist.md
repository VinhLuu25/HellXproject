# Manual Test Checklist

## Client Skeleton Check

- Open `client/` in Unity when the editor is available.
- Confirm `Assets/Scenes/MainMenu.unity`, `Assets/Scenes/FirstRoom.unity`, and `Assets/Scenes/PocScene.unity` exist.
- Confirm `Assets/Scenes/Chapter01_Room01.unity` exists after the Week 2 scene pass.
- Confirm scripts exist under `Assets/Scripts/Player`, `Assets/Scripts/Interaction`, `Assets/Scripts/Save`, `Assets/Scripts/UI`, and `Assets/Scripts/Network`.
- Confirm scene wiring manually before claiming playable client behavior.

## Week 2 Room Loop Check

- Open `Assets/Scenes/MainMenu.unity`.
- Confirm the title, start test session placeholder, status placeholder, and start button are visible.
- Press play and use the start button to load `Assets/Scenes/Chapter01_Room01.unity`.
- Move the player placeholder with WASD or arrow keys.
- Approach the clue, puzzle, or checkpoint placeholder and press `E`.
- Confirm the status text changes when an interaction is detected.

## Week 2 Clue Pickup Check

- Open `Assets/Scenes/Chapter01_Room01.unity`.
- Move the player near `ClueObject`.
- Press `E`.
- Confirm the clue status says the torn chapel note was found.
- Confirm the clue sprite is hidden after pickup.
- Confirm the room has `InventoryState` and `JournalState` on `RoomRoot`.

## Week 2 Puzzle Check

- Open `Assets/Scenes/Chapter01_Room01.unity`.
- Move the player near `PuzzleObject` before collecting the clue and press `E`.
- Confirm the status says the lock needs the torn chapel note.
- Collect `ClueObject`.
- Return to `PuzzleObject` and press `E`.
- Confirm the status says the chapel lock opens.
- Press `E` again and confirm the status says the chapel lock is already open.
- Confirm the room has `PuzzleState` on `RoomRoot`.

## Week 2 Checkpoint Check

- Open `Assets/Scenes/Chapter01_Room01.unity`.
- Confirm `RoomRoot` has `SavePayloadBuilder` and `LocalSaveStore`.
- Confirm `CheckpointObject` has `CheckpointTrigger` if the scene builder completed.
- Collect `ClueObject`.
- Solve `PuzzleObject`.
- Move the player into `CheckpointObject`.
- Confirm the status says the checkpoint was saved.
- Stop play mode and inspect PlayerPrefs through a local debug pass before claiming resume behavior.

## Backend Health Check

```bash
cd server
npm install
npm run build
npm test
npm run dev
```

Then check:

```txt
GET http://localhost:3000/health
```

Expected result:

```json
{
  "status": "ok",
  "service": "hellx-backend"
}
```

## Mock Save And Load Check

With the backend running:

```txt
POST http://localhost:3000/session/test
GET http://localhost:3000/save/current
PUT http://localhost:3000/save/current
DELETE http://localhost:3000/save/current
```

Expected behavior:

- Test session returns `test-session-001`.
- Current save returns `chapter-01`, `first-room`, and `intro`.
- Write current save accepts the contract payload.
- Reset returns the mock save to `intro`.

## Unity Availability Note

Unity must be opened locally to verify scene wiring, UI button bindings, and WebGL build settings. A command-line server test does not prove Unity scenes are wired.

## Refresh And Resume Expectation

Future vertical slice behavior should let the player:

1. Start a session.
2. Enter the first room.
3. Collect a clue.
4. Trigger a checkpoint.
5. Refresh or return later.
6. Resume at the saved room, checkpoint, inventory, clues, journal entries, puzzle flags, and retry state.

Week 1 only defines and mocks this path.

## Known Skipped Checks

- WebGL build verification.
- Real PostgreSQL persistence.
- Prisma migrations.
- Production login.
- Dashboard checks.
- Fresh clone simulation.
