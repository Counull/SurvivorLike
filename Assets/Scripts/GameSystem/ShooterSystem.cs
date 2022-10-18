using System.Collections;
using System.Collections.Generic;
using LevelData.WeaponData;
using Models;
using QFramework;
using UnityEngine;

namespace GameSystem {
    public class ShooterSystem : AbstractWeaponSystem {
        public ShooterSystem(List<int> weaponIndex) : base(weaponIndex) { }

        protected override void OnInit() { }


        public override void Start() {
            shouldStop = false;
            var weaponModel = this.GetModel<WeaponModel>();
            foreach (var index in weaponIndex) {
                var weaponData = weaponModel.WeaponData.Value[index];
                GameController.GameController.QueueCoroutine(AutoShoot((ShooterWeaponData) weaponData));
            }
        }

        public override void Stop() {
            shouldStop = true;
        }


        IEnumerator AutoShoot(ShooterWeaponData weaponData) {
            while (!shouldStop) {
                var position = this.GetModel<PlayerModel>().playerPosition.Value;
                for (int i = 0; i < weaponData.Count - 1; i++) {
                    Object.Instantiate(weaponData.Prefab, position, Quaternion.identity);
                    yield return new WaitForSeconds(weaponData.ContinuousFireInterval);
                }

                Object.Instantiate(weaponData.Prefab, position, Quaternion.identity);
                yield return new WaitForSeconds(weaponData.ShootInterval);
            }
        }
    }
}