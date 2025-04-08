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

        public GameObject ginSprite;
        public GameObject whiskeySprite;
        public GameObject rumSprite;
        public GameObject iceSprite;

        private GameObject currentSprite;

        void Start()
        {
            ginButton.onClick.AddListener(() => ShowSprite(ginSprite));
            whiskeyButton.onClick.AddListener(() => ShowSprite(whiskeySprite));
            rumButton.onClick.AddListener(() => ShowSprite(rumSprite));
            iceButton.onClick.AddListener(() => ShowSprite(iceSprite));
        }

        void ShowSprite(GameObject spriteToShow)
        {
            if (currentSprite != null)
            {
                currentSprite.SetActive(false);
            }

            currentSprite = spriteToShow;
            currentSprite.SetActive(true);
        }
    }
}
