using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelData {
    Vector2 PlayerSpawnPoint { get; }
    string PlayerPrefabPath { get; }
    float PlayerSpeed { get; }

    void Destroy();
}

public class LevelData : MonoBehaviour, ILevelData {
    [SerializeField] private Vector2 playerSpawnPoint;
    [SerializeField] private string playerPrefabPath;
    [SerializeField] private float playerSpeed;
    public Vector2 PlayerSpawnPoint => playerSpawnPoint;
    public string PlayerPrefabPath => playerPrefabPath;

    public float PlayerSpeed => playerSpeed;

    public void Destroy() {
        GameObject.Destroy(this);
    }
}