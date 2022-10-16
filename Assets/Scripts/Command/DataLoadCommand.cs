using System;
using Models;
using QFramework;
using UnityEngine;

namespace Command {
    public class DataLoadCommand : AbstractCommand {
        private ILevelData _levelData;

        public DataLoadCommand(ILevelData data) {
            _levelData = data;
        }

        protected override void OnExecute() {
            var playerModel = this.GetModel<PlayerModels>();


            var prefab = Resources.Load<GameObject>(_levelData.PlayerPrefabPath);
            if (prefab == null) {
                throw new Exception("prefab not loaded");
            }

            playerModel.playerPrefab.Value = prefab;
            playerModel.playerSpawnPoint.Value = _levelData.PlayerSpawnPoint;
            playerModel.playerSpeed.Value = _levelData.PlayerSpeed;

            _levelData.Destroy();
        }
    }
}