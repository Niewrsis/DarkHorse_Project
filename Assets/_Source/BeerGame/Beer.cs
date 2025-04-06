using UnityEngine;
using UnityEngine.UI;

namespace BeerSystem
{
    public class Beer : MonoBehaviour
    {
        public Image image1;
        public Image image2;
        public GameObject sprite1;
        public GameObject sprite2;
        public Button victoryButton;
        public Button CompletionButton;

        private float fillSpeed1 = 1f;
        private float fillSpeed2 = 10f;
        private bool isFilling1 = false;
        private bool isFilling2 = false;

        private void Start()
        {
            victoryButton.gameObject.SetActive(false);
            CompletionButton.onClick.AddListener(OnCompletionButtonClick);
        }

        private void Update()
        {
            if (isFilling1)
            {
                image1.fillAmount += Time.deltaTime / fillSpeed1;

                if (image1.fillAmount >= 1f)
                {
                    isFilling2 = true;
                }
            }

            if (isFilling2)
            {
                image2.fillAmount += Time.deltaTime / fillSpeed2;

                if (image2.fillAmount >= 1f)
                {
                    image2.fillAmount = 1f;
                    isFilling2 = false;
                }
            }

            UpdateSprites();
            CheckVictoryCondition();
        }

        public void OnCompletionButtonClick()
        {
            // Начинаем заполнение, если кнопка нажата
            if (!isFilling1)
            {
                isFilling1 = true;
                image1.fillAmount = 0;
            }
            else
            {
                // Если кнопка была нажата повторно, останавливаем заполнение
                isFilling1 = false;
                image1.fillAmount = 0;
                isFilling2 = false;
            }
        }

        public void OnPointerDown()
        {
            // Начинаем заполнение при удерживании кнопки
            if (!isFilling1)
            {
                isFilling1 = true;
                image1.fillAmount = 0;
            }
        }

        public void OnPointerUp()
        {
            // Останавливаем заполнение при отпускании кнопки
            isFilling1 = false;
            image1.fillAmount = 0;
            isFilling2 = false;
        }

        private void UpdateSprites()
        {
            if (image2.fillAmount >= 0.78560f && image2.fillAmount <= 0.88782f)
            {
                sprite1.SetActive(true);
                sprite2.SetActive(false);
            }
            else
            {
                sprite1.SetActive(false);
                sprite2.SetActive(true);
            }
        }

        private void CheckVictoryCondition()
        {
            if (image2.fillAmount >= 0.78560f && image2.fillAmount <= 0.88782f)
            {
                victoryButton.gameObject.SetActive(true);
            }
            else
            {
                victoryButton.gameObject.SetActive(false);
            }
        }
    }
}