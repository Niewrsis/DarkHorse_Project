using UnityEngine;
using UnityEngine.UI;

public class Beer : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public GameObject sprite1; // ������ ������
    public GameObject sprite2; // ������ ������

    private float fillSpeed1 = 1f;
    private float fillSpeed2 = 10f;
    private bool isFilling1 = false;
    private bool isFilling2 = false;

    private void Update()
    {
        // ���������, ������ �� ������ (��������, ����� ������ ����)
        if (Input.GetMouseButton(0))
        {
            if (!isFilling1)
            {
                isFilling1 = true;
                image1.fillAmount = 0;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isFilling1 = false;
            image1.fillAmount = 0;
            isFilling2 = false;
        }

        // ���������� ������� �����������
        if (isFilling1)
        {
            image1.fillAmount += Time.deltaTime / fillSpeed1;

            if (image1.fillAmount >= 1f)
            {
                isFilling2 = true;
            }
        }

        // ���������� ������� �����������
        if (isFilling2)
        {
            image2.fillAmount += Time.deltaTime / fillSpeed2;

            if (image2.fillAmount >= 1f)
            {
                image2.fillAmount = 1f;
                isFilling2 = false;
            }
        }

        // �������� ��������� fillAmount ��� ������� �����������
        UpdateSprites();
    }

    private void UpdateSprites()
    {
        if (image2.fillAmount >= 0.78560f && image2.fillAmount <= 0.88782f)
        {
            sprite1.SetActive(true); // ���������� ������ ������
            sprite2.SetActive(false); // �������� ������ ������
        }
        else
        {
            sprite1.SetActive(false); // �������� ������ ������
            sprite2.SetActive(true); // ���������� ������ ������
        }
    }
}
