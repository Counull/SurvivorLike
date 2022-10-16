using Event;
using Models;
using QFramework;
using UnityEngine;

namespace Command {
    public class HurtPlayerCommand : AbstractCommand {
        private float damage;

        public HurtPlayerCommand(float damage) {
            this.damage = damage;
        }

        protected override void OnExecute() {
            var playerModels = this.GetModel<PlayerModels>();
            playerModels.playerCurrentHealth.Value -= damage;
            Debug.Log("Player get hurt:" + damage);
            if (playerModels.playerCurrentHealth < float.Epsilon) {
                this.SendEvent<PlayerDied>();
            }
        }
    }
}