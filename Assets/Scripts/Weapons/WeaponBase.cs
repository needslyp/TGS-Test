using Interfaces;
using UnityEngine;
using Projectiles;

namespace Weapons
{
    public abstract class WeaponBase : MonoBehaviour, IShooter
    {
        [SerializeField] protected GameObject projectilePrefab;
        [SerializeField] protected Transform firePoint;

        [SerializeField] protected float fireRate = 0.2f;
        [SerializeField] protected float projectileSpeed = 0.2f;
        [SerializeField] protected int damage = 10;
        
        protected float NextFireTime;

        public bool CanShoot => Time.time >= NextFireTime;
        public float FireRate { get => fireRate; set => fireRate = value; }

        public abstract void Shoot();

        protected virtual void CreateProjectile()
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation); 
            var rb = projectile.GetComponent<Rigidbody2D>();
            
            if (rb)
                rb.AddForce(firePoint.up * projectileSpeed, ForceMode2D.Impulse);

            var proj = projectile.GetComponent<Projectile>();
            if (proj)
                proj.SetDamage(damage);
            
            Destroy(projectile, 2f);
        }
    }
}
