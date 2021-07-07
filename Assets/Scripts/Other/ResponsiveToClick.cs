
using UnityEngine;


[RequireComponent(typeof(ActivationAndDeactivationManager))]
[RequireComponent(typeof(ClickHandler))]

public class ResponsiveToClick : MonoBehaviour
{
    private ActivationAndDeactivationManager _manager;
    private ClickHandler _button;

    private void Awake()
    {
        _manager = GetComponent<ActivationAndDeactivationManager>();
        _button = GetComponent<ClickHandler>();
    }

    private void OnEnable()
    {
        _button.Click += ToClick;
    }

    private void OnDisable()
    {
        _button.Click -= ToClick;
    }

    private void ToClick()
    {
        _manager.ActivateObjects();
        _manager.DeactivateObjects();
    }
}
