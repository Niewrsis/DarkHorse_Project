using BarSystem;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private Button _button;

    private OrdersView _ordersView;

    private void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(Test1);

        _ordersView = FindFirstObjectByType<OrdersView>();
    }

    private void Test1()
    {
        //_ordersView.EventHandler.OnComplete?.Invoke();
    }

}
