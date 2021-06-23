
using UnityEngine;


[RequireComponent(typeof(ActivationAndDeactivationManager))]

public class TotalScoreBoard : MonoBehaviour
{
    [SerializeField] private Keeper _keeper;
    [SerializeField] private Dock _dock;

    private ActivationAndDeactivationManager _manager;

    private void Awake()
    {
        _manager = GetComponent<ActivationAndDeactivationManager>();
    }

    private void OnEnable()
    {
        _keeper.Fail += DoneGameSession;
    }

    private void OnDisable()
    {
        _keeper.Fail -= DoneGameSession;
    }

    private void DoneGameSession()
    {
        _manager.DeactivateObjects();
        _dock.gameObject.SetActive(true);
    }
}
