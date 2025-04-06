using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro; // ����������� �������� ���� using ��� TextMeshPro

namespace FoodSelection
{
    public class GameManager : MonoBehaviour
    {
        public FoodGoal[] winConditions; // ������ ������� ��� ������
        public Image winIndicator; // �������, ������� ����� ������������ ��� ������
        public Plate plate; // ������ �� ������ Plate
        public TextMeshProUGUI taskText; // ������ �� TextMeshPro UI �������

        void Start()
        {
            winIndicator.gameObject.SetActive(false); // �������� ������� � ������
            UpdateTaskText(); // ��������� ����� ������� ��� ������ ����
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

            // 1. ��������, ��� ��� ����������� ����������� ������������ � ������ ����������.
            foreach (FoodGoal goal in winConditions)
            {
                int count = foodOnPlate.Count(food => food == goal.foodName); // ���������� Linq ��� ��������
                if (count != goal.requiredAmount) // ������� ������������
                {
                    win = false;
                    break;
                }
            }

            // 2. �������� �� ������� ������ ������������.
            if (win) // ���� ���������� �������� ������ �������
            {
                // ������� ������ ��������� ������������
                List<string> expectedFood = new List<string>();
                foreach (FoodGoal goal in winConditions)
                {
                    for (int i = 0; i < goal.requiredAmount; i++)
                    {
                        expectedFood.Add(goal.foodName);
                    }
                }

                // ��������� ��� ������ ��� ����������� ���������
                foodOnPlate.Sort();
                expectedFood.Sort();

                // ���������� ������
                if (!foodOnPlate.SequenceEqual(expectedFood)) // ���������� Linq ��� ��������� �������������������
                {
                    win = false; // ���� ���� ������� � ������� (������ �����������), ������ �� �������������
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