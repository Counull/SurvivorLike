using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace Models {
    public class WeaponModel : AbstractModel {
        public BindableProperty<List<GameObject>> prefabList;


        protected override void OnInit() {
            prefabList = new BindableProperty<List<GameObject>>();
            prefabList.SetValueWithoutEvent(new List<GameObject>());
        }
    }
}