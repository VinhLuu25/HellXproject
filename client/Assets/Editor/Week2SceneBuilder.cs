using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HellX.EditorTools
{
    public static class Week2SceneBuilder
    {
        private const string MainMenuPath = "Assets/Scenes/MainMenu.unity";
        private const string RoomPath = "Assets/Scenes/Chapter01_Room01.unity";

        public static void BuildWeek2Scenes()
        {
            EnsureFolder("Assets/Scenes");
            BuildMainMenu();
            BuildRoom();
            UpdateBuildSettings();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private static void BuildMainMenu()
        {
            Scene scene = OpenOrCreateScene(MainMenuPath);
            Camera camera = EnsureCamera("Main Camera", new Vector3(0f, 0f, -10f), 5f);
            camera.backgroundColor = new Color(0.02f, 0.02f, 0.025f);

            GameObject root = EnsureObject("MenuRoot");
            MainMenuController controller = EnsureComponent<MainMenuController>(root);

            Canvas canvas = EnsureCanvas("MenuCanvas");
            EnsureEventSystem();
            TMP_Text title = EnsureText(canvas.transform, "TitlePlaceholder", "HELL X", new Vector2(0f, 120f), 58);
            title.color = new Color(0.8f, 0.06f, 0.05f);
            EnsureText(canvas.transform, "StartTestSessionPlaceholder", "Start Test Session", new Vector2(0f, 35f), 26);
            EnsureText(canvas.transform, "StatusPlaceholder", "Press start to enter Chapter 01.", new Vector2(0f, -40f), 20);
            Button button = EnsureButton(canvas.transform, "StartButton", "Start", new Vector2(0f, -120f));
            SerializedObject serialized = new SerializedObject(controller);
            serialized.FindProperty("firstRoomSceneName").stringValue = "Chapter01_Room01";
            serialized.ApplyModifiedPropertiesWithoutUndo();
            SerializedObject buttonSerialized = new SerializedObject(button);
            buttonSerialized.FindProperty("m_OnClick.m_PersistentCalls.m_Calls").ClearArray();
            buttonSerialized.ApplyModifiedPropertiesWithoutUndo();
            UnityEditor.Events.UnityEventTools.AddPersistentListener(button.onClick, controller.StartGame);

            EditorSceneManager.SaveScene(scene, MainMenuPath);
        }

        private static void BuildRoom()
        {
            Scene scene = OpenOrCreateScene(RoomPath);
            Camera camera = EnsureCamera("Main Camera", new Vector3(0f, 0f, -10f), 6f);
            camera.backgroundColor = new Color(0.015f, 0.014f, 0.018f);

            GameObject root = EnsureObject("RoomRoot");
            EnsureComponent<RoomStateCoordinator>(root);
            EnsureSprite("FloorPlaceholder", root.transform, new Vector3(0f, 0f, 0f), new Vector2(12f, 7f), new Color(0.11f, 0.11f, 0.12f), false);
            EnsureBoundary("BoundaryTop", root.transform, new Vector3(0f, 3.6f, 0f), new Vector2(12f, 0.2f));
            EnsureBoundary("BoundaryBottom", root.transform, new Vector3(0f, -3.6f, 0f), new Vector2(12f, 0.2f));
            EnsureBoundary("BoundaryLeft", root.transform, new Vector3(-6.1f, 0f, 0f), new Vector2(0.2f, 7f));
            EnsureBoundary("BoundaryRight", root.transform, new Vector3(6.1f, 0f, 0f), new Vector2(0.2f, 7f));

            GameObject player = EnsureSprite("PlayerPlaceholder", root.transform, new Vector3(-4f, -1.8f, 0f), new Vector2(0.55f, 0.75f), new Color(0.85f, 0.86f, 0.78f), true);
            Rigidbody2D body = EnsureComponent<Rigidbody2D>(player);
            body.gravityScale = 0f;
            body.freezeRotation = true;
            EnsureComponent<PlayerMovement>(player);
            BoxCollider2D playerCollider = EnsureComponent<BoxCollider2D>(player);
            playerCollider.isTrigger = false;

            GameObject controllerObject = EnsureObject("InteractionController", player.transform);
            controllerObject.transform.localPosition = Vector3.zero;
            InteractionController interaction = EnsureComponent<InteractionController>(controllerObject);
            BoxCollider2D interactionRange = EnsureComponent<BoxCollider2D>(controllerObject);
            interactionRange.isTrigger = true;
            interactionRange.size = new Vector2(1.8f, 1.8f);
            Rigidbody2D interactionBody = EnsureComponent<Rigidbody2D>(controllerObject);
            interactionBody.gravityScale = 0f;
            interactionBody.bodyType = RigidbodyType2D.Kinematic;

            GameObject clue = EnsureSprite("ClueObject", root.transform, new Vector3(-1.5f, 0.8f, 0f), new Vector2(0.45f, 0.45f), new Color(0.95f, 0.82f, 0.25f), true);
            InteractableObject clueInteraction = EnsureComponent<InteractableObject>(clue);
            SetPrivateString(clueInteraction, "interactionMessage", "Clue found: a torn chapel note.");
            BoxCollider2D clueCollider = EnsureComponent<BoxCollider2D>(clue);
            clueCollider.isTrigger = true;

            GameObject puzzle = EnsureSprite("PuzzleObject", root.transform, new Vector3(2.1f, 1.1f, 0f), new Vector2(0.75f, 0.75f), new Color(0.32f, 0.45f, 0.9f), true);
            InteractableObject puzzleInteraction = EnsureComponent<InteractableObject>(puzzle);
            SetPrivateString(puzzleInteraction, "interactionMessage", "The lock needs a clue.");
            EnsureComponent<BoxCollider2D>(puzzle).isTrigger = true;

            EnsureSprite("LockedExitPlaceholder", root.transform, new Vector3(4.8f, 0f, 0f), new Vector2(0.7f, 1.8f), new Color(0.4f, 0.05f, 0.07f), true);
            GameObject checkpoint = EnsureSprite("CheckpointObject", root.transform, new Vector3(3.2f, -2f, 0f), new Vector2(0.8f, 0.45f), new Color(0.1f, 0.7f, 0.5f), true);
            InteractableObject checkpointInteraction = EnsureComponent<InteractableObject>(checkpoint);
            SetPrivateString(checkpointInteraction, "interactionMessage", "Checkpoint reached.");
            EnsureComponent<BoxCollider2D>(checkpoint).isTrigger = true;

            Canvas canvas = EnsureCanvas("RoomCanvas");
            EnsureEventSystem();
            TMP_Text status = EnsureText(canvas.transform, "StatusText", "Find the clue.", new Vector2(0f, -245f), 22);
            status.color = new Color(0.88f, 0.88f, 0.82f);
            EnsureText(canvas.transform, "BackendStatusPlaceholder", "Backend not checked.", new Vector2(0f, -285f), 16);
            StatusDisplay display = EnsureComponent<StatusDisplay>(status.gameObject);
            SerializedObject statusSerialized = new SerializedObject(display);
            statusSerialized.FindProperty("statusText").objectReferenceValue = status;
            statusSerialized.FindProperty("defaultStatus").stringValue = "Find the clue.";
            statusSerialized.ApplyModifiedPropertiesWithoutUndo();

            LocalSaveStore store = EnsureComponent<LocalSaveStore>(root);
            SerializedObject interactionSerialized = new SerializedObject(interaction);
            interactionSerialized.FindProperty("statusDisplay").objectReferenceValue = display;
            interactionSerialized.FindProperty("saveStore").objectReferenceValue = store;
            interactionSerialized.ApplyModifiedPropertiesWithoutUndo();

            EditorSceneManager.SaveScene(scene, RoomPath);
        }

        private static Scene OpenOrCreateScene(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return EditorSceneManager.OpenScene(path, OpenSceneMode.Single);
            }

            return EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        }

        private static void EnsureFolder(string path)
        {
            string[] parts = path.Split('/');
            string current = parts[0];
            for (int index = 1; index < parts.Length; index++)
            {
                string next = $"{current}/{parts[index]}";
                if (!AssetDatabase.IsValidFolder(next))
                {
                    AssetDatabase.CreateFolder(current, parts[index]);
                }

                current = next;
            }
        }

        private static Camera EnsureCamera(string name, Vector3 position, float size)
        {
            GameObject target = EnsureObject(name);
            Camera camera = EnsureComponent<Camera>(target);
            target.tag = "MainCamera";
            target.transform.position = position;
            camera.orthographic = true;
            camera.orthographicSize = size;
            return camera;
        }

        private static GameObject EnsureObject(string name, Transform parent = null)
        {
            GameObject found = GameObject.Find(name);
            if (found == null)
            {
                found = new GameObject(name);
            }

            found.transform.SetParent(parent);
            found.transform.localScale = Vector3.one;
            return found;
        }

        private static T EnsureComponent<T>(GameObject target) where T : Component
        {
            T component = target.GetComponent<T>();
            return component != null ? component : target.AddComponent<T>();
        }

        private static GameObject EnsureSprite(string name, Transform parent, Vector3 position, Vector2 size, Color color, bool collider)
        {
            GameObject target = EnsureObject(name, parent);
            target.transform.position = position;
            SpriteRenderer renderer = EnsureComponent<SpriteRenderer>(target);
            renderer.sprite = BuiltinSprite();
            renderer.color = color;
            target.transform.localScale = new Vector3(size.x, size.y, 1f);
            if (collider)
            {
                BoxCollider2D box = EnsureComponent<BoxCollider2D>(target);
                box.size = Vector2.one;
            }

            return target;
        }

        private static void EnsureBoundary(string name, Transform parent, Vector3 position, Vector2 size)
        {
            GameObject target = EnsureSprite(name, parent, position, size, new Color(0.02f, 0.02f, 0.025f), true);
            BoxCollider2D box = EnsureComponent<BoxCollider2D>(target);
            box.isTrigger = false;
        }

        private static Sprite BuiltinSprite()
        {
            return AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        }

        private static Canvas EnsureCanvas(string name)
        {
            GameObject target = EnsureUiObject(name);
            Canvas canvas = EnsureComponent<Canvas>(target);
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            EnsureComponent<CanvasScaler>(target);
            EnsureComponent<GraphicRaycaster>(target);
            return canvas;
        }

        private static TMP_Text EnsureText(Transform parent, string name, string text, Vector2 position, int fontSize)
        {
            GameObject target = EnsureUiObject(name, parent);
            TMP_Text label = EnsureComponent<TextMeshProUGUI>(target);
            label.text = text;
            label.fontSize = fontSize;
            label.alignment = TextAlignmentOptions.Center;
            RectTransform rect = EnsureComponent<RectTransform>(target);
            rect.sizeDelta = new Vector2(640f, 80f);
            rect.anchoredPosition = position;
            return label;
        }

        private static Button EnsureButton(Transform parent, string name, string label, Vector2 position)
        {
            GameObject target = EnsureUiObject(name, parent);
            Image image = EnsureComponent<Image>(target);
            image.color = new Color(0.2f, 0.02f, 0.03f);
            Button button = EnsureComponent<Button>(target);
            RectTransform rect = EnsureComponent<RectTransform>(target);
            rect.sizeDelta = new Vector2(220f, 54f);
            rect.anchoredPosition = position;
            TMP_Text text = EnsureText(target.transform, $"{name}Text", label, Vector2.zero, 22);
            text.color = Color.white;
            return button;
        }

        private static GameObject EnsureUiObject(string name, Transform parent = null)
        {
            GameObject found = GameObject.Find(name);
            if (found == null)
            {
                found = new GameObject(name, typeof(RectTransform));
            }

            found.transform.SetParent(parent);
            found.transform.localScale = Vector3.one;
            return found;
        }

        private static void EnsureEventSystem()
        {
            if (GameObject.Find("EventSystem") != null)
            {
                return;
            }

            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<UnityEngine.EventSystems.EventSystem>();
            eventSystem.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }

        private static void SetPrivateString(Object target, string propertyName, string value)
        {
            SerializedObject serialized = new SerializedObject(target);
            serialized.FindProperty(propertyName).stringValue = value;
            serialized.ApplyModifiedPropertiesWithoutUndo();
        }

        private static void UpdateBuildSettings()
        {
            string[] required = { MainMenuPath, RoomPath };
            List<EditorBuildSettingsScene> scenes = EditorBuildSettings.scenes
                .Where(scene => required.Contains(scene.path) || System.IO.File.Exists(scene.path))
                .ToList();

            foreach (string path in required)
            {
                if (scenes.All(scene => scene.path != path))
                {
                    scenes.Add(new EditorBuildSettingsScene(path, true));
                }
            }

            EditorBuildSettings.scenes = scenes.ToArray();
        }
    }
}
