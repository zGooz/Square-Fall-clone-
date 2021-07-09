
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(ClickHandler))]

public class ProgramCloser : MonoBehaviour
{
    [SerializeField] private float _interval = 1f;

    private ClickHandler _handler;

    private void Awake()
    {
        _handler = GetComponent<ClickHandler>();
    }

    private void OnEnable()
    {
        _handler.Click += OnGameClose;
    }

    private void OnDisable()
    {
        _handler.Click -= OnGameClose;
    }

    private void OnGameClose()
    {
        Debug.Log("Game end");

        DOTween.Sequence().AppendInterval(_interval)
            .AppendCallback(() => Application.Quit());
    }
}
