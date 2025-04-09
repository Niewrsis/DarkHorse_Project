using System;

namespace FoodSelection
{
    [Serializable] // Обязательно добавляем [Serializable], чтобы класс можно было отобразить в инспекторе Unity
    public class FoodGoal : IComparable<FoodGoal> // Реализуем IComparable<FoodGoal>
    {
        public FoodType foodName;
        public int requiredAmount;

        public int CompareTo(FoodGoal other)
        {
            if (other == null) return 1; // Обработка null: текущий объект "больше", чем null

            // Сравниваем по foodName.  Можно добавить и другие поля.
            int nameComparison = foodName.CompareTo(other.foodName);
            if (nameComparison != 0)
            {
                return nameComparison; // foodName отличаются, возвращаем результат их сравнения
            }

            // Если foodName одинаковы, можно сравнивать по requiredAmount (по желанию)
            //return requiredAmount.CompareTo(other.requiredAmount);

            return 0; // foodName и, возможно, другие поля равны, объекты равны
        }
        //Переопределение Equals and GetHashCode (опционально, но рекомендуется, особенно если FoodGoal используется в коллекциях, основанных на хеш-таблицах)
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            FoodGoal other = (FoodGoal)obj;
            return foodName == other.foodName && requiredAmount == other.requiredAmount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(foodName, requiredAmount);
        }
    }
}