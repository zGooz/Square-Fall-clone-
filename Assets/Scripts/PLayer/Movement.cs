
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Keeper))]

public class Movement : MonoBehaviour
{
    public event UnityAction CollideReflector;

    [SerializeField] private MoveHandler _handler;
    [SerializeField] private float _speed = 2.5f;

    private bool IsFirstRun { get; set; } = true;

    private Transform _transform;
    private int _direction = 0;
    private Keeper _keeper;
    private Vector2 _startPosition;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _keeper = GetComponent<Keeper>();
        _startPosition = _transform.position;
    }

    private void OnEnable()
    {
        IsFirstRun = true;

        _handler.Reverce += OnReverceDirection;
        _keeper.MakeStop += OnStopMovement;
    }

    private void OnDisable()
    {
        _handler.Reverce -= OnReverceDirection;
        _keeper.MakeStop -= OnStopMovement;
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
            CollideReflector?.Invoke();
        }
    }

    private void Run()
    {
        _direction = 1;
        IsFirstRun = false;
    }

    private void OnStopMovement()
    {
        _direction = 0;
        _transform.position = _startPosition;
    }

    private void OnReverceDirection()
    {
        if (IsFirstRun)
        {
            Run();
        }
        else
        {
            _direction = -_direction;
        }
    }
}
