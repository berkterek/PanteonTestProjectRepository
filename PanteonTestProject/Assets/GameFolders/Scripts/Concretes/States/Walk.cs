using PanteonTestProject.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.States
{
    public class Walk : IState
    {
        public void Enter()
        {
            Debug.Log("Enter walk state");
        }

        public void Exit()
        {
            Debug.Log("Exit walk state");
        }

        public void Tick()
        {
            Debug.Log("Tick walk state");
        }
    }
}

