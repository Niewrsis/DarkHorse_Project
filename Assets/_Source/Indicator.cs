using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public SpriteRenderer indicatorRenderer;
    public Sprite indicator1;
    public Sprite indicator2;
    public Image image1;
    public Image image2;

    private void Update()
    {
        float fillAmount1 = image1.fillAmount;
        float fillAmount2 = image2.fillAmount;

        if (fillAmount1 >= 0.78560f && fillAmount1 <= 0.88782f)
        {
            indicatorRenderer.sprite = indicator1;
        }
        else
        {
            indicatorRenderer.sprite = indicator2;
        }
    }
}
