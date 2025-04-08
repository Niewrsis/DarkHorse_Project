using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetInt(ConstVar.DAYS_PP, 1);
        SceneManager.LoadScene(ConstVar.BAR_SCREEN_INDEX);
    }

}
