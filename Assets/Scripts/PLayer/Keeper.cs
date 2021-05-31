
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(CircleCollider2D))]

public class Keeper : MonoBehaviour
{
    public event UnityAction Keep;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject;

        if (other.TryGetComponent(out Bonus _))
        {
            Keep?.Invoke();
        }

        if (other.TryGetComponent(out Square _))
        {
            Destroy(other);
        }
    }
}
