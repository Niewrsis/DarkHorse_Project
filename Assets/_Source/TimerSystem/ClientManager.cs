using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> clientSprites;
    [SerializeField] private Image clientImage;
    [SerializeField] private GameObject hiddenImage;

    private void Start()
    {
        ChangeClient();
        hiddenImage.SetActive(false);
    }

    public void ChangeClient()
    {
        int randomIndex = Random.Range(0, clientSprites.Count);
        clientImage.sprite = clientSprites[randomIndex];
    }

    public void ShowHiddenImage()
    {
        hiddenImage.SetActive(true);
    }
}
