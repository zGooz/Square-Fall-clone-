
using UnityEngine;


[RequireComponent(typeof(ActivationHandler))]
[RequireComponent(typeof(ClickHandler))]

public class ResponsiveToClick : MonoBehaviour
{
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
        _anctivationHandler.ActivateObjects();
        _anctivationHandler.DeactivateObjects();
    }
}
