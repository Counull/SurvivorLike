using System;
using System.Collections;
using Command;
using EnemyData;
using Models;
using QFramework;
using Unity.VisualScripting;
using UnityEngine;

namespace Behavior {
    using GameController;

    public class EnemyBehavior : EnemyController {
        private int _type;
        private BaseEnemyData _property;
        private bool following = false;

        public void Init(int type) {
            this._type = type;
            var enemyMode = this.GetModel<EnemyModel>();
            _property = enemyMode.enemyData.Value[type];
            StartCoroutine(nameof(AutoFollowPlayer));
        }


        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Player")) {
                this.SendCommand(new HurtPlayerCommand(_property.Damage));
            }
        }

        IEnumerator AutoFollowPlayer() {
            following = true;

            var agent = GetComponent<PolyNavAgent>();
            while (following) {
                var target = this.GetModel<PlayerModels>().playerPosition.Value;
                agent.SetDestination(target);
                yield return new WaitForSeconds(0.7f);
            }
        }
    }
}