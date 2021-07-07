
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Spawner : MonoBehaviour
{
    public event UnityAction ToGiveSquare;

    [SerializeField] private float _delay = 0.65f;
    [SerializeField] private BonusProvider _provider;
    [SerializeField] private GameObject _square;
    [SerializeField, Range(0, 0.8f)] private float _offset = 0.8f;
    [SerializeField] private Keeper _keeper;

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
        _provider.ToSpawnBonus += CreateBonus;
        _keeper.Fail += Clear;
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnProcess());
        _provider.ToSpawnBonus -= CreateBonus;
        _keeper.Fail -= Clear;
    }

    private void Clear()
    {
        var squares = GameObject.FindObjectsOfType<Square>();

        foreach (var square in squares)
        {
            Destroy(square.gameObject);
        }

        StopCoroutine(SpawnProcess());
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
        var x = _offset * Random.Range(-1f, 1f);
        var position = _transform.position + new Vector3(x, 0, 0);

        _instance = Instantiate(_square, position, Quaternion.identity, _transform);
        ToGiveSquare?.Invoke();
    }
}
