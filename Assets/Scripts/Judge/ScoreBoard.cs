
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
[RequireComponent(typeof(ScoreProvider))]

public class ScoreBoard : MonoBehaviour
{
    private Text _board;
    private ScoreProvider _provider;

    private void Awake()
    {
        _board = GetComponent<Text>();
        _provider = GetComponent<ScoreProvider>();
    }

    private void OnEnable()
    {
        UpdateResultOnScoreboard();
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
