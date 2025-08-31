namespace Interfaces
{
    public interface IShooter
    {
        void Shoot();
        bool CanShoot {  get; }
        float FireRate { get; set; }
    }
}
