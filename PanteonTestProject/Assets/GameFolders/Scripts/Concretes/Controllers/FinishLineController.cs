using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class FinishLineController : MonoBehaviour
    {
        public event System.Action OnRaceFinished;

        private void OnTriggerExit(Collider other)
        {
            OnRaceFinished?.Invoke();
        }
    }
}

