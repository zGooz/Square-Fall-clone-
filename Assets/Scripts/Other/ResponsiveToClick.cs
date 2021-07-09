
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(ActivationHandler))]
[RequireComponent(typeof(ClickHandler))]

public class ResponsiveToClick : MonoBehaviour
{
    [SerializeField] private float _interval = 1f;

    private ActivationHandler _anctivationHandler;
    private ClickHandler _clickHandler;

    private void Awake()
    {
        _anctivationHandler = GetComponent<ActivationHandler>();
        _clickHandler = GetComponent<ClickHandler>();
    }

    private void OnEnable()
    {
        _clickHandler.Click += ToClick;
    }

    private void OnDisable()
    {
        _clickHandler.Click -= ToClick;
    }

    private void ToClick()
    {
        var sequance = DOTween.Sequence();

        sequance.AppendInterval(_interval)
            .AppendCallback(() => _anctivationHandler.ActivateObjects())
            .AppendCallback(() => _anctivationHandler.DeactivateObjects());
    }
}
