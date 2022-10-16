﻿using UnityEngine;
using UnityEngine.Serialization;

namespace EnemyData {
    public class EnemyBushData : MonoBehaviour, IEnemyData {
        [SerializeField]  BaseEnemyData baseEnemyData;
        [SerializeField] string prefabPath;

        public BaseEnemyData Data => baseEnemyData;
        public BaseHealerData HealingData => null;
        public string PrefabPah => prefabPath;
        public void Destroy() {
            GameObject.Destroy(this);
        }
    }
}