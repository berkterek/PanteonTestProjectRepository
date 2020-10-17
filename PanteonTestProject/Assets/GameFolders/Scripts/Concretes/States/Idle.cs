using PanteonTestProject.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.States
{
    public class Idle : IState
    {
        public void Enter()
        {
            Debug.Log("Enter idle state");
        }

        public void Exit()
        {
            Debug.Log("Exit idle state");
        }

        public void Tick()
        {
            Debug.Log("Tick idle state");
        }
    }
}
