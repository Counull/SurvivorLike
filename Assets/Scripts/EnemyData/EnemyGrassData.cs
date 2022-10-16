
    using UnityEngine;

    namespace EnemyData {
        public class EnemyGrassData:MonoBehaviour ,IEnemyData{
           [SerializeField] private BaseEnemyData _baseEnemyData;
           public BaseEnemyData Data => _baseEnemyData;
           [SerializeField] string prefabPath;
           public BaseHealerData HealingData => null;
           public string PrefabPah => prefabPath;
           public void Destroy() {
               GameObject.Destroy(this);
           }
        }
    }
