using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace LevelData.WeaponData {
    
    public class WeaponDataInput : SerializedMonoBehaviour, IWeaponData {
        [SerializeField] private string prefabPath;

      
        [NonSerialized, OdinSerialize,ShowInInspector] private BaseWeaponData _baseWeaponData;
        public string PrefabPath => prefabPath;
        public WeaponType WeaponType => _baseWeaponData.WeaponType;
        public BaseWeaponData BaseWeaponData => _baseWeaponData;

     


        public void Destroy() {
            Object.Destroy(gameObject);
        }
    }
}