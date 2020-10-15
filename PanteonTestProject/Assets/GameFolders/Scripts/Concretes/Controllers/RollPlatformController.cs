using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class RollPlatformController : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 5f;
        [SerializeField] float forceSpeed = 0.001f;

        public float MoveForce => forceSpeed;

        private void FixedUpdate()
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }
}
