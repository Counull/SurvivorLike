using System;
using System.Collections.Generic;
using EnemyData;
using GameController;
using GameSystem;
using LevelData.WeaponData;
using Models;
using QFramework;
using UnityEngine;

namespace Command {
    public class DataLoadCommand : AbstractCommand {
        private readonly IPlayerData _playerPlayerData;
        private readonly IEnemyData[] _enemyData;

        private IWeaponData[] _weaponData;

        public DataLoadCommand(IPlayerData playerPlayerData, IEnemyData[] enemyData, IWeaponData[] weaponData) {
            _playerPlayerData = playerPlayerData;
            _enemyData = enemyData;
            _weaponData = weaponData;
        }

        protected override void OnExecute() {
            LoadPlayerData();
            LoadEnemyData();
            LoadWeaponData();
        }


        void LoadWeaponData() {
            var weaponModel = this.GetModel<WeaponModel>();

            List<int> surrounderIndexList = new List<int>(_weaponData.Length);
            List<int> shooterIndexList = new List<int>(_weaponData.Length);

            for (int i = 0; i < _weaponData.Length; i++) {
                var prefab = Resources.Load<GameObject>(_weaponData[i].PrefabPath);
                if (prefab == null) {
                    continue;
                }

                weaponModel.prefabList.Value.Add(prefab);
                int currentIndex = weaponModel.prefabList.Value.Count - 1;
                var type = _weaponData[currentIndex].WeaponType;

                switch (type) {
                    case WeaponType.Shooter:
                        shooterIndexList.Add(currentIndex);
                        break;
                    case WeaponType.Surrounder:
                        surrounderIndexList.Add(currentIndex);
                        break;
                    default:
                        throw new Exception("Weapon type not exist");
                }
            }

            if (shooterIndexList.Count > 0) {
                GameArchitecture.Interface.RegisterSystem(new ShooterSystem(shooterIndexList));
            }

            if (surrounderIndexList.Count > 0) {
                //我本来以为这个东西能塞多个同样类型的System
                GameArchitecture.Interface.RegisterSystem(new SurrounderSystem(surrounderIndexList));
            }
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
            var playerModel = this.GetModel<PlayerModel>();


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