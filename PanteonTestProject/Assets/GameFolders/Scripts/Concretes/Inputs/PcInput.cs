﻿using PanteonTestProject.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Inputs
{
    public class PcInput:IPlayerInput
    {
        public float Horizonal => Input.GetAxis("Horizontal");
        public bool Jump => Input.GetButtonDown("Jump");
    }
}
