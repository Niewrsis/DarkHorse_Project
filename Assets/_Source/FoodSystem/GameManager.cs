using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro; // Обязательно добавьте этот using для TextMeshPro

namespace FoodSelection
{
    public class GameManager : MonoBehaviour
    {
        public FoodGoal[] winConditions; // Массив условий для победы
        public Image winIndicator; // Галочка, которую нужно активировать при победе
        public Plate plate; // Ссылка на скрипт Plate
        public TextMeshProUGUI taskText; // Ссылка на TextMeshPro UI элемент

        void Start()
        {
            winIndicator.gameObject.SetActive(false); // Скрываем галочку в начале
            UpdateTaskText(); // Обновляем текст задания при старте игры
        }

        private void UpdateTaskText()
        {
            string task = "\n";
            foreach (FoodGoal goal in winConditions)
            {
                task += $"{goal.requiredAmount} {goal.foodName}\n";
            }
            taskText.text = task;
        }

        public void CheckWinCondition(List<string> foodOnPlate)
        {
            bool win = true;

            // 1. Проверка, что все необходимые ингредиенты присутствуют в нужном количестве.
            foreach (FoodGoal goal in winConditions)
            {
                int count = foodOnPlate.Count(food => food == goal.foodName); // Используем Linq для подсчета
                if (count != goal.requiredAmount) // Строгое соответствие
                {
                    win = false;
                    break;
                }
            }

            // 2. Проверка на наличие лишних ингредиентов.
            if (win) // Если предыдущая проверка прошла успешно
            {
                // Создаем список ожидаемых ингредиентов
                List<string> expectedFood = new List<string>();
                foreach (FoodGoal goal in winConditions)
                {
                    for (int i = 0; i < goal.requiredAmount; i++)
                    {
                        expectedFood.Add(goal.foodName);
                    }
                }

                // Сортируем оба списка для корректного сравнения
                foodOnPlate.Sort();
                expectedFood.Sort();

                // Сравниваем списки
                if (!foodOnPlate.SequenceEqual(expectedFood)) // Используем Linq для сравнения последовательностей
                {
                    win = false; // Если есть разница в списках (лишние ингредиенты), победа не засчитывается
                }
            }

            winIndicator.gameObject.SetActive(win);
        }

        public void ClearPlate()
        {
            plate.ClearPlate();
        }
    }
}