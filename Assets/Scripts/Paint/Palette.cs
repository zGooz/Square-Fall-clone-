
using UnityEngine;
using UnityEngine.Events;


public class Palette : MonoBehaviour
{
    public Color Color { get; private set; } = Color.white;
    public event UnityAction ColorSet;

    [SerializeField] private BonusProvider _provider;

    private void OnEnable()
    {
        _provider.ToSpawnBonus += MakeColor;
    }

    private void OnDisable()
    {
        _provider.ToSpawnBonus -= MakeColor;
    }

    private void MakeColor()
    {
        var h = Random.Range(0.0f, 1.0f);
        Color = Color.HSVToRGB(h, 1, 1);
        ColorSet?.Invoke();
    }
}
