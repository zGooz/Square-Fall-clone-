
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]

public class Keeper : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject;

        if (other.TryGetComponent(out Square _))
        {
            Destroy(other);
        }
    }
}
