
using UnityEngine;

public class Square : MonoBehaviour 
{
    private readonly float _lifetime = 2.0f;

    private void Awake()
    {
        Destroy(gameObject, _lifetime);
    }
}
