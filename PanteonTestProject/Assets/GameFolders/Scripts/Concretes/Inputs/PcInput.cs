using PanteonTestProject.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Inputs
{
    public class PcInput:IPlayerInput
    {
        public float Vertical => Input.GetAxis("Vertical");
        public float MouseX => Input.GetAxis("Mouse X");
        public bool Jump => Input.GetButtonDown("Jump");
    }
}

