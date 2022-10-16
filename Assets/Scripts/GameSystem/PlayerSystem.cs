using Models;
using QFramework;
using UnityEngine;

namespace GameSystem {
    public class PlayerSystem : AbstractSystem {
        protected override void OnInit() { }

        public void SpawnPlayer() {
            var playerModel = this.GetModel<PlayerModels>();
            Object.Instantiate<GameObject>(playerModel.playerPrefab.Value, playerModel.playerSpawnPoint.Value,
                Quaternion.identity);
        }
    }
}