
using UnityEngine;


public class Rotator : MonoBehaviour
{
    [SerializeField] private float _angularVelocity = 1.5f;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _angularVelocity = Random.Range(1f, -1f);
    }

    private void Update()
    {
        _transform.rotation *= Quaternion.Euler(0, 0, _angularVelocity);
    }
}
