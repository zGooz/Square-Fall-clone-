
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
[RequireComponent(typeof(Judge))]

public class ScoreBoard : MonoBehaviour
{
    private Text _board;
    private Judge _provider;

    private void Awake()
    {
        _board = GetComponent<Text>();
        _provider = GetComponent<Judge>();
    }

    private void OnEnable()
    {
        _provider.NewScore += UpdateResultOnScoreboard;
    }

    private void OnDisable()
    {
        _provider.NewScore -= UpdateResultOnScoreboard;
    }

    private void UpdateResultOnScoreboard()
    {
        _board.text = _provider.Score.ToString();
    }
}
