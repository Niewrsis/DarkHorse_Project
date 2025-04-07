using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour
{
    public Image myImage; // ������ �� �����������
    public float targetOpacity = 1f; // ������� ��������������
    public float fadeDuration = 0.5f; // ������������ ��������

    private float startOpacity;
    private bool isHovering = false;

    void Start()
    {
        // ���������� ��������� ������������
        startOpacity = myImage.color.a;
        myImage.color = new Color(myImage.color.r, myImage.color.g, myImage.color.b, 0); // ��������� ������������ 0
    }

    void Update()
    {
        // ������� ��������� ������������
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
