using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System;

namespace FoodSelection
{
    public class GameManager : MonoBehaviour
    {
        public List<FoodGoal> winConditions;
        public Image winIndicator;
        public Plate plate;
        public TextMeshProUGUI taskText;

        private System.Random _rnd = new System.Random();

        void Start()
        {

            winConditions = new List<FoodGoal>();

            FoodGoal food = new FoodGoal();
            FoodGoal food1 = new FoodGoal();
            FoodGoal food2 = new FoodGoal();
            FoodGoal food3 = new FoodGoal();

            food.foodName = FoodType.Salad;
            food.requiredAmount = _rnd.Next(1, 4);
            winConditions.Add(food);

            food1.foodName = FoodType.Tomato;
            food1.requiredAmount = _rnd.Next(0, 4);
            winConditions.Add(food1);

            food2.foodName = FoodType.Cheese;
            food2.requiredAmount = _rnd.Next(0, 4);
            winConditions.Add(food2);

            food3.foodName = FoodType.Chicken;
            food3.requiredAmount = _rnd.Next(0, 4);
            winConditions.Add(food3);

                
            winIndicator.gameObject.SetActive(false);
            UpdateTaskText();
        }

        private void UpdateTaskText()
        {
            string task = "";
            foreach (FoodGoal goal in winConditions)
            {
                if(goal.requiredAmount != 0)
                {
                    task += $"{goal.requiredAmount} {Enum.GetName(typeof(FoodType), goal.foodName)}\n";
                }
            }
            taskText.text = task;
        }

        public void CheckWinCondition(List<FoodGoal> foodOnPlate)
        {
            var groupedFood = foodOnPlate.GroupBy(x => x.foodName)
                .Select(group => new { FoodType = group.Key, Count = group.Count() })
                .ToDictionary(x => x.FoodType, x => x.Count);

            List<FoodGoal> list = new List<FoodGoal>();

            foreach (FoodGoal winCondition in winConditions)
            {
                FoodGoal food = new FoodGoal();
                food.foodName = winCondition.foodName;

                if (groupedFood.ContainsKey(winCondition.foodName))
                {
                    food.requiredAmount = groupedFood[winCondition.foodName];
                }
                else
                {
                    food.requiredAmount = 0;
                }
                list.Add(food);
            }

            winConditions.Sort();
            list.Sort();

            bool win = winConditions.SequenceEqual(list);

            winIndicator.gameObject.SetActive(win);
        }

        public void ClearPlate()
        {
            plate.ClearPlate();
        }
    }
}