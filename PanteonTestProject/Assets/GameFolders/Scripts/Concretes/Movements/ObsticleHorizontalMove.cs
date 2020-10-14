using PanteonTestProject.Abstracts.Controllers;
using PanteonTestProject.Abstracts.Movements;
using PanteonTestProject.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Movements
{
    public class ObsticleHorizontalMove : IMover
    {
        ObsticleController _controller;

        public ObsticleHorizontalMove(ObsticleController controller)
        {
            _controller = controller;
        }

        public void TickFixed(float vertical)
        {
            float yMove = Mathf.Cos(Time.time);
            _controller.transform.position += Vector3.up * yMove * vertical;
        }

        public void SetStartPosition(Vector3 newPosition)
        {
            _controller.transform.position = newPosition;
        }
    }
}

