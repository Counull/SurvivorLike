using System;
using Sirenix.OdinInspector;

namespace LevelData.WeaponData {
    [ShowInInspector, EnableGUI]
    public class SurrounderWeaponData : BaseWeaponData {
        public override WeaponType WeaponType => WeaponType.Surrounder;
    }
}