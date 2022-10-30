namespace Project.Game.Ball.Settings
{
    using System;
    using UnityEngine;

    [CreateAssetMenu(fileName = "BallSettings", menuName = "Settings/Game/BallSettings")]
    public class BallSettings : ScriptableObject
    {
        [SerializeField]
        private MoveSettings move;

        [SerializeField]
        private PositionSettings position;

        public MoveSettings Move => move;
        public PositionSettings Position => position;


        [Serializable]
        public class MoveSettings
        {
            [SerializeField]
            private float speed = 1;

            public float Speed => speed;
        }

        [Serializable]
        public class PositionSettings
        {
            [SerializeField]
            private Vector2 defaultPosition;

            [SerializeField]
            private float maxStartAngle;

            public Vector2 DefaultPosition => defaultPosition;
            public float MaxStartAngle => maxStartAngle;
        }
    }
}