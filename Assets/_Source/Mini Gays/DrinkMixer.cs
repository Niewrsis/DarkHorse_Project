using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkMixer : MonoBehaviour
{
    public Button ginButton;
    public Button whiskeyButton;
    public Button rumButton;
    public Button iceButton;
    public Button mixButton;

    public GameObject panpanosSprite; // Объект для Панпанос
    public GameObject normisianoSprite; // Объект для Нормисианно
    public GameObject surpriseSprite; // Объект для Сюрприз из глубин
    public GameObject minus40Sprite; // Объект для -40 градусов по фарингейту
    public GameObject wrongCombinationSprite; // Объект для неправильной комбинации

    private List<string> ingredients = new List<string>();

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
        ingredients.Add(ingredient);
        Debug.Log("Добавлено: " + ingredient);
    }

    void MixDrinks()
    {
        string result = CheckRecipe(ingredients);
        ShowResult(result);
        ingredients.Clear(); // Сбрасываем ингредиенты после смешивания
    }

    string CheckRecipe(List<string> ingredients)
    {
        if (MatchRecipe(ingredients, new List<string> { "Gin", "Whiskey", "Ice" }))
            return "Panpanos";
        if (MatchRecipe(ingredients, new List<string> { "Rum", "Ice" }))
            return "Normisiano";
        if (MatchRecipe(ingredients, new List<string> { "Whiskey", "Rum", "Gin" }))
            return "Surprise from the Depths";
        if (MatchRecipe(ingredients, new List<string> { "Ice", "Ice", "Ice" }))
            return "-40 Degrees Fahrenheit";

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
        // Скрываем все спрайты
        panpanosSprite.SetActive(false);
        normisianoSprite.SetActive(false);
        surpriseSprite.SetActive(false);
        minus40Sprite.SetActive(false);
        wrongCombinationSprite.SetActive(false);

        // Показываем нужный спрайт
        switch (result)
        {
            case "Panpanos":
                panpanosSprite.SetActive(true);
                break;
            case "Normisiano":
                normisianoSprite.SetActive(true);
                break;
            case "Surprise from the Depths":
                surpriseSprite.SetActive(true);
                break;
            case "-40 Degrees Fahrenheit":
                minus40Sprite.SetActive(true);
                break;
            default:
                wrongCombinationSprite.SetActive(true);
                break;
        }
    }
}
