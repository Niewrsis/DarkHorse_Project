using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour
{
    public Image myImage; // Ссылка на изображение
    public float targetOpacity = 1f; // Целевая непрозрачность
    public float fadeDuration = 0.5f; // Длительность перехода

    private float startOpacity;
    private bool isHovering = false;

    void Start()
    {
        // Установите начальную прозрачность
        startOpacity = myImage.color.a;
        myImage.color = new Color(myImage.color.r, myImage.color.g, myImage.color.b, 0); // Начальная прозрачность 0
    }

    void Update()
    {
        // Плавное изменение прозрачности
        Color color = myImage.color;
        if (isHovering)
        {
            color.a = Mathf.MoveTowards(color.a, targetOpacity, Time.deltaTime / fadeDuration);
        }
        else
        {
            color.a = Mathf.MoveTowards(color.a, startOpacity, Time.deltaTime / fadeDuration);
        }
        myImage.color = color;
    }

    public void OnMouseEnter()
    {
        isHovering = true;
    }

    public void OnMouseExit()
    {
        isHovering = false;
    }
}
