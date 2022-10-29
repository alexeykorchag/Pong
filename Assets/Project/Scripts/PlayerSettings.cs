using System;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerSettings", menuName = "Settings/Game/PlayerSettings")]
public class PlayerSettings : ScriptableObject
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

