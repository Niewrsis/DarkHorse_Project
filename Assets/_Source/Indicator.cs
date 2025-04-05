using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public SpriteRenderer indicatorRenderer; // Компонент SpriteRenderer для индикатора
    public Sprite indicator1; // Спрайт индикатора 1
    public Sprite indicator2; // Спрайт индикатора 2
    public Image image1; // Первое изображение
    public Image image2; // Второе изображение

    private void Update()
    {
        // Получаем fillAmount обоих изображений
        float fillAmount1 = image1.fillAmount;
        float fillAmount2 = image2.fillAmount;

        // Проверяем условие для отображения индикатора 1 или 2
        if (fillAmount1 >= 0.78560f && fillAmount1 <= 0.88782f)
        {
            indicatorRenderer.sprite = indicator1; // Устанавливаем индикатор 1
        }
        else
        {
            indicatorRenderer.sprite = indicator2; // Устанавливаем индикатор 2
        }
    }
}
