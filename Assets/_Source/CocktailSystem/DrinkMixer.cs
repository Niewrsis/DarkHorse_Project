using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CocktailSystem
{
    public class DrinkMixer : MonoBehaviour
    {
        public Button ginButton;
        public Button whiskeyButton;
        public Button rumButton;
        public Button iceButton;
        public Button mixButton;

        public GameObject torpedoSprite;
        public GameObject howardphillipsSprite;
        public GameObject lonelyragamuffinSprite;
        public GameObject flappersdelightSprite;
        public GameObject wrongCombinationSprite;

        public WinChecker winChecker;

        private List<string> ingredients = new List<string>();
        private bool hasWon = false; // Флаг для проверки, выиграл ли игрок

        void Start()
        {
            ginButton.onClick.AddListener(() => AddIngredient("Gin"));
            whiskeyButton.onClick.AddListener(() => AddIngredient("Whiskey"));
            rumButton.onClick.AddListener(() => AddIngredient("Rum"));
            iceButton.onClick.AddListener(() => AddIngredient("Ice"));
            mixButton.onClick.AddListener(MixDrinks);
        }

        void AddIngredient(string ingredient)
        {
            if (!hasWon) // Проверяем, выиграл ли игрок
            {
                ingredients.Add(ingredient);
                Debug.Log("Добавлено: " + ingredient);
            }
        }

        void MixDrinks()
        {
            if (hasWon) return; // Если игрок уже выиграл, не смешиваем напитки

            string result = CheckRecipe(ingredients);
            ShowResult(result);
            winChecker.CheckWin(result);
            ingredients.Clear();
        }

        string CheckRecipe(List<string> ingredients)
        {
            if (MatchRecipe(ingredients, new List<string> { "Rum", "Gin", "Gin", "Ice" }))
                return "TORPEDO";
            if (MatchRecipe(ingredients, new List<string> { "Gin", "Rum", "Rum" }))
                return "HOWARD PHILLIPS";
            if (MatchRecipe(ingredients, new List<string> { "Gin", "Rum", "Whiskey" }))
                return "LONELY RAG-A-MUFFIN";
            if (MatchRecipe(ingredients, new List<string> { "Gin", "Gin", "Whiskey", "Whiskey", "Ice" }))
                return "FLAPPER'S DELIGHT";

            return "Wrong Combination";
        }

        bool MatchRecipe(List<string> ingredients, List<string> recipe)
        {
            if (ingredients.Count != recipe.Count) return false;
            for (int i = 0; i < recipe.Count; i++)
            {
                if (ingredients[i] != recipe[i]) return false;
            }
            return true;
        }

        void ShowResult(string result)
        {
            torpedoSprite.SetActive(false);
            howardphillipsSprite.SetActive(false);
            lonelyragamuffinSprite.SetActive(false);
            flappersdelightSprite.SetActive(false);
            wrongCombinationSprite.SetActive(false);

            switch (result)
            {
                case "TORPEDO":
                    torpedoSprite.SetActive(true);
                    hasWon = true; // Устанавливаем флаг выигрыша
                    break;
                case "HOWARD PHILLIPS":
                    howardphillipsSprite.SetActive(true);
                    hasWon = true; // Устанавливаем флаг выигрыша
                    break;
                case "LONELY RAG-A-MUFFIN":
                    lonelyragamuffinSprite.SetActive(true);
                    hasWon = true; // Устанавливаем флаг выигрыша
                    break;
                case "FLAPPER'S DELIGHT":
                    flappersdelightSprite.SetActive(true);
                    hasWon = true; // Устанавливаем флаг выигрыша
                    break;
                default:
                    wrongCombinationSprite.SetActive(true);
                    break;
            }

            // Отключаем кнопку смешивания, если игрок выиграл
            if (hasWon)
            {
                mixButton.interactable = false; // Делаем кнопку недоступной
            }
        }
    }
}
