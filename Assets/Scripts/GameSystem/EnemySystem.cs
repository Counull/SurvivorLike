using System.Collections;
using Models;
using QFramework;
using UnityEngine;

namespace GameSystem {
    public class EnemySystem : AbstractSystem {
        protected override void OnInit() { }

        public void SpawnEnemy() {
            var enemyModel = this.GetModel<EnemyModel>();
            var playerModel = this.GetModel<PlayerModels>();

            foreach (var data in enemyModel.enemyData.Value) {
                Vector3 randomPosotiom =
                    playerModel.playerPosition.Value + new Vector3(Random.value * 5, Random.value * 5);
                Object.Instantiate(data.Prefab, randomPosotiom, Quaternion.identity);
            }
        }

        IEnumerator AutoSpawnEnemy() {
            yield return new WaitForSeconds(2);
        }
    }
}