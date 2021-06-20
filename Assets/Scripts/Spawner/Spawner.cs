
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Spawner : MonoBehaviour
{
    public event UnityAction ToGiveSquare;

    [SerializeField] private float _delay = 0.7f;
    [SerializeField] private Donor _donor;
    [SerializeField] private GameObject _square;
    [SerializeField, Range(0, 2)] private float _offset;

    private Transform _transform;
    private GameObject _instance;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        StopCoroutine(SpawnProcess());
        StartCoroutine(SpawnProcess());
        _donor.ToSpawnBonus += CreateBonus;
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnProcess());
        _donor.ToSpawnBonus -= CreateBonus;
    }

    private IEnumerator SpawnProcess()
    {
        yield return new WaitForSeconds(_delay);

        Spawn();
        StartCoroutine(SpawnProcess());
    }

    private void CreateBonus()
    {
        if (_instance != null)
        {
            _instance.AddComponent<Bonus>();
        }
    }

    private void Spawn()
    {
        var x = _offset * Random.Range(-1, 1);
        var position = _transform.position + new Vector3(x, 0, 0);

        _instance = Instantiate(_square, position, Quaternion.identity, _transform);
        ToGiveSquare?.Invoke();
    }
}
