using PanteonTestProject.Abstracts.Inputs;
using PanteonTestProject.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        IPlayerInput _input;

        private void Awake()
        {
            _input = new PcInput();
        }
    }
}

