
using UnityEngine;
using UnityEngine.UI;


public class Dock : MonoBehaviour 
{
    [SerializeField] Text _scoreValue;
    [SerializeField] Text _bestValue;
    [SerializeField] ScoreProvider _provider;

    private void OnEnable()
    {
        _scoreValue.text = _provider.Score.ToString();
        _bestValue.text = _provider.Best.ToString();
    }
}
