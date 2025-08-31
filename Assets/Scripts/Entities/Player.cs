using Interfaces;
using UnityEngine;

namespace Entities
{
    public class Player: Entity
    {
        [SerializeField] private Components.Movement.MovementBase movementController;

        protected override void Awake()
        {
            base.Awake();
            
            if (movementController == null)
                movementController = GetComponent<Components.Movement.MovementBase>();
        }

        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (movementController is IControllable controllable)
                controllable.HandleInput();
        }
    }
}
