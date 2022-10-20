using System.Collections;
using System.Collections.Generic;
using EnemyData;
using QFramework;
using UnityEngine;

namespace Models {
    public class EnemyModel : AbstractModel {
        //应该有个enum EnemyType 然后这里放HashMap
        public BindableProperty<List<EnemyTypeData>> enemyTypeData;
        public Dictionary<int, EnemyStatusData> statusData;

        protected override void OnInit() {
            enemyTypeData = new BindableProperty<List<EnemyTypeData>>();
            enemyTypeData.SetValueWithoutEvent(new List<EnemyTypeData>());
            statusData = new Dictionary<int, EnemyStatusData>();
        }
    }
}