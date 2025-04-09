using System;

namespace FoodSelection
{
    [Serializable] // ����������� ��������� [Serializable], ����� ����� ����� ���� ���������� � ���������� Unity
    public class FoodGoal : IComparable<FoodGoal> // ��������� IComparable<FoodGoal>
    {
        public FoodType foodName;
        public int requiredAmount;

        public int CompareTo(FoodGoal other)
        {
            if (other == null) return 1; // ��������� null: ������� ������ "������", ��� null

            // ���������� �� foodName.  ����� �������� � ������ ����.
            int nameComparison = foodName.CompareTo(other.foodName);
            if (nameComparison != 0)
            {
                return nameComparison; // foodName ����������, ���������� ��������� �� ���������
            }

            // ���� foodName ���������, ����� ���������� �� requiredAmount (�� �������)
            //return requiredAmount.CompareTo(other.requiredAmount);

            return 0; // foodName �, ��������, ������ ���� �����, ������� �����
        }
        //��������������� Equals and GetHashCode (�����������, �� �������������, �������� ���� FoodGoal ������������ � ����������, ���������� �� ���-��������)
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