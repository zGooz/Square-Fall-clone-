
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Spawner : MonoBehaviour
{
    public event UnityAction ToGiveSquare;
    public float Delay { get; set; } = 1.5f;

    [SerializeField] private Donor _donor;
    [SerializeField] private GameObject _square;

    private Transform _transform;
    private GameObject _instance;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _donor.ToGiveBonus += CreateBonus;
        StopCoroutine(SpawnProcess());
        StartCoroutine(SpawnProcess());
    }

    private void OnDisable()
    {
        _donor.ToGiveBonus -= CreateBonus;
        StopCoroutine(SpawnProcess());
    }

    private IEnumerator SpawnProcess()
    {
        yield return new WaitForSeconds(Delay);
        Spawn();
        StartCoroutine(SpawnProcess());
    }

    private void CreateBonus()
    {
        _instance.AddComponent<Bonus>();
    }

    private void Spawn()
    {
        ToGiveSquare?.Invoke();
        _instance = Instantiate(_square, _transform);
    }
}
