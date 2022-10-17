using System.Collections.Generic;
using Event;
using Models;
using QFramework;
using UnityEngine;

namespace GameSystem {
    public class SurrounderSystem : IWeaponSystem {
        public SurrounderSystem(List<int> weaponIndex) : base(weaponIndex) { }

        protected override void OnInit() {
            this.RegisterEvent<PlayerSpawnComplete>(SurroundPlayer);
        }


        public override void Start() {
            shouldStop = false;
        }

        void SurroundPlayer(PlayerSpawnComplete e) {
          
            var weaponModel = this.GetModel<WeaponModel>();
            foreach (var index in weaponIndex) {
                var prefab = weaponModel.prefabList.Value[index];
                Object.Instantiate(prefab, e.player.transform);
            }
        }


        public override void Stop() {
            shouldStop = true;
        }
    }
}