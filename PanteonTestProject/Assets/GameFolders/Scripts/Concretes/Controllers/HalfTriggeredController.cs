using PanteonTestProject.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class HalfTriggeredController : MonoBehaviour
    {
        public event System.Action<EntityController> OnTriggered;

        private void OnTriggerEnter(Collider other)
        {
            EntityController entityController = other.GetComponent<EntityController>();

            if (entityController != null)
            {
                OnTriggered?.Invoke(entityController);
            }
        }
    }
}

