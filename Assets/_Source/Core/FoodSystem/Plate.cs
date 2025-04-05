using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plate : MonoBehaviour, IDropHandler
{
    public GameManager gameManager; // ������ �� GameManager

    public Transform foodContainer; // Transform ��� ���������� �������� ��� �� �������.

    private List<string> _foodOnPlate = new List<string>(); // ������ ��� �� �������

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
            Debug.Log("Added " + draggableItem.foodName + " to plate.");
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
        Debug.Log("Plate cleared.");
    }
}