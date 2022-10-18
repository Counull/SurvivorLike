using System.Collections.Generic;
using LevelData.WeaponData;
using QFramework;
using UnityEngine;

namespace Models {
    public class WeaponModel : AbstractModel {
        public BindableProperty<List<BaseWeaponData>> WeaponData;
        

        protected override void OnInit() {
            WeaponData = new BindableProperty<List<BaseWeaponData>>();
            WeaponData.SetValueWithoutEvent(new List<BaseWeaponData>());
        }
    }
}