using System.Collections;
using System.Collections.Generic;
using Behavior;
using EnemyData;
using Models;
using QFramework;
using UnityEngine;

namespace GameSystem {
    public class EnemySystem : AbstractSystem {
        private List<float> spawnRnadom;

        protected override void OnInit() {
      
        }


        public void StartSpanEnemy() {
            var enemyList = this.GetModel<EnemyModel>().enemyTypeData.Value;

            spawnRnadom = new List<float>(enemyList.Count);
            float total = 0.0f;
            foreach (var enemyData in enemyList) {
                total += enemyData.SpawnRatio;
                spawnRnadom.Add(total);
            }

            GameController.GameController.QueueCoroutine(AutoSpawnEnemy());
        }


        public void RandomSpawnEnemy() {
            float random = Random.value;

            for (int type = 0; type < spawnRnadom.Count; type++) {
                if (random <= spawnRnadom[type]) {
                    SpawnEnemyRandomPosition(type);
                    break;
                }
            }
        }


        public void SpawnEnemyRandomPosition(int type) {
            var playerModel = this.GetModel<PlayerModel>();
            Vector2 randomPosition = (Vector2) playerModel.playerPosition.Value +
                                     RandomPosition(playerModel.cleanAreaSqr, playerModel.enemySpawnArea);
            var enemyModel = this.GetModel<EnemyModel>();
            var enemyTypeData = enemyModel.enemyTypeData.Value[type];
            var enemy = Object.Instantiate(enemyTypeData.Prefab, randomPosition,
                Quaternion.identity);
            var status = new EnemyStatusData {
                CurrentHealth = enemyTypeData.Health,
                GameObject = enemy
            };
            enemyModel.statusData.Add(enemy.GetInstanceID(), status);

            enemy.GetComponent<EnemyBehavior>().Init(type);
        }

        Vector2 RandomPosition(float cleanAreaSqr, float enemySpawnArea) {
            Vector2 randomPoint;

            do {
                randomPoint = Random.insideUnitCircle * enemySpawnArea;
            } while (randomPoint.sqrMagnitude < cleanAreaSqr);

            return randomPoint;
        }


        IEnumerator AutoSpawnEnemy() {
            int index = 0;
            while (true) {
                RandomSpawnEnemy();
                index++;
                yield return new WaitForSeconds(2);
            }
        }
    }
}