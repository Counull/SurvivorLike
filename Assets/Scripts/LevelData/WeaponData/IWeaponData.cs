using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace LevelData.WeaponData {
    public enum WeaponType {
        Shooter,
        Surrounder
    }

    public interface IWeaponData {
        string PrefabPath { get; }

        BaseWeaponData BaseWeaponData { get; }

        void Destroy();
    }

    [ShowInInspector, EnableGUI]
    public abstract class BaseWeaponData {
        [NonSerialized, OdinSerialize, ShowInInspector]
        private float _maxDistance = 0f;

        [NonSerialized, OdinSerialize, ShowInInspector]
        private int _count = 0;

    
        private GameObject _prefab;

       public BaseWeaponData() { }

    

        public float MaxDistance {
            get => _maxDistance;
            set => _maxDistance = value;
        }

        public int Count {
            get => _count;
            set => _count = value;
        }

        public abstract WeaponType WeaponType {
            get;
        }

        public GameObject Prefab {
            get => _prefab;
            set => _prefab = value;
        }
    }
}