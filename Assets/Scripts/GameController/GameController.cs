using System.Runtime.InteropServices;
using Command;
using GameSystem;
using Models;
using QFramework;
using Storage;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameController {
    public class GameController : MonoBehaviour, IController {
        // Start is called before the first frame update
        void Start() {
            this.SendCommand(new DataLoadCommand(GetComponentInChildren<ILevelData>()));
            this.SendCommand(new GameStartCommand());
        }

        // Update is called once per frame
        void Update() { }

        public IArchitecture GetArchitecture() {
            return GameArchitecture.Interface;
        }
    }


    public class GameArchitecture : Architecture<GameArchitecture> {
        protected override void Init() {
            this.RegisterSystem(new GameSystem.GameSystem());
            this.RegisterSystem(new PlayerSystem());
            this.RegisterModel(new PlayerModels());
            this.RegisterUtility(new PlayerStorage());
        }
    }
}