using PanteonTestProject.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.States
{
    public class NpcStateMachine
    {
        List<StateTransition> _stateTransitions = new List<StateTransition>();
        List<StateTransition> _anyTransitions = new List<StateTransition>();

        IState _currentState;

        public void SetState(IState state)
        {
            if (_currentState == state) return;

            _currentState?.Exit();

            _currentState = state;

            _currentState.Enter();
        }

        public void Tick()
        {
            StateTransition stateTranstion = GetNextStateTransition();

            if (stateTranstion != null)
            {
                SetState(stateTranstion.To);
            }

            _currentState.Tick();
        }

        private StateTransition GetNextStateTransition()
        {
            foreach (StateTransition stateTrasition in _anyTransitions)
            {
                if (stateTrasition.Condition.Invoke()) return stateTrasition;
            }

            foreach (StateTransition stateTransition in _stateTransitions)
            {
                if (stateTransition.From == _currentState && stateTransition.Condition.Invoke()) return stateTransition;
            }

            return null;
        }

        public void AddStateTransition(IState from, IState to,System.Func<bool> condition)
        {
            _stateTransitions.Add(new StateTransition(from, to, condition));
        }

        public void AddAnyStateTransition(IState to, System.Func<bool> condition)
        {
            _anyTransitions.Add(new StateTransition(null, to, condition));
        }
    }
}

