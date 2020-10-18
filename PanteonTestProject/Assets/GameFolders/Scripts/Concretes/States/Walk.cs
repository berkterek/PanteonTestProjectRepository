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
        CharacterController _characterController;
        System.Action _chooseAction;

        float _randomSpeed;
        float _maxDistance;

        public Walk(CharacterAnimation animator, CharacterController characterController, IMover mover, TouchOnRollGround touchOnRollGround, float maxDistance, System.Action chooseAction)
        {
            _animator = animator;
            _mover = mover;
            _maxDistance = maxDistance;
            _touchOnRollGround = touchOnRollGround;
            _characterController = characterController;
            _chooseAction = chooseAction;
        }

        public void Enter()
        {
            Debug.Log("Walk");
            _randomSpeed = Random.Range(0.5f, 0.8f); //0.3f,1f
            _animator.MoveLocomotion(_randomSpeed);
        }

        public void Exit()
        {
            _chooseAction.Invoke();
        }

        public void Tick()
        {            
            _mover.TickFixed(_randomSpeed);
            _touchOnRollGround.TouchOnGround(_characterController.transform, _maxDistance);
        }
    }
}

