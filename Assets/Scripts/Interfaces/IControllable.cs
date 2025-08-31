using UnityEngine;

namespace Interfaces
{
    public interface IControllable
    {
        void Move(Vector2 direction);
        void RotateTowards(Vector2 target);
        void HandleInput();
    }
}
