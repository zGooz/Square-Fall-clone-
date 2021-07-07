
using UnityEngine;


[RequireComponent(typeof(ActivationAndDeactivationManager))]
[RequireComponent(typeof(ClickHandler))]

public class ResponsiveToClick : MonoBehaviour
{
    private ActivationAndDeactivationManager _manager;
    private ClickHandler _clickHandler;

    private void Awake()
    {
        _manager = GetComponent<ActivationAndDeactivationManager>();
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
        _manager.ActivateObjects();
        _manager.DeactivateObjects();
    }
}
