using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToGoBack;

    public void GoToSpecifiedScene()
    {
        SceneManager.LoadScene(sceneToGoBack);
    }
}
