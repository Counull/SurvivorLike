using QFramework;
using Storage;
using UnityEngine;

namespace Models {
    public class PlayerModels : AbstractModel {
        public BindableProperty<float> health = new BindableProperty<float>() {
            Value = 1.0f
        };

        public BindableProperty<Vector2> playerSpawnPoint = new BindableProperty<Vector2>();
        public BindableProperty<GameObject> playerPrefab = new BindableProperty<GameObject>();
        public BindableProperty<float> playerSpeed = new BindableProperty<float>();
        protected override void OnInit() {
         
        }
    }
}