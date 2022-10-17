using QFramework;
using UnityEngine;

namespace GameController {
    public class WeaponController : MonoBehaviour, IController {
        public IArchitecture GetArchitecture() {
            return GameArchitecture.Interface;
        }
    }
}

