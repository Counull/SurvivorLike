using System;
using GameController;
using GameSystem;
using QFramework;

public class GameStartCommand : AbstractCommand {
    protected override void OnExecute() {
        var playerSystem = this.GetSystem<PlayerSystem>();
        playerSystem.SpawnPlayer();
        var enemySystem = this.GetSystem<EnemySystem>();
        enemySystem.SpawnEnemy();
    }
}