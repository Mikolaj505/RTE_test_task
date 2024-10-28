namespace MKubiak.RTETestTask.Weapons
{
    public interface IWeaponController
    {
        void AddAmmo(float amount);
        void OnFireDown();
        WeaponConfig GetWeaponConfig();
    }
}