
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(CircleCollider2D))]

public class Keeper : MonoBehaviour
{
    public event UnityAction Keep;
    public event UnityAction Fail;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.gameObject;

        if (other.TryGetComponent(out Bonus _))
        {
            Keep?.Invoke();
        }

        if (other.TryGetComponent(out Square _))
        {
            Fail?.Invoke();
        }

        Destroy(other);
    }
}
