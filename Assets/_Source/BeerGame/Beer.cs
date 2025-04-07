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
        public Button completionButton;
        public Button resetButton;
        public GameObject foamImage;

        private float fillSpeed1 = 1f;
        private float fillSpeed2 = 4f;
        private bool isFilling1 = false;
        private bool isFilling2 = false;

        private float minFillAmount;
        private float maxFillAmount;

        private void Start()
        {
            victoryButton.gameObject.SetActive(false);
            completionButton.onClick.AddListener(OnCompletionButtonClick);
            resetButton.onClick.AddListener(OnResetButtonClick);
            SetRandomRange();
            foamImage.SetActive(false);
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
            UpdateFoam();
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

        private void OnResetButtonClick()
        {
            image2.fillAmount = 0;
            isFilling2 = false;
            victoryButton.gameObject.SetActive(false);
            foamImage.SetActive(false);
        }

        private void UpdateSprites()
        {
            sprite1.SetActive(image2.fillAmount >= minFillAmount && image2.fillAmount <= maxFillAmount);
            sprite2.SetActive(image2.fillAmount < minFillAmount || image2.fillAmount > maxFillAmount);
        }

        private void UpdateFoam()
        {
            if (image2.fillAmount >= 0.065f)
            {
                foamImage.SetActive(true);
                float foamHeight = image2.rectTransform.rect.height * image2.fillAmount;
                foamImage.transform.localPosition = new Vector3(-17, -405f + foamHeight, 0);
            }
            else
            {
                foamImage.SetActive(false);
            }
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
