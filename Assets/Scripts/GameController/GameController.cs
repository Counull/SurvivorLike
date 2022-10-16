using System;
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


        private static Action mUpdateAction;
        public static void AddUpdateAction(Action fun) => mUpdateAction += fun;
        public static void RemoveUpdateAction(Action fun) => mUpdateAction -= fun;


        void Start() {
            this.SendCommand(new DataLoadCommand(GetComponentInChildren<ILevelData>()));
            this.SendCommand(new GameStartCommand());
        }

        private void Update() {
            mUpdateAction?.Invoke();
        }


        public IArchitecture GetArchitecture() {
            return GameArchitecture.Interface;
        }
    }


    public class GameArchitecture : Architecture<GameArchitecture> {
        protected override void Init() {
            this.RegisterSystem(new GameSystem.GameSystem());
            this.RegisterSystem(new PlayerSystem());
            this.RegisterSystem(new MainCameraSystem());
            this.RegisterModel(new PlayerModels());
            this.RegisterUtility(new PlayerStorage());
        }
    }
}