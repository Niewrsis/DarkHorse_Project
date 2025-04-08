using System.Collections.Generic;
using UnityEngine;

public class IngredientIndicator : MonoBehaviour
{
    public GameObject ginSprite;
    public GameObject whiskeySprite;
    public GameObject rumSprite;
    public GameObject iceSprite;

    private Dictionary<string, GameObject> ingredientMap;
    private string currentIngredient;

    void Start()
    {
        ingredientMap = new Dictionary<string, GameObject>
        {
            { "Gin", ginSprite },
            { "Whiskey", whiskeySprite },
            { "Rum", rumSprite },
            { "Ice", iceSprite }
        };

        ClearIndicators();
    }

    public void UpdateIndicators(string ingredient)
    {
        if (ingredient == currentIngredient) return;

        if (!string.IsNullOrEmpty(currentIngredient) && ingredientMap.ContainsKey(currentIngredient))
        {
            ingredientMap[currentIngredient].SetActive(false);
        }

        if (ingredientMap.ContainsKey(ingredient))
        {
            ingredientMap[ingredient].SetActive(true);
            currentIngredient = ingredient;
        }
    }

    private void ClearIndicators()
    {
        foreach (var indicator in ingredientMap.Values)
        {
            indicator.SetActive(false);
        }
        currentIngredient = null;
    }
}
