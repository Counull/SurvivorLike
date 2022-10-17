using UnityEngine;
using UnityEngine.Serialization;

namespace LevelData.WeaponData {
    public class WeaponDataInput : MonoBehaviour, IWeaponData {
        [SerializeField] private string prefabPath;
        [SerializeField] WeaponType weaponType;
        public string PrefabPath => prefabPath;
        public WeaponType WeaponType => weaponType;


        public void Destroy() {
            Object.Destroy(gameObject);
        }
    }
}