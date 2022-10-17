using System;
using GameController;
using GameSystem;
using QFramework;

public class GameStartCommand : AbstractCommand {
    protected override void OnExecute() {
        this.GetSystem<SurrounderSystem>()?.Start();
        this.GetSystem<PlayerSystem>()?.SpawnPlayer();
        this.GetSystem<EnemySystem>()?.StartSpanEnemy();
        this.GetSystem<ShooterSystem>()?.Start();
    }
}