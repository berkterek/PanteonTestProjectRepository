using PanteonTestProject.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class HalfDonutObsticleController : ObsticleController
    {
        [SerializeField] GameObject moveStick;
        [SerializeField] float moveSpeed = 3f; //0.003f

        private void Start()
        {
            HalfTriggeredController[] halfTriggeredControllers = GetComponentsInChildren<HalfTriggeredController>();

            foreach (HalfTriggeredController halfTriggeredController in halfTriggeredControllers)
            {
                halfTriggeredController.OnTriggered += HandleOnTriggered;
            }
        }

        private void HandleOnTriggered(EntityController entityController)
        {
            StartCoroutine(WaitAndProcess(entityController));
        }

        private void FixedUpdate()
        {
            moveStick.transform.position += Vector3.right * moveSpeed *  Mathf.Sin(Time.time);
        }
    }
}

