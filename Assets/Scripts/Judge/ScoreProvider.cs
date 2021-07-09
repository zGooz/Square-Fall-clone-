
using UnityEngine;
using UnityEngine.Events;


public class ScoreProvider : MonoBehaviour
{
    public event UnityAction NewScore;

    public int Score { get; private set; } = 0;
    public int Best { get; private set; } = 0;

    [SerializeField] private Keeper _keeper;

    private void OnEnable()
    {
        _keeper.PickUpBonusComplete += IncrementScore;
        _keeper.FaceObstacleComplete += ResetScore;
    }

    private void OnDisable()
    {
        _keeper.PickUpBonusComplete -= IncrementScore;
        _keeper.FaceObstacleComplete -= ResetScore;
    }

    private void IncrementScore()
    {
        Score += 1;
        Best = Mathf.Max(Score, Best);
        NewScore?.Invoke();
    }

    private void ResetScore()
    {
        Score = 0;
        NewScore?.Invoke();
    }
}
