using System;
using UnityEngine;

namespace Components.Movement
{
    public abstract class MovementBase : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed = 5f;
        [SerializeField] protected float rotationSpeed = 10f;
        
        protected Rigidbody2D rb;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
        public abstract void Move(Vector2 direction);
        public abstract void RotateTowards(Vector2 target);
    }
}
