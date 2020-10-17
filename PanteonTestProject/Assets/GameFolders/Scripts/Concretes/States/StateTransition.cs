using PanteonTestProject.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.States
{
    public class StateTransition
    {
        public IState From { get; private set; }
        public IState To { get; private set; }
        public System.Func<bool> Condition { get; private set; }

        public StateTransition(IState from, IState to, System.Func<bool> condition)
        {
            From = from;
            To = to;
            Condition = condition;
        }
    }
}
