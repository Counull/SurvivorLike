using System.Collections;
using System.Collections.Generic;
using Models;
using QFramework;
using UnityEngine;

namespace GameSystem {
    public class EnemySystem : AbstractSystem {
        private List<float> spawnRnadom;

        protected override void OnInit() {
            IEnumerator autoSpawnEnemy = AutoSpawnEnemy();
        }

        public void SpawnEnemy() {
            float random = Random.value;

            for (int type = 0; type < spawnRnadom.Count; type++) {
                if (random <= spawnRnadom[type]) {
                    SpawnEnemy(type);
                    break;
                }
            }
        }


        public void SpawnEnemy(int index) {
            var playerModel = this.GetModel<PlayerModels>();
            Vector2 randomPosition = (Vector2) playerModel.playerPosition.Value +
                                     RandomPosition(playerModel.cleanAreaSqr, playerModel.enemySpawnArea);
            var enemyModel = this.GetModel<EnemyModel>();
           var enemy= Object.Instantiate(enemyModel.enemyData.Value[index].Prefab, randomPosition, Quaternion.identity);
         
        }

        Vector2 RandomPosition(float cleanAreaSqr, float enemySpawnArea) {
            Vector2 randomPoint;

            do {
                randomPoint = Random.insideUnitCircle * enemySpawnArea;
            } while (randomPoint.sqrMagnitude < cleanAreaSqr);

            return randomPoint;
        }

        public void StartSpanEnemy() {
            var enemyList = this.GetModel<EnemyModel>().enemyData.Value;

            spawnRnadom = new List<float>(enemyList.Count);
            float total = 0.0f;
            foreach (var enemyData in enemyList) {
                total += enemyData.SpawnRatio;
                spawnRnadom.Add(total);
            }

            GameController.GameController.QueueCoroutine(AutoSpawnEnemy());
        }

        IEnumerator AutoSpawnEnemy() {
            while (true) {
                SpawnEnemy();
                yield return new WaitForSeconds(2);
            }
        }
    }
}