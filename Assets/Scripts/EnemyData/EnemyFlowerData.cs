using UnityEngine;

namespace EnemyData {
    public class EnemyFlowerData : MonoBehaviour, IEnemyData {
        [SerializeField] private BaseEnemyData _baseEnemyData;
        [SerializeField] private BaseHealerData _baseHealerData;
        [SerializeField] string prefabPath;
        
        public BaseEnemyData Data => _baseEnemyData;

        public BaseHealerData HealingData => _baseHealerData;
        public string PrefabPath => prefabPath;
        public void Destroy() {
            GameObject.Destroy(gameObject);
        }
    }
}