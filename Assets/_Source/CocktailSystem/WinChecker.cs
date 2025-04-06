using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CocktailSystem
{
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
            string[] cocktails = { "TORPEDO", "HOWARD PHILLIPS", "LONELY RAG-A-MUFFIN", "FLAPPER'S DELIGHT" };
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
}