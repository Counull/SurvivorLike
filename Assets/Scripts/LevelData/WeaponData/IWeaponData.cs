namespace LevelData.WeaponData {
   public enum WeaponType {
        Shooter,
        Surrounder
    }

    public interface IWeaponData {
        string PrefabPath { get; }
        WeaponType WeaponType { get; }
        void Destroy();
    }
}