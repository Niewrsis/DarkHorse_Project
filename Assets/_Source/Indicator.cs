using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public SpriteRenderer indicatorRenderer; // ��������� SpriteRenderer ��� ����������
    public Sprite indicator1; // ������ ���������� 1
    public Sprite indicator2; // ������ ���������� 2
    public Image image1; // ������ �����������
    public Image image2; // ������ �����������

    private void Update()
    {
        // �������� fillAmount ����� �����������
        float fillAmount1 = image1.fillAmount;
        float fillAmount2 = image2.fillAmount;

        // ��������� ������� ��� ����������� ���������� 1 ��� 2
        if (fillAmount1 >= 0.78560f && fillAmount1 <= 0.88782f)
        {
            indicatorRenderer.sprite = indicator1; // ������������� ��������� 1
        }
        else
        {
            indicatorRenderer.sprite = indicator2; // ������������� ��������� 2
        }
    }
}
