
using UnityEngine;


public class Rotator : MonoBehaviour
{
    private Transform _transform;
    private float _angularVelocity = 1f;

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
