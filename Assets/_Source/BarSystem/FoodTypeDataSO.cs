using UnityEngine;

namespace BarSystem
{
    [CreateAssetMenu(fileName = "FoodTypeData", menuName = "SO/FoodTypeData")]
    public class FoodTypeDataSO : ScriptableObject
    {
        public OrderType OrderType;
        public string FoodName;
        public Sprite Icon;
        public int MiniGameScene;
    }
}