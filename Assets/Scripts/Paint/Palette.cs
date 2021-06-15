
using UnityEngine;
using UnityEngine.Events;


public class Palette : MonoBehaviour
{
    public Color Color { get; private set; } = Color.white;
    public event UnityAction ColorSet;

    [SerializeField] private Donor _donor;

    private void OnEnable()
    {
        _donor.ToGiveBonus += MakeColor;
    }

    private void OnDisable()
    {
        _donor.ToGiveBonus -= MakeColor;
    }

    private void MakeColor()
    {
        var r = Random.Range(0, 1);
        var g = Random.Range(0, 1);
        var b = Random.Range(0, 1);

        Color = new Color(r, g, b, 1);
        ColorSet?.Invoke();
    }
}
