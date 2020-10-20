using PanteonTestProject.Abstracts.Movements;
using PanteonTestProject.Abstracts.States;
using PanteonTestProject.Animations;
using PanteonTestProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.States
{
    public class Walk : IState
    {
        CharacterAnimation _animator;
        IMover _mover;
        TouchOnRollGround _touchOnRollGround;
        Transform _target;
        System.Action _chooseAction;

        float _randomSpeed;
        float _maxDistance;
        float _lookTime = 0;

        public Walk(Transform target,CharacterAnimation animator, IMover mover, TouchOnRollGround touchOnRollGround, float maxDistance, System.Action chooseAction)
        {
            _animator = animator;
            _mover = mover;
            _maxDistance = maxDistance;
            _touchOnRollGround = touchOnRollGround;
            _chooseAction = chooseAction;
            _target = target;
        }

        public void Enter()
        {
            _randomSpeed = Random.Range(0.5f, 0.7f); //0.5f, 0.8f
            _animator.MoveLocomotion(_randomSpeed);
        }

        public void Exit()
        {
            _chooseAction.Invoke();
            _lookTime = 0f;
        }

        public void Tick()
        {
            _mover.TickFixed(_randomSpeed);

            if (_lookTime > 0.4f)
            {
                _mover.Transform.LookAt(_target, Vector3.up * 10);
            }
            
            _touchOnRollGround.TouchOnGround(_mover.Transform, _maxDistance);
            _lookTime += Time.deltaTime;
        }
    }
}

