using QFramework;
using UnityEngine;

namespace GameController {
    public class EnemyController : MonoBehaviour, IController {
        public IArchitecture GetArchitecture() {
            return GameArchitecture.Interface;
        }
    }
}