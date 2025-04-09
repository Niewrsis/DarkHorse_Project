using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FoodSelection
{
    public class Plate : MonoBehaviour, IDropHandler
    {
        public GameManager gameManager; // ������ �� GameManager

        public Transform foodContainer; // Transform ��� ���������� �������� ��� �� �������.

        private List<FoodGoal> _foodOnPlate = new List<FoodGoal>(); // ������ ��� �� �������

        public void OnDrop(PointerEventData eventData)
        {
            DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();

            if (draggableItem != null)
            {
                // ������� ����� ��������� ������� ���
                GameObject newFood = Instantiate(draggableItem.gameObject, foodContainer);
                //����� ����������� ���� � ����������
                DraggableItem newDraggableItem = newFood.GetComponent<DraggableItem>();
                RectTransform rectTransform = newFood.GetComponent<RectTransform>();
                CanvasGroup canvasGroup = newFood.GetComponent<CanvasGroup>();

                if (newDraggableItem)
                {
                    newDraggableItem.OnEndDrag(eventData); //����� �������� ������������
                }

                if (canvasGroup)
                {
                    canvasGroup.blocksRaycasts = true; //����� �� ����������� ��������� ���
                }

                //������ ���� ��� ����������� �� �������.
                rectTransform.SetParent(foodContainer);
                newFood.layer = LayerMask.NameToLayer("UI");
                newFood.transform.localScale = Vector3.one;
                _foodOnPlate.Add(draggableItem.foodName);
                canvasGroup.blocksRaycasts = false;
                gameManager.CheckWinCondition(_foodOnPlate);
            }
        }

        public void ClearPlate()
        {
            // ������� ��� ������� ��� � �������
            foreach (Transform child in foodContainer)
            {
                Destroy(child.gameObject);
            }

            _foodOnPlate.Clear();
            gameManager.CheckWinCondition(_foodOnPlate);
        }
    }
}