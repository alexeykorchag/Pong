using UnityEngine;
public interface IMove
{
    void Create(GameObject root, PlayerSettings.MoveSettings settings);
    void Enable();
    void Disable();
    void Update(float deltaTime);
    void Dispose();
}