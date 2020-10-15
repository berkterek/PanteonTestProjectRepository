using PanteonTestProject.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class RotatorObsticleController : ObsticleController
    {
        [SerializeField] float maxSpeed = 20f;
        [SerializeField] float minSpeed = 10f;
        [SerializeField] float currentTurnSpeed;

        private void Start()
        {
            currentTurnSpeed = Random.Range(minSpeed, maxSpeed);
        }

        private void FixedUpdate()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * currentTurnSpeed);
        }
    }
}

