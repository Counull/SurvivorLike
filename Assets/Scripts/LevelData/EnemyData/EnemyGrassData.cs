
    using UnityEngine;
    using UnityEngine.Serialization;

    namespace EnemyData {
        public class EnemyGrassData:MonoBehaviour ,IEnemyData{
           [FormerlySerializedAs("_baseEnemyData")] [SerializeField] private EnemyTypeData enemyTypeData;
           public EnemyTypeData TypeData => enemyTypeData;
           [SerializeField] string prefabPath;
           public BaseHealerData HealingData => null;
           public string PrefabPath => prefabPath;
           public void Destroy() {
               GameObject.Destroy(gameObject);
           }
        }
    }
