# Hell X Client

The client is a Unity 2D WebGL project for the Hell X vertical slice.

## Structure

```txt
Assets/
  Scenes/
    MainMenu.unity
    Chapter01_Room01.unity
    FirstRoom.unity
    PocScene.unity
  Scripts/
    Game/
    Network/
    Player/
    Interaction/
    Save/
    UI/
```

## Day 2 Skeleton

- `Player/PlayerMovement.cs` handles top-down Rigidbody2D movement.
- `Interaction/InteractionController.cs` detects nearby objects and records a local checkpoint.
- `Interaction/InteractableObject.cs` provides the first inspectable object behavior.
- `Save/LocalSaveStore.cs` stores a local checkpoint through PlayerPrefs.
- `Network/BackendClient.cs` calls local backend mock endpoints.
- `UI/StatusDisplay.cs` updates a TextMeshPro status label.
- `UI/BackendStatusController.cs` runs the local backend mock flow and displays success or failure.
- `UI/MainMenuController.cs` loads the first room from the menu.
- `Game/RoomStateCoordinator.cs` sets the first Week 2 room objective.

## Scene Setup

- `MainMenu.unity` is the entry scene.
- `Chapter01_Room01.unity` is the Week 2 playable room loop.
- `FirstRoom.unity` is the first gameplay room structure.
- `PocScene.unity` remains available as the earlier proof-of-concept scene.
- Build settings list `MainMenu` and `Chapter01_Room01` for the Week 2 flow.

## WebGL Readiness

1. Open `client/` in Unity `6000.3.11f1` or a compatible editor.
2. Confirm the active build target is WebGL.
3. Open `Assets/Scenes/MainMenu.unity`.
4. Wire a UI button to `MainMenuController.StartGame`.
5. Open `Assets/Scenes/Chapter01_Room01.unity`.
6. Add a player object with `Rigidbody2D`, collider, `PlayerMovement`, and `InteractionController`.
7. Add an interactable object with a trigger collider and `InteractableObject`.
8. Add a TextMeshPro status label and connect it to `StatusDisplay`.
9. Add a scene object with `BackendClient` and `BackendStatusController`.
10. Connect a UI button or test object to `BackendStatusController.CheckBackend`.
11. Save scenes before creating a WebGL build.

## Local Backend Mock Flow

Run the backend in a separate terminal:

```bash
cd server
npm install
npm run dev
```

In Unity:

1. Open `Assets/Scenes/FirstRoom.unity`.
2. Add `BackendClient` to a scene object and keep the default base URL `http://localhost:3000`.
3. Add `BackendStatusController` to a scene object.
4. Connect the status label, local save store, and backend client references.
5. Trigger `CheckBackend` from a UI button or temporary test object.

Expected success status:

```txt
Backend ready: first-room / intro
```

If the backend is not running, the status text should show an unavailable or failed request state.

Production login, cloud save, database persistence, dashboard work, and online deployment are not part of Week 1 foundation.

## Manual Check

Use [manual test checklist](../docs/manual-test-checklist.md) for the current Week 1 verification flow.
