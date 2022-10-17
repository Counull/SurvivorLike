using System.Collections;
using System.Collections.Generic;
using Models;
using QFramework;
using UnityEngine;

namespace GameSystem {
    public class ShooterSystem : IWeaponSystem {
        public ShooterSystem(List<int> weaponIndex) : base(weaponIndex) { }

        protected override void OnInit() { }


        public override void Start() {
            shouldStop = false;
           var weaponModel= this.GetModel<WeaponModel>();
            foreach (var index in weaponIndex) {
               var prefab= weaponModel.prefabList.Value[index];
               GameController.GameController.QueueCoroutine(AutoShoot(prefab,1));
            }
        }

        public override void Stop() {
            shouldStop = true;
        }


        IEnumerator AutoShoot(GameObject prefab, float interval) {
            while (!shouldStop) {
                var position = this.GetModel<PlayerModel>().playerPosition.Value;
                GameObject.Instantiate(prefab,position,Quaternion.identity);
                yield return new WaitForSeconds(interval);
            }
        }
    }
}