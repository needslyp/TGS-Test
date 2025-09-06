using System;
using Entities;
using UnityEngine;

namespace Projectiles
{
    public sealed class Projectile: MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        [SerializeField] private GameObject impactEffect;
        
        private bool _isInitialized = false;
        
        public void SetDamage(int value) => damage = value;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isInitialized) return;
            
            var entity = other.GetComponent<Entity>();
            if (entity)
            {
                entity.TakeDamage(damage);
                OnImpact();
            }
            
            Destroy(gameObject);
        }

        private void OnImpact()
        {
            if  (impactEffect)
                Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        public void Initialize(Vector2 direction, float speed)
        {
            var rb = GetComponent<Rigidbody2D>();
            if (rb)
                rb.velocity = direction * speed;
            
            _isInitialized = true;
        }
    }
}
