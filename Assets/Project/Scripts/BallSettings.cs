using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BallSettings", menuName = "Settings/Game/BallSettings")]
public class BallSettings : ScriptableObject
{
    [SerializeField]
    private MoveSettings move;

    public MoveSettings Move => move;
    
    
    
    [Serializable]
    public class MoveSettings
    {
        [SerializeField]
        private float speed = 1;

        public float Speed => speed;
    }
}

