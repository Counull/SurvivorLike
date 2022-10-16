using Cinemachine;
using Event;
using QFramework;
using UnityEngine;

namespace GameSystem {
    public class MainCameraSystem : AbstractSystem {
        private Camera mainCamera;
        private CinemachineVirtualCamera virtualCamera;


        protected override void OnInit() {
            mainCamera = Camera.main;
            GameObject vCamGameObject = GameObject.FindWithTag("VirtualCamera");
            virtualCamera = vCamGameObject.GetComponent<CinemachineVirtualCamera>();
            this.RegisterEvent<PlayerSpawnComplete>(FollowPlayer);
        }

        void FollowPlayer(PlayerSpawnComplete e) {
            virtualCamera.Follow = e.player.transform;
        }
    }
}