
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Button))]

public class Handler : MonoBehaviour
{
    private Button _panel;
    public event UnityAction Reverce;

    private void Awake()
    {
        _panel = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _panel.Click += RevercePlayer;
    }

    private void OnDisable()
    {
        _panel.Click -= RevercePlayer;
    }

    private void RevercePlayer()
    {
        Reverce?.Invoke();
    }
}
