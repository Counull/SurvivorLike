using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameController {
    public interface IPlayerData {
        Vector2 PlayerSpawnPoint { get; }
        string PlayerPrefabPath { get; }
        float PlayerSpeed { get; }

        float CleanArea { get; }

        float EnemySpawnArea { get; }

        float PlayerMaxHealth { get; }
        float PlayerCurrentHealth { get; }
        void Destroy();
    }

    public class PlayerData : MonoBehaviour, IPlayerData {
        [SerializeField] private Vector2 playerSpawnPoint;
        [SerializeField] private string playerPrefabPath;
        [SerializeField] private float playerSpeed;

        [SerializeField] private float playerMaxHealth;
        [SerializeField] private float playerCurrentHealth;
        [SerializeField] private float cleanArea;
        [SerializeField] private float enemySpawnArea;
        public Vector2 PlayerSpawnPoint => playerSpawnPoint;
        public string PlayerPrefabPath => playerPrefabPath;

        public float PlayerSpeed => playerSpeed;
        public float CleanArea => cleanArea;
        public float EnemySpawnArea => enemySpawnArea;
        public float PlayerMaxHealth => playerMaxHealth;
        public float PlayerCurrentHealth => playerCurrentHealth;


        public void Destroy() {
            GameObject.Destroy(gameObject);
            //  GameObject.Destroy(this);
        }
    }
}