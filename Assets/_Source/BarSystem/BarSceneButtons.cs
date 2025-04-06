using SceneSystem;
using UnityEngine;
using UnityEngine.UI;

namespace BarSystem
{
    public class BarSceneButtons : MonoBehaviour
    {
        [SerializeField] private Button cocktailButton;
        [SerializeField] private Button beerButton;
        [SerializeField] private Button saladButton;

        private void Start()
        {
            cocktailButton.onClick.AddListener(CocktailButton);
            beerButton.onClick.AddListener(BeerButton);
            saladButton.onClick.AddListener(SaladButton);
        }
        private void CocktailButton()
        {
            SceneChanger.ChangeScene(1);
        }
        private void BeerButton()
        {
            SceneChanger.ChangeScene(2);
        }
        private void SaladButton()
        {
            SceneChanger.ChangeScene(3);
        }
    }
}
