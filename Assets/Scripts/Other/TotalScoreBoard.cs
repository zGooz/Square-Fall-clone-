
using UnityEngine;


[RequireComponent(typeof(ActivationHandler))]

public class TotalScoreBoard : MonoBehaviour
{
    [SerializeField] private Keeper _keeper;
    [SerializeField] private Dock _dock;

    private ActivationHandler _activationHandler;

    private void Awake()
    {
        _activationHandler = GetComponent<ActivationHandler>();
    }

    private void OnEnable()
    {
        _keeper.FaceObstacle += DoneGameSession;
    }

    private void OnDisable()
    {
        _keeper.FaceObstacle -= DoneGameSession;
    }

    private void DoneGameSession()
    {
        _activationHandler.DeactivateObjects();
        _dock.gameObject.SetActive(true);
    }
}
