using UnityEngine;

namespace Entities
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] protected int maxHealth = 100;
        [SerializeField] protected int currentHealth;
    
        public event System.Action<int> OnHealthChanged;
        public event System.Action OnDeath;

        protected virtual void Awake()
        {
            currentHealth = maxHealth;
        }

        public virtual void TakeDamage(int damage)
        {
            currentHealth -= damage;
            OnHealthChanged?.Invoke(currentHealth);
        
            if (currentHealth <= 0)
                Die();
        }

        protected virtual void Die()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
