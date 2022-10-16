using System.Collections.Generic;
using EnemyData;
using QFramework;
using UnityEngine;

namespace Models {
    public class EnemyModel : AbstractModel {
        public BindableProperty<List<BaseEnemyData>> enemyData;

        protected override void OnInit() {
            enemyData = new BindableProperty<List<BaseEnemyData>>();
            enemyData.Value = new List<BaseEnemyData>();
        }
    }
}