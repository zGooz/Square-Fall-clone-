
using UnityEngine;


public class LifeTimeHandler : MonoBehaviour
{
    [SerializeField]
    private float _lifetime = 2.0f;

    private void Awake()
    {
        Destroy(gameObject, _lifetime);
    }
}
