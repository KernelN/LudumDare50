using UnityEngine.SceneManagement;

namespace Universal.SceneManaging
{
    public static class SceneLoader
    {        
        public static Scenes GetCurrentScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            switch (currentScene.name)
            {
                case "ProtoGameplay":
                    return Scenes.proto;
                case "Menu":
                    return Scenes.menu;
                case "Highscores":
                    return Scenes.menu;
                case "Credits":
                    return Scenes.credits;
                default:
                    return Scenes.menu;
            }
        }
        public static void LoadScene(Scenes sceneToLoad)
        {
            string sceneName = "ProtoGameplay";

            switch (sceneToLoad)
            {
                case Scenes.proto:
                    sceneName = "ProtoGameplay";
                    break;
                case Scenes.menu:
                    sceneName = "Menu";
                    break;
                case Scenes.highscores:
                    sceneName = "Highscores";
                    break;
                case Scenes.credits:
                    sceneName = "Credits";
                    break;
                default:
                    break;
            }

            ASyncSceneLoader.Get().StartLoad(sceneName);
        }
    }
}