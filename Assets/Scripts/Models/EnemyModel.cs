using System.Collections.Generic;
using EnemyData;
using QFramework;
using UnityEngine;

namespace Models {
    public class EnemyModel : AbstractModel {
        //应该有个enum EnemyType 然后这里放HashMap
        public BindableProperty<List<BaseEnemyData>> enemyData;

        protected override void OnInit() {
            enemyData = new BindableProperty<List<BaseEnemyData>>();
            enemyData.SetValueWithoutEvent(new List<BaseEnemyData>());
        }
    }
}