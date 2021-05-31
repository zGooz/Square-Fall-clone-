
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]

public class Colorant : MonoBehaviour
{
    [SerializeField] private Palette _palette;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _palette.ColorSeted += Paint;
    }

    private void OnDisable()
    {
        _palette.ColorSeted -= Paint;
    }

    private void Paint()
    {
        _renderer.color = _palette.Color;
    }
}
