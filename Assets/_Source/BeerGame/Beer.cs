using UnityEngine;
using UnityEngine.UI;

namespace BeerSystem
{
    public class Beer : MonoBehaviour
    {
        public Image image1;
        public Image image2;
        public GameObject sprite1; // Для отображения победного состояния
        public GameObject sprite2; // Для отображения обычного состояния
        public Button victoryButton;
        public Button completionButton;

        private float fillSpeed1 = 1f;
        private float fillSpeed2 = 10f;
        private bool isFilling1 = false;
        private bool isFilling2 = false;

        private float minFillAmount;
        private float maxFillAmount;

        private void Start()
        {
            victoryButton.gameObject.SetActive(false);
            completionButton.onClick.AddListener(OnCompletionButtonClick);
            SetRandomRange(); // Устанавливаем случайный диапазон
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
            if (!isFilling1)
            {
                isFilling1 = true;
                image1.fillAmount = 0;
            }
            else
            {
                isFilling1 = false;
                image1.fillAmount = 0;
                isFilling2 = false;
            }
        }

        public void OnPointerDown()
        {
            if (!isFilling1)
            {
                isFilling1 = true;
                image1.fillAmount = 0;
            }
        }

        public void OnPointerUp()
        {
            isFilling1 = false;
            image1.fillAmount = 0;
            isFilling2 = false;
        }

        private void UpdateSprites()
        {
            // Убираем индикатор, добавляем новый для минимума и максимума
            sprite1.SetActive(image2.fillAmount >= minFillAmount && image2.fillAmount <= maxFillAmount);
            sprite2.SetActive(image2.fillAmount < minFillAmount || image2.fillAmount > maxFillAmount);
        }

        private void CheckVictoryCondition()
        {
            if (image2.fillAmount >= minFillAmount && image2.fillAmount <= maxFillAmount)
            {
                victoryButton.gameObject.SetActive(true);
            }
            else
            {
                victoryButton.gameObject.SetActive(false);
            }
        }

        private void SetRandomRange()
        {
            // Определяем случайный диапазон
            float[][] ranges = {
                new float[] { 0.78560f, 0.88782f },
                new float[] { 0.211f, 0.301f },
                new float[] { 0.52f, 0.641f },
                new float[] { 0.926f, 1f }
            };

            int randomIndex = Random.Range(0, ranges.Length);
            minFillAmount = ranges[randomIndex][0];
            maxFillAmount = ranges[randomIndex][1];
        }
    }
}
