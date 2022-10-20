using UnityEngine;
using UnityEngine.Serialization;

namespace EnemyData {
    public class EnemyTreeData : MonoBehaviour, IEnemyData {
        [FormerlySerializedAs("_baseEnemyData")] [SerializeField] private EnemyTypeData enemyTypeData;
        [SerializeField] string prefabPath;

        public EnemyTypeData TypeData => enemyTypeData;

        public BaseHealerData HealingData => null;
        public string PrefabPath => prefabPath;
        public void Destroy() {
            GameObject.Destroy(gameObject);
        }
    }
}