using UnityEngine.SceneManagement;

public class SceneSystem : SingletonMonoBehaviour<SceneSystem>
{
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
