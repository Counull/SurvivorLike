using QFramework;
using Storage;
using UnityEngine;

namespace Models {
    public class PlayerModel : AbstractModel {
        public BindableProperty<Vector2> playerSpawnPoint = new BindableProperty<Vector2>();
        public BindableProperty<GameObject> playerPrefab = new BindableProperty<GameObject>();
        public BindableProperty<Vector3> playerPosition = new BindableProperty<Vector3>();
        public BindableProperty<float> playerSpeed = new BindableProperty<float>();
        public BindableProperty<float> playerMaxHealth = new BindableProperty<float>();
        public BindableProperty<float> playerCurrentHealth = new BindableProperty<float>();
        public BindableProperty<float> cleanAreaSqr = new BindableProperty<float>();
        public BindableProperty<float> enemySpawnArea = new BindableProperty<float>();
      
        protected override void OnInit() { }
    }
}