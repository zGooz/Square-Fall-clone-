
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Pusher : MonoBehaviour
{
    private float _forceValue = 1f;
    private int _directionFlow = 1;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _directionFlow = Random.Range(-1, 2);
        _forceValue = Random.Range(1f, 4f);
    }

    private void Update()
    {
        var value = _forceValue * _directionFlow * Time.deltaTime;
        var force = new Vector2(value, 0);

        _body.AddForce(force, ForceMode2D.Impulse);
    }
}
