
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]

public class Colorant : MonoBehaviour
{
    [SerializeField] private Palette _palette;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        if (_palette == null)
        {
            // This is for the prefabs.
            _palette = GameObject.FindObjectOfType<Palette>();
        }

        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _palette.ColorSet += Paint;
    }

    private void OnDisable()
    {
        _palette.ColorSet -= Paint;
    }

    private void Paint()
    {
        var isBonus = gameObject.TryGetComponent<Bonus>(out Bonus _);
        var isPlayer = gameObject.TryGetComponent<Player>(out Player _);

        if (isBonus || isPlayer)
        {
            _renderer.color = _palette.Color;
        }
    }
}
