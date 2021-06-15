
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Donor : MonoBehaviour 
{
    public event UnityAction ToGiveBonus;

    [SerializeField] private Spawner _spawner;
    [SerializeField, Min(1)] private int _tickCount;
    private float _time;

    private void Awake()
    {
        _time = _spawner.Delay * _tickCount;
    }

    private void OnEnable()
    {
        StopCoroutine(Alarm());
        StartCoroutine(Alarm());
    }

    private void OnDisable()
    {
        StopCoroutine(Alarm());
    }

    private IEnumerator Alarm()
    {
        yield return new WaitForSeconds(_time);
        ToGiveBonus?.Invoke();
        StartCoroutine(Alarm());
    }
}
