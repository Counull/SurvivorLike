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
            foreach (var vEnemyData in _enemyData) {
                var baseEnemyData = vEnemyData.Data;
                var prefab = Resources.Load<GameObject>(vEnemyData.PrefabPah);
                baseEnemyData.Prefab = prefab;
                enemyModel.enemyData.Value.Add(baseEnemyData);
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

            _playerPlayerData.Destroy();
        }
    }
}