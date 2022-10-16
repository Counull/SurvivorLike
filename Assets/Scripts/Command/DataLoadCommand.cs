using System;
using System.Collections.Generic;
using EnemyData;
using GameController;
using Models;
using QFramework;
using UnityEngine;

namespace Command {
    public class DataLoadCommand : AbstractCommand {
        private readonly IPlayerData _playerPlayerData;
        private IEnemyData[] _enemyData;

        public DataLoadCommand(IPlayerData playerPlayerData, IEnemyData[] enemyData) {
            _playerPlayerData = playerPlayerData;
            _enemyData = enemyData;
        }

        protected override void OnExecute() {
            LoadPlayerData();
            LoadEnemyData();
        }

        void LoadEnemyData() {
            var enemyModel = this.GetModel<EnemyModel>();

            float total = 0.0f;
            foreach (var vEnemyData in _enemyData) {
                total += vEnemyData.Data.SpawnRatio;
            }

            foreach (var vEnemyData in _enemyData) {
                var baseEnemyData = vEnemyData.Data;
                var prefab = Resources.Load<GameObject>(vEnemyData.PrefabPath);
                baseEnemyData.Prefab = prefab;
                enemyModel.enemyData.Value.Add(baseEnemyData);
                vEnemyData.Data.SpawnRatio /= total;
                vEnemyData.Destroy();
            }
        }

        void LoadPlayerData() {
            var playerModel = this.GetModel<PlayerModels>();


            var prefab = Resources.Load<GameObject>(_playerPlayerData.PlayerPrefabPath);
            if (prefab == null) {
                throw new Exception("prefab not loaded");
            }

            playerModel.playerPrefab.Value = prefab;
            playerModel.playerSpawnPoint.Value = _playerPlayerData.PlayerSpawnPoint;
            playerModel.playerSpeed.Value = _playerPlayerData.PlayerSpeed;
            playerModel.cleanAreaSqr.Value = _playerPlayerData.CleanArea * _playerPlayerData.CleanArea;
            playerModel.enemySpawnArea.Value = _playerPlayerData.EnemySpawnArea;
            playerModel.playerMaxHealth.Value = _playerPlayerData.PlayerMaxHealth;
            playerModel.playerCurrentHealth.Value = _playerPlayerData.PlayerCurrentHealth;
            _playerPlayerData.Destroy();
        }
    }
}