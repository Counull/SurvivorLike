using Behavior;
using Command;
using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameController {
    [ShowInInspector]
    public class WeaponController : MonoBehaviour, IController {
        [ShowInInspector] public float damage = 0.0f;

        protected virtual void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Enemy")) {
                Debug.Log(col.gameObject.name + "get hurt");
            }
        }

        protected virtual void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Enemy")) {
                if (damage > 0) {
                    HurtEnemyCommand.Instance.Damage = damage;
                    HurtEnemyCommand.Instance.EnemyID = col.gameObject.GetInstanceID();
                    this.SendCommand<HurtEnemyCommand>(HurtEnemyCommand.Instance);
                }
            }
        }


        public IArchitecture GetArchitecture() {
            return GameArchitecture.Interface;
        }
    }
}