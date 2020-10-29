using PanteonTestProject.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace PanteonTestProject.Inputs
{
    public class MobileInput : IPlayerInput
    {
        public float Vertical => CrossPlatformInputManager.GetAxis("Vertical");
        public float MouseX => CrossPlatformInputManager.GetAxis("Mouse X");
        public bool Jump => CrossPlatformInputManager.GetButtonDown("Jump");
    }
}

