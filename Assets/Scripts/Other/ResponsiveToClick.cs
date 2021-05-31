
using UnityEngine;


[RequireComponent(typeof(ActivationAndDeactivationManager))]
[RequireComponent(typeof(Button))]

public class ResponsiveToClick : MonoBehaviour
{
    private ActivationAndDeactivationManager _manager;
    private Button _button;

    private void Awake()
    {
        _manager = GetComponent<ActivationAndDeactivationManager>();
        _button = GetComponent<Button>();
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
