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
                case "Gameplay":
                    return Scenes.gameplay;
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
            string sceneName = "ERROR";

            switch (sceneToLoad)
            {
                case Scenes.gameplay:
                    sceneName = "Gameplay";
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