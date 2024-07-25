using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private SceneName _sceneName;

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync($"{_sceneName}");
    }

}
