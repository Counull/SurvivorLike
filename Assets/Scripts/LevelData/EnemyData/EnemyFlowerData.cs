using UnityEngine;
using UnityEngine.Serialization;

namespace EnemyData {
    public class EnemyFlowerData : MonoBehaviour, IEnemyData {
        [FormerlySerializedAs("_baseEnemyData")] [SerializeField] private EnemyTypeData enemyTypeData;
        [SerializeField] private BaseHealerData _baseHealerData;
        [SerializeField] string prefabPath;
        
        public EnemyTypeData TypeData => enemyTypeData;

        public BaseHealerData HealingData => _baseHealerData;
        public string PrefabPath => prefabPath;
        public void Destroy() {
            GameObject.Destroy(gameObject);
        }
    }
}