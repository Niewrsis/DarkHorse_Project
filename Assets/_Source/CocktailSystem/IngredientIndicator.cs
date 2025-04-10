using UnityEngine;
using UnityEngine.UI;

namespace CocktailSystem
{
    public class SpriteManager : MonoBehaviour
    {
        public Button ginButton;
        public Button whiskeyButton;
        public Button rumButton;
        public Button iceButton;
        public Button mixButton;

        public GameObject ginSprite;
        public GameObject whiskeySprite;
        public GameObject rumSprite;
        public GameObject iceSprite;

        private GameObject currentSprite;
        private GameObject lastSprite;

        void Start()
        {
            ginButton.onClick.AddListener(() => ShowSprite(ginSprite));
            whiskeyButton.onClick.AddListener(() => ShowSprite(whiskeySprite));
            rumButton.onClick.AddListener(() => ShowSprite(rumSprite));
            iceButton.onClick.AddListener(() => ShowSprite(iceSprite));
            mixButton.onClick.AddListener(HideAllSprites);
        }

        void ShowSprite(GameObject spriteToShow)
        {
            if (currentSprite != null)
            {
                lastSprite = currentSprite;
                currentSprite.SetActive(false);
            }

            currentSprite = spriteToShow;
            currentSprite.SetActive(true);
        }

        void HideAllSprites()
        {
            ginSprite.SetActive(false);
            whiskeySprite.SetActive(false);
            rumSprite.SetActive(false);
            iceSprite.SetActive(false);

            if (lastSprite == iceSprite)
            {
                if (currentSprite != null && currentSprite != iceSprite)
                {
                    currentSprite.SetActive(true);
                }
            }

            currentSprite = null;
            lastSprite = null;
        }
    }
}
