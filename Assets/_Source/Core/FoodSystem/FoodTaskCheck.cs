using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class FoodTaskCheck : MonoBehaviour
{
    public PlateUI plate; // ������ �� ��������� PlateUI �� �������
    public GameObject checkmark; // ������ �� GameObject �������
    public List<DraggableUI> draggableFood = new List<DraggableUI>(); // ������ ���� �������� ���

    [System.Serializable]
    public class FoodRequirement
    {
        public string foodName;
        public int requiredAmount;
    }

    public List<FoodRequirement> requiredFood = new List<FoodRequirement>(); // ������ ������ ������������ � �� ����������

    void Start()
    {
        checkmark.SetActive(false); // �������� ������� � ������ ����
        //  ������� ��������� ���������� ���
        foreach (DraggableUI food in draggableFood)
        {
            food.originalPrefab = food.gameObject; // ������������� originalPrefab
        }
    }

    void Update()
    {
        // ��������� ������ ��� �� ������� ������ ���� (��� � ������������ ���������� ��� �����������)
        UpdateFoodOnPlate();

        if (CheckIfTaskCompleted())
        {
            checkmark.SetActive(true); // ���������� �������
        }
        else
        {
            checkmark.SetActive(false); // �������� �������, ���� ������� ������ �� �����������
        }
    }

    // ��������� ������ ��� �� �������
    private void UpdateFoodOnPlate()
    {
        plate.foodOnPlate.Clear();
        foreach (DraggableUI food in draggableFood)
        {
            if (plate.IsFoodOnPlate(food.GetComponent<RectTransform>()) && !food.IsOnPlate())
            {
                plate.AddFood(food.gameObject.name);
                food.SetOnPlate();
                food.CreateNewInstance(); // ������� ����� ��������� ����� ��������� �� �������
            }
        }
    }


    // ����� ��� �������� ���������� �������
    public bool CheckIfTaskCompleted()
    {
        // ������� ������� ��� �������� ���������� ������� ���� ��� �� �������
        Dictionary<string, int> foodCounts = new Dictionary<string, int>();
        foreach (string food in plate.foodOnPlate)
        {
            if (foodCounts.ContainsKey(food))
            {
                foodCounts[food]++;
            }
            else
            {
                foodCounts[food] = 1;
            }
        }

        // ���������, ��������� �� ��� ����������
        foreach (FoodRequirement requirement in requiredFood)
        {
            if (!foodCounts.ContainsKey(requirement.foodName) || foodCounts[requirement.foodName] < requirement.requiredAmount)
            {
                return false; // ���� ���� ���� ���������� �� ���������, ���������� false
            }
        }

        return true; // ���� ��� ���������� ���������, ���������� true
    }

    // ������� ��� ������ �������
    public void ResetPlate()
    {
        plate.foodOnPlate.Clear();
        foreach (DraggableUI food in draggableFood)
        {
            food.ResetPosition();
        }
    }
}