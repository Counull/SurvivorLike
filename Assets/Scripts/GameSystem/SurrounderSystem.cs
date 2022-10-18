using System.Collections.Generic;
using Event;
using Models;
using QFramework;
using UnityEngine;

namespace GameSystem {
    public class SurrounderSystem : AbstractWeaponSystem {
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
                var baseWeaponData = weaponModel.WeaponData.Value[index];
                var prefab = baseWeaponData.Prefab;
                var unitRadian = Mathf.PI * 2 / baseWeaponData.Count;
                for (int i = 0; i < baseWeaponData.Count; i++) {
                    var radian = unitRadian * i;
                    var playerTransform = e.player.transform;
                    Vector3 delta = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian)) * baseWeaponData.MaxDistance;
                    Object.Instantiate(prefab, playerTransform.position + delta, Quaternion.identity,
                        playerTransform);
                }
            }
        }


        public override void Stop() {
            shouldStop = true;
        }
    }
}