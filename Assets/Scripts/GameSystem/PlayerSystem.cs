using System.Collections;
using Event;
using Models;
using QFramework;
using UnityEngine;

namespace GameSystem {
    public class PlayerSystem : AbstractSystem {
        protected override void OnInit() { }

        private GameObject player;
        private Animator animator;
        private PlayerModels playerModel;

        public void SpawnPlayer() {
            playerModel = this.GetModel<PlayerModels>();
            player = Object.Instantiate<GameObject>(playerModel.playerPrefab.Value, playerModel.playerSpawnPoint.Value,
                Quaternion.identity);
            animator = player.GetComponent<Animator>();
            playerModel.playerPosition.Value = player.transform.position;
            this.SendEvent<PlayerSpawnComplete>(new PlayerSpawnComplete() {player = this.player});
            GameController.GameController.AddUpdateAction(PlayerMove);
        }


        void PlayerMove() {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A)) {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D)) {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W)) {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S)) {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            player.GetComponent<Rigidbody2D>().velocity = playerModel.playerSpeed * dir;
            playerModel.playerPosition.Value = player.transform.position;
        }
    }
}