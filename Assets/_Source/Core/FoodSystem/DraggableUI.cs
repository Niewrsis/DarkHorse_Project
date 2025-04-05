using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 startPosition;
    private bool isOnPlate = false;
    private Image image;

    public GameObject originalPrefab; // Префаб исходного объекта еды

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startPosition = rectTransform.anchoredPosition;
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isOnPlate)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void ResetPosition()
    {
        rectTransform.anchoredPosition = startPosition;
        isOnPlate = false;
        image.raycastTarget = true; // Включаем возможность перетаскивания
    }

    public void SetOnPlate()
    {
        isOnPlate = true;
        image.raycastTarget = false; // Блокируем перетаскивание
    }

    public bool IsOnPlate()
    {
        return isOnPlate;
    }

    public void CreateNewInstance()
    {
        GameObject newFood = Instantiate(originalPrefab, transform.parent); // Создаем новый экземпляр
        newFood.transform.SetAsLastSibling();
        newFood.GetComponent<RectTransform>().anchoredPosition = startPosition;

        // Дополнительно: Убедитесь, что новый экземпляр добавлен в список draggableFood в GameManager
        FoodTaskCheck gameManager = FindObjectOfType<FoodTaskCheck>();
        if (gameManager != null)
        {
            gameManager.draggableFood.Add(newFood.GetComponent<DraggableUI>());
        }
    }
}
