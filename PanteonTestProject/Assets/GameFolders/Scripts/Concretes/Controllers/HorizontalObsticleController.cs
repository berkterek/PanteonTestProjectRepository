using PanteonTestProject.Abstracts.Controllers;
using PanteonTestProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class HorizontalObsticleController : ObsticleController
    {
        [Header("Move Settings")]
        [SerializeField] float moveSpeed = 0.01f;
        [SerializeField] Vector3 startPosition;

        ObsticleHorizontalMove _mover;

        private void Awake()
        {
            _mover = new ObsticleHorizontalMove(this);
        }

        public void Start()
        {
            _mover.SetStartPosition(startPosition);
        }

        private void FixedUpdate()
        {
            _mover.TickFixed(moveSpeed * Time.deltaTime);
        }
    }
}

