
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CollideHandler))]

public class Breaker : MonoBehaviour
{
    [SerializeField] private float _forceValue;

    private Rigidbody2D _body;
    private CollideHandler _handler;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _body = GetComponent<Rigidbody2D>();
        _handler = GetComponent<CollideHandler>();
    }

    private void OnEnable()
    {
        _handler.CollideComplete += MoveUpInRandomDirection;
    }

    private void OnDisable()
    {
        _handler.CollideComplete -= MoveUpInRandomDirection;
    }

    private void MoveUpInRandomDirection()
    {
        var position = _transform.position;
        var x = position.x;
        var y = position.y + Random.Range(2, _forceValue);
        var forceDirection = new Vector2(x, y);
        var force = forceDirection * _forceValue;

        _body.AddForce(force, ForceMode2D.Impulse);
        _body.gravityScale = 0;
    }
}
