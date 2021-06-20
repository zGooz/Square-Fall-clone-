
using UnityEngine;
using UnityEngine.Events;


public class Donor : MonoBehaviour 
{
    public event UnityAction ToSpawnBonus;

    private const int MAX_TICK = 10;

    [SerializeField] private Spawner _spawner;
    [SerializeField, Range(1, MAX_TICK)] private int _tickCount;

    private void OnEnable()
    {
        _spawner.ToGiveSquare += DecrementTicks;
    }

    private void OnDisable()
    {
        _spawner.ToGiveSquare -= DecrementTicks;
    }

    private void DecrementTicks()
    {
        _tickCount -= 1;

        if (_tickCount == 0)
        {
            _tickCount = MAX_TICK;
            ToSpawnBonus?.Invoke();
        }
    }
}
