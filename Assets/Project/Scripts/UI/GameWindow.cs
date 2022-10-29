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

    public override void Show()
    {
        base.Show();

        gameController.ScoreChanged += OnScoreChanged;
    }

    public override void Hide()
    {
        base.Hide();

        gameController.ScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        scoreLeft.text = gameController.scoreLeft.ToString();
        scoreRight.text = gameController.scoreRight.ToString();
    }

}
