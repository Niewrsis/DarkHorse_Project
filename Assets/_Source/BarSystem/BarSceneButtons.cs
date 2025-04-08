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
            SceneChanger.ChangeScene(ConstVar.COCKTAIL_SCREEN_INDEX);
        }
        private void BeerButton()
        {
            SceneChanger.ChangeScene(ConstVar.BEER_SCREEN_INDEX);
        }
        private void SaladButton()
        {
            SceneChanger.ChangeScene(ConstVar.SALAD_SCREEN_INDEX);
        }
    }
}
