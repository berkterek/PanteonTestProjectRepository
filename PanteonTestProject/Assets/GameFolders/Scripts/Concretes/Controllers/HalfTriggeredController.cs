using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class HalfTriggeredController : MonoBehaviour
    {
        public event System.Action<PlayerController> OnTriggered;

        private void OnTriggerEnter(Collider other)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                OnTriggered?.Invoke(playerController);
            }
        }
    }
}

