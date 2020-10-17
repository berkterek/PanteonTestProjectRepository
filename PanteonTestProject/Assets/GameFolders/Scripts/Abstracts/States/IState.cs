using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Abstracts.States
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Tick();
    }
}

