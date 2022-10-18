using System.Collections.Generic;
using QFramework;

namespace GameSystem {
    public abstract class AbstractWeaponSystem : AbstractSystem {
        protected List<int> weaponIndex;
        protected bool shouldStop;
        public AbstractWeaponSystem(List<int> weaponIndex) {
            weaponIndex.Capacity = weaponIndex.Count;
            this.weaponIndex = weaponIndex;
        }

        public abstract void Start();

        public abstract void Stop();
    }
}