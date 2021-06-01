
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private Handler _handler;
    [SerializeField] private readonly float _speed = 2.5f;

    private Transform _transform;
    private int _direction = 0;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _handler.Reverce += OnRunOrReverce;
    }

    private void OnDisable()
    {
        _handler.Reverce -= OnRunOrReverce;
    }

    private void Update()
    {
        var x = _speed * _direction * Time.deltaTime;
        _transform.position += new Vector3(x, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject;

        if (other.TryGetComponent(out Reflector _))
        {
            _direction *= -1;
        }
    }

    private void OnRunOrReverce()
    {
        _direction = (_direction == 0) ? 1 : _direction * -1;
    }
}
