using System.Collections.Generic;
using UnityEngine;

public class PlateUI : MonoBehaviour
{
    public List<string> foodOnPlate = new List<string>();
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Debug.Log("PlateUI Start: " + gameObject.name); // Проверяем, что Start вызывается
    }

    public void AddFood(string foodName)
    {
        foodOnPlate.Add(foodName);
        Debug.Log("Added " + foodName + " to plate.");
    }

    public void RemoveFood(string foodName)
    {
        foodOnPlate.Remove(foodName);
        Debug.Log("Removed " + foodName + " from plate.");
    }

    public bool IsFoodOnPlate(RectTransform foodRectTransform)
    {
        Vector3[] corners = new Vector3[4];
        foodRectTransform.GetWorldCorners(corners);

        // Проверяем, находится ли хотя бы один угол еды внутри RectTransform тарелки.
        foreach (Vector3 corner in corners)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, corner, Camera.main))
            {
                return true;
            }
        }
        return false;
    }

}