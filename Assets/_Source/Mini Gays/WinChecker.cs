using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinChecker : MonoBehaviour
{
    public TMP_Text cocktailNameText;
    public Button winButton;
    private string currentCocktail;

    void Start()
    {
        winButton.gameObject.SetActive(false);
        SetRandomCocktail();
    }

    void SetRandomCocktail()
    {
        string[] cocktails = { "Panpanos", "Normisiano", "Surprise from the Depths", "-40 Degrees Fahrenheit" };
        currentCocktail = cocktails[Random.Range(0, cocktails.Length)];
        cocktailNameText.text = currentCocktail;
    }

    public void CheckWin(string result)
    {
        if (result == currentCocktail)
        {
            winButton.gameObject.SetActive(true);
            Debug.Log("Вы выиграли!");
        }
    }
}
