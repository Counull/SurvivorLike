using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Command;
using EnemyData;
using GameSystem;
using Models;
using QFramework;
using Storage;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameController {
    public class GameController : MonoBehaviour, IController {
        // Start is called before the first frame update

        static readonly List<IEnumerator> CoroutineList = new List<IEnumerator>(1);
        private static Action _mUpdateAction;
        public static void AddUpdateAction(Action fun) => _mUpdateAction += fun;
        public static void RemoveUpdateAction(Action fun) => _mUpdateAction -= fun;

        public static void QueueCoroutine(IEnumerator enumerator) {
            CoroutineList.Add(enumerator);
        }

        void Start() {
            var playerData = GetComponentInChildren<IPlayerData>();
            var enemyData = GetComponentsInChildren<IEnemyData>();
            this.SendCommand(new DataLoadCommand(playerData, enemyData));
            this.SendCommand(new GameStartCommand());
        }

        private void Update() {
            _mUpdateAction?.Invoke();
            foreach (var c in CoroutineList) {
                StartCoroutine(c);
            }

            CoroutineList.Clear();
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
            this.RegisterSystem(new EnemySystem());
            this.RegisterModel(new PlayerModels());
            this.RegisterModel(new EnemyModel());
            this.RegisterUtility(new PlayerStorage());
        }
    }
}