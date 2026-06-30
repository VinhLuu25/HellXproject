# Hell X Client

The client is a Unity 2D WebGL project for the Hell X vertical slice.

## Structure

```txt
Assets/
  Scenes/
    MainMenu.unity
    FirstRoom.unity
    PocScene.unity
  Scripts/
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
- `UI/StatusDisplay.cs` updates a TextMeshPro status label.
- `UI/MainMenuController.cs` loads the first room from the menu.

## Scene Setup

- `MainMenu.unity` is the entry scene.
- `FirstRoom.unity` is the first gameplay room structure.
- `PocScene.unity` remains available as the earlier proof-of-concept scene.
- Build settings list `MainMenu`, `FirstRoom`, then `PocScene`.

## WebGL Readiness

1. Open `client/` in Unity `6000.3.11f1` or a compatible editor.
2. Confirm the active build target is WebGL.
3. Open `Assets/Scenes/MainMenu.unity`.
4. Wire a UI button to `MainMenuController.StartGame`.
5. Open `Assets/Scenes/FirstRoom.unity`.
6. Add a player object with `Rigidbody2D`, collider, `PlayerMovement`, and `InteractionController`.
7. Add an interactable object with a trigger collider and `InteractableObject`.
8. Add a TextMeshPro status label and connect it to `StatusDisplay`.
9. Save scenes before creating a WebGL build.

No backend, login, cloud save, database, dashboard, or online integration is part of Day 2.
