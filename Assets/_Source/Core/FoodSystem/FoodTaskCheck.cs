using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class FoodTaskCheck : MonoBehaviour
{
    public PlateUI plate; // Ссылка на компонент PlateUI на тарелке
    public GameObject checkmark; // Ссылка на GameObject галочки
    public List<DraggableUI> draggableFood = new List<DraggableUI>(); // Список всех объектов еды

    [System.Serializable]
    public class FoodRequirement
    {
        public string foodName;
        public int requiredAmount;
    }

    public List<FoodRequirement> requiredFood = new List<FoodRequirement>(); // Список нужных ингредиентов и их количества

    void Start()
    {
        checkmark.SetActive(false); // Скрываем галочку в начале игры
        //  Создаем начальные экземпляры еды
        foreach (DraggableUI food in draggableFood)
        {
            food.originalPrefab = food.gameObject; // Устанавливаем originalPrefab
        }
    }

    void Update()
    {
        // Обновляем список еды на тарелке каждый кадр (или с определенным интервалом для оптимизации)
        UpdateFoodOnPlate();

        if (CheckIfTaskCompleted())
        {
            checkmark.SetActive(true); // Показываем галочку
        }
        else
        {
            checkmark.SetActive(false); // Скрываем галочку, если условие больше не выполняется
        }
    }

    // Обновляем список еды на тарелке
    private void UpdateFoodOnPlate()
    {
        plate.foodOnPlate.Clear();
        foreach (DraggableUI food in draggableFood)
        {
            if (plate.IsFoodOnPlate(food.GetComponent<RectTransform>()) && !food.IsOnPlate())
            {
                plate.AddFood(food.gameObject.name);
                food.SetOnPlate();
                food.CreateNewInstance(); // Создаем новый экземпляр после помещения на тарелку
            }
        }
    }


    // Метод для проверки выполнения задания
    public bool CheckIfTaskCompleted()
    {
        // Создаем словарь для подсчета количества каждого типа еды на тарелке
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

        // Проверяем, выполнены ли все требования
        foreach (FoodRequirement requirement in requiredFood)
        {
            if (!foodCounts.ContainsKey(requirement.foodName) || foodCounts[requirement.foodName] < requirement.requiredAmount)
            {
                return false; // Если хоть одно требование не выполнено, возвращаем false
            }
        }

        return true; // Если все требования выполнены, возвращаем true
    }

    // Функция для сброса тарелки
    public void ResetPlate()
    {
        plate.foodOnPlate.Clear();
        foreach (DraggableUI food in draggableFood)
        {
            food.ResetPosition();
        }
    }
}