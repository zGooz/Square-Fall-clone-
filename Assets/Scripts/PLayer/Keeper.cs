
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
        var checkBonus = other.TryGetComponent(out Bonus _);
        var checkSquare = other.TryGetComponent(out Square _);

        if (checkBonus)
        {
            Keep?.Invoke();
        }

        if (checkSquare)
        {
            if (!checkBonus)
            {
                Fail?.Invoke();
            }
        }

        Destroy(other);
    }
}
