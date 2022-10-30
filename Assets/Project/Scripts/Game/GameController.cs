namespace Project.Game
{
    using Mirror;
    using System;
    using System.Collections;
    using UnityEngine;

    public class GameController : NetworkBehaviour
    {
        [SyncVar(hook = nameof(ScoreUpdated))]
        public int scoreLeft;
        [SyncVar(hook = nameof(ScoreUpdated))]
        public int scoreRight;

        public event Action ScoreChanged;

        public event Action<int> GameStart;
        public event Action GameStarted;

        public event Action ResetPosition;

        [Server]
        public void AddPointToLeft()
        {
            scoreLeft++;
            ScoreChanged?.Invoke();

            ResetPosition?.Invoke();
        }

        [Server]
        public void AddPointToRight()
        {
            scoreRight++;
            ScoreChanged?.Invoke();

            ResetPosition?.Invoke();
        }

        private void ScoreUpdated(int oldValue, int newValue)
        {
            ScoreChanged?.Invoke();
        }

        [ClientRpc]
        public void StartNewGame() => StartCoroutine(CountdownToStart());

        private IEnumerator CountdownToStart()
        {
            var wfs = new WaitForSecondsRealtime(1f);

            for (var i = 3; i > 0; i--)
            {
                GameStart?.Invoke(i);
                yield return new WaitForSecondsRealtime(1f);
            }

            GameStarted?.Invoke();
        }
    }
}
