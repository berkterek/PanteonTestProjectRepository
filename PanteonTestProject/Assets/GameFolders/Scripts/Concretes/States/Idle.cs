using PanteonTestProject.Abstracts.Movements;
using PanteonTestProject.Abstracts.States;
using PanteonTestProject.Animations;
using PanteonTestProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.States
{
    public class Idle : IState
    {
        CharacterAnimation _animator;
        IMover _mover;
        TouchOnRollGround _touchOnRollGround;
        Transform _characterTransform;
        float _maxDistance;
        float _currentTime = 0f;
        float _maxTime;

        public bool IsIdle { get; private set; }

        public Idle(Transform characterTransform,CharacterAnimation animator,IMover mover,TouchOnRollGround touchOnRollGround,float maxDistance)
        {
            _animator = animator;
            _mover = mover;
            _touchOnRollGround = touchOnRollGround;
            _maxDistance = maxDistance;
            _characterTransform = characterTransform;
            IsIdle = true;
        }

        public void Enter()
        {
            _maxTime = Random.Range(1f, 3f);
            _animator.MoveLocomotion(0f);
        }

        public void Exit()
        {
            _currentTime = 0f;
            IsIdle = true;
        }

        public void Tick()
        {
            _mover.TickFixed(0f);
            _touchOnRollGround.TouchOnGround(_characterTransform, _maxDistance);

            _currentTime += Time.deltaTime;

            if (_currentTime > _maxTime)
            {
                IsIdle = false;
            }
        }
    }
}
