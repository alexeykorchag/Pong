using Mirror;
using System;

public class GameController : NetworkBehaviour
{
    [SyncVar(hook = nameof(ScoreUpdated))]
    public int scoreLeft;
    [SyncVar(hook = nameof(ScoreUpdated))]
    public int scoreRight;

    public event Action ScoreChanged;


    [Server]
    public void AddPointToLeft()
    {
        scoreLeft++;
        ScoreChanged?.Invoke();
    }

    [Server]
    public void AddPointToRight()
    {
        scoreRight++;
        ScoreChanged?.Invoke();
    }

    private void ScoreUpdated(int oldValue, int newValue)
    {
        ScoreChanged?.Invoke();
    }
}
