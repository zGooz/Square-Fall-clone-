
using UnityEngine;

public class Square : MonoBehaviour 
{
    private readonly float _lifetime = 5.0f;

    private void Awake()
    {
        Destroy(gameObject, _lifetime);
    }
}
