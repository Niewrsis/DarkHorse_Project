using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plate : MonoBehaviour, IDropHandler
{
    public GameManager gameManager; // ������ �� GameManager
    private List<string> _foodOnPlate = new List<string>(); // ������ ��� �� �������

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();

        if (draggableItem != null)
        {
            _foodOnPlate.Add(draggableItem.foodName);
            Debug.Log("Added " + draggableItem.foodName + " to plate.");
            gameManager.CheckWinCondition(_foodOnPlate);
        }
    }

    public void ClearPlate()
    {
        _foodOnPlate.Clear();
        gameManager.CheckWinCondition(_foodOnPlate);
        Debug.Log("Plate cleared.");
    }
}