using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace LevelData.WeaponData {
    [ShowInInspector,EnableGUI]
    public class ShooterWeaponData : BaseWeaponData {
    
        [NonSerialized, OdinSerialize,ShowInInspector] private float shootInterval = 0f;
        [NonSerialized, OdinSerialize,ShowInInspector] private float continuousFireInterval = 0f;


        public float ShootInterval {
            get => shootInterval;
            set => shootInterval = value;
        }

        public float ContinuousFireInterval {
            get => continuousFireInterval;
            set => continuousFireInterval = value;
        }

        public override WeaponType WeaponType => WeaponType.Shooter;
    }
}