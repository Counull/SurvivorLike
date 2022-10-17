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
        private PlayerModel _playerModel;

        public void SpawnPlayer() {
            _playerModel = this.GetModel<PlayerModel>();
            player = Object.Instantiate<GameObject>(_playerModel.playerPrefab.Value, _playerModel.playerSpawnPoint.Value,
                Quaternion.identity);
            animator = player.GetComponent<Animator>();
            _playerModel.playerPosition.Value = player.transform.position;
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

            player.GetComponent<Rigidbody2D>().velocity = _playerModel.playerSpeed * dir;
            _playerModel.playerPosition.Value = player.transform.position;
        }
    }
}