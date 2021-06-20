
using UnityEngine;
using UnityEngine.Events;


public class Palette : MonoBehaviour
{
    public Color Color { get; private set; } = Color.white;
    public event UnityAction ColorSet;

    [SerializeField] private Donor _donor;

    private void OnEnable()
    {
        _donor.ToSpawnBonus += MakeColor;
    }

    private void OnDisable()
    {
        _donor.ToSpawnBonus -= MakeColor;
    }

    private void MakeColor()
    {
        var r = Random.Range(0.0f, 1.0f);
        var g = Random.Range(0.0f, 1.0f);
        var b = Random.Range(0.0f, 1.0f);

        Color = new Color(r, g, b, 1);
        ColorSet?.Invoke();
    }
}
