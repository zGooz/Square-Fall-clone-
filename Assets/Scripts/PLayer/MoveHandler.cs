
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(ClickHandler))]

public class MoveHandler : MonoBehaviour
{
    private ClickHandler _panel;
    public event UnityAction Reverce;

    private void Awake()
    {
        _panel = GetComponent<ClickHandler>();
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
