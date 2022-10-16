using UnityEngine;

namespace EnemyData {
    public class EnemyTreeData : MonoBehaviour, IEnemyData {
        [SerializeField] private BaseEnemyData _baseEnemyData;
        [SerializeField] string prefabPath;

        public BaseEnemyData Data => _baseEnemyData;

        public BaseHealerData HealingData => null;
        public string PrefabPah => prefabPath;
        public void Destroy() {
            GameObject.Destroy(this);
        }
    }
}