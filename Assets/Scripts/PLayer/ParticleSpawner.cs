
using UnityEngine;


[RequireComponent(typeof(Keeper))]

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _particlePrefab;

    private Keeper _keeper;
    private Transform _transform;

    private void Awake()
    {
        _keeper = GetComponent<Keeper>();
        _transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _keeper.SpawnParticleOfLoser += OnSpawnParticleOfLoser;
    }

    private void OnDisable()
    {
        _keeper.SpawnParticleOfLoser -= OnSpawnParticleOfLoser;
    }

    private void OnSpawnParticleOfLoser()
    {
        Instantiate(_particlePrefab, _transform.position, Quaternion.identity);
    }
}
