using System;
using UnityEngine;
using UnityEngine.Serialization;
//遇到碰撞器还是得往怪物上贴MonoBehavior 纯纯小丑代码 CNM
namespace EnemyData {
    public interface IEnemyData {
        EnemyTypeData TypeData { get; }
        BaseHealerData HealingData { get; }

        string PrefabPath { get; }
        void Destroy();
    }


    [System.Serializable]
    public  class EnemyTypeData {
        public float Speed {
            get => speed;
            set => speed = value;
        }

        public float Health {
            get => health;
            set => health = value;
        }

        public float Damage {
            get => damage;
            set => damage = value;
        }

        public float SpawnRatio {
            get => spawnRatio;
            set => spawnRatio = value;
        }

        public GameObject Prefab {
            get => _prefab;
            set => _prefab = value;
        }
        private GameObject _prefab;
        [SerializeField] float speed;
        [SerializeField] float health;
        [SerializeField] float damage;
        [SerializeField] float spawnRatio;
    }
}


public abstract class BaseHealerData {
    public float Healing { get; }
}