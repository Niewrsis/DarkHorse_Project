using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public FoodGoal[] winConditions; // ������ ������� ��� ������
    public Image winIndicator; // �������, ������� ����� ������������ ��� ������
    public Plate plate; // ������ �� ������ Plate

    void Start()
    {
        winIndicator.gameObject.SetActive(false); // �������� ������� � ������
    }

    public void CheckWinCondition(List<string> foodOnPlate)
    {
        bool win = true;

        foreach (FoodGoal goal in winConditions)
        {
            int count = 0;
            foreach (string food in foodOnPlate)
            {
                if (food == goal.foodName)
                {
                    count++;
                }
            }

            if (count < goal.requiredAmount)
            {
                win = false;
                break;
            }
        }

        winIndicator.gameObject.SetActive(win);
    }

    public void ClearPlate()
    {
        plate.ClearPlate();
    }
}