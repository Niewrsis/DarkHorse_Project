using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FoodSelection
{
    public class Plate : MonoBehaviour, IDropHandler
    {
        public GameManager gameManager; // Ссылка на GameManager

        public Transform foodContainer; // Transform для размещения объектов еды на тарелке.

        private List<FoodGoal> _foodOnPlate = new List<FoodGoal>(); // Список еды на тарелке

        public void OnDrop(PointerEventData eventData)
        {
            DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();

            if (draggableItem != null)
            {
                // Создаем новый экземпляр объекта еды
                GameObject newFood = Instantiate(draggableItem.gameObject, foodContainer);
                //Сразу настраиваем слои и компоненты
                DraggableItem newDraggableItem = newFood.GetComponent<DraggableItem>();
                RectTransform rectTransform = newFood.GetComponent<RectTransform>();
                CanvasGroup canvasGroup = newFood.GetComponent<CanvasGroup>();

                if (newDraggableItem)
                {
                    newDraggableItem.OnEndDrag(eventData); //Чтобы убралась прозрачность
                }

                if (canvasGroup)
                {
                    canvasGroup.blocksRaycasts = true; //Чтобы не блокировать остальную еду
                }

                //Меняем слой для отображения на канвасе.
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
            // Удаляем все объекты еды с тарелки
            foreach (Transform child in foodContainer)
            {
                Destroy(child.gameObject);
            }

            _foodOnPlate.Clear();
            gameManager.CheckWinCondition(_foodOnPlate);
        }
    }
}