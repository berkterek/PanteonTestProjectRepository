using UnityEngine;

namespace PanteonTestProject.Abstracts.Movements
{
    public interface IMover
    {
        void TickFixed(float vertical);
        void SetStartPosition(Vector3 newPosition);
    }
}
