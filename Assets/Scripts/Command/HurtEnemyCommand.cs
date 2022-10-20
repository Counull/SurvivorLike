using System;
using Models;
using QFramework;
using Unity.VisualScripting;
using UnityEngine;

namespace Command {
    public class HurtEnemyCommand : AbstractCommand {
        private HurtEnemyCommand() { }
        private static readonly Lazy<HurtEnemyCommand> Lazy = new(new HurtEnemyCommand());
        public static HurtEnemyCommand Instance => Lazy.Value;


        public int EnemyID { get; set; }

        public float Damage { get; set; }

        protected override void OnExecute() {
            var enemyStatusData = this.GetModel<EnemyModel>().statusData[EnemyID];
            enemyStatusData.CurrentHealth -= Damage;
#if UNITY_EDITOR
            Debug.Log(string.Format("Enemy {0}({1}) get Hurt,damage:{2},current health{3}",
                enemyStatusData.GameObject.name, enemyStatusData.GameObject.GetInstanceID(), Damage,
                enemyStatusData.CurrentHealth
            ));
#endif
            if (enemyStatusData.CurrentHealth < float.Epsilon) {
                enemyStatusData.GameObject.SetActive(false);
            }
        }
    }
}