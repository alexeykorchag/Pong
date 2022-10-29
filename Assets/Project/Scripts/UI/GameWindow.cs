using TMPro;
using UnityEngine;
using Zenject;

public class GameWindow : BaseWindow
{

    [Inject]
    private GameController gameController;

    [Header("Score")]
    [SerializeField]
    private TMP_Text scoreLeft;
    [SerializeField]
    private TMP_Text scoreRight;
    [SerializeField]
    private TMP_Text countdown;

    public override void Show()
    {
        base.Show();

        gameController.ScoreChanged += OnScoreChanged;
        gameController.GameStart += OnGameStart;
        gameController.GameStarted += OnGameStarted;
    }

    public override void Hide()
    {
        base.Hide();

        gameController.ScoreChanged -= OnScoreChanged;
        gameController.GameStart -= OnGameStart;
        gameController.GameStarted -= OnGameStarted;
    }

    private void OnScoreChanged()
    {
        scoreLeft.text = gameController.scoreLeft.ToString();
        scoreRight.text = gameController.scoreRight.ToString();
    }

    private void OnGameStart(int value)
    {
        countdown.gameObject.SetActive(true);
        countdown.text = value.ToString();
    }

    private void OnGameStarted()
    {
        countdown.gameObject.SetActive(false);
    }



}
