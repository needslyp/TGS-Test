using Interfaces;
using UnityEngine;

namespace Components.Movement
{
    public class PlayerMovement : MovementBase, IControllable
    {
        private Camera _cam;

        protected override void Awake()
        {
            base.Awake();
            _cam = Camera.main;
        } 

        public override void Move(Vector2 direction)
        {
            if (rb != null)
                rb.velocity = direction * moveSpeed;
        }

        public override void RotateTowards(Vector2 target)
        {
            var direction = target - (Vector2)transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            if (rb != null)
                rb.rotation = angle;
        }

        public void HandleInput()
        {
            var movement = new Vector2(
                Input.GetAxis("Horizontal"), 
                Input.GetAxis("Vertical")
            ).normalized;
            
            Move(movement);

            if (_cam == null) return;
            Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            RotateTowards(mousePos);
        }
    }
}
