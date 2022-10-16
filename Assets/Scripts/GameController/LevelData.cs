using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelData {
    Vector2 PlayerSpawnPoint { get; }
    string PlayerPrefabPath { get; }
}

public class LevelData : MonoBehaviour, ILevelData {
    [SerializeField] private Vector2 playerSpawnPoint;
    [SerializeField] private string playerPrefabPath;
    public Vector2 PlayerSpawnPoint => playerSpawnPoint;
    public string PlayerPrefabPath => playerPrefabPath;
    
}