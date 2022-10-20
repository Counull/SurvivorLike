using UnityEngine;
using UnityEngine.Serialization;

namespace EnemyData {
    public class EnemyBushData : MonoBehaviour, IEnemyData {
       [SerializeField]  EnemyTypeData enemyTypeData;
        [SerializeField] string prefabPath;

        public EnemyTypeData TypeData => enemyTypeData;
        public BaseHealerData HealingData => null;
        public string PrefabPath => prefabPath;
        public void Destroy() {
            GameObject.Destroy(gameObject);
        }
    }
}