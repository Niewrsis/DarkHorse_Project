using System.Collections.Generic;
using TimerSystem;
using UnityEngine;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> clientSprites;
    [SerializeField] private Image clientImage;
    [SerializeField] private GameObject hiddenImage;

    private ClientTimer _clientTimer;

    private Sprite _currentClient;

    private void Start()
    {
        _clientTimer = FindFirstObjectByType<ClientTimer>();
        ChangeClient();

        hiddenImage.SetActive(false);
    }

    public void ChangeClient()
    {
        if(_clientTimer.IsNewClient)
        {
            int randomIndex = Random.Range(0, clientSprites.Count);
            clientImage.sprite = clientSprites[randomIndex];
            _clientTimer.CurrentSprite = clientImage.sprite;
        }
        else
        {
            Debug.Log(_clientTimer.CurrentSprite.name);
            clientImage.sprite = _clientTimer.CurrentSprite;
        }
        hiddenImage.SetActive(false);
        _clientTimer.IsNewClient = false;
        clientImage.gameObject.SetActive(true);
    }
    public Sprite GetCurrentSprite()
    {
        return _currentClient;
    }

    public void ShowHiddenImage()
    {
        hiddenImage.SetActive(true);
    }

    public void HideClient()
    {
        clientImage.gameObject.SetActive(false);
    }
}
