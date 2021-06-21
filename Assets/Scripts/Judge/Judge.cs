
using UnityEngine;
using UnityEngine.Events;


public class Judge : MonoBehaviour
{
    public event UnityAction NewScore;

    public int Score { get; private set; } = 0;
    public int Best { get; private set; } = 0;

    [SerializeField] private Keeper _keeper;

    private void OnEnable()
    {
        _keeper.Keep += IncrementScore;
    }

    private void OnDisable()
    {
        _keeper.Keep -= IncrementScore;
    }

    private void IncrementScore()
    {
        Score += 1;

        if (Score > Best)
        {
            Best = Score;
        }

        NewScore?.Invoke();
    }
}
