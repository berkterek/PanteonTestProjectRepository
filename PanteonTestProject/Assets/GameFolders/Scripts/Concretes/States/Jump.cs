using PanteonTestProject.Abstracts.Movements;
using PanteonTestProject.Abstracts.States;
using PanteonTestProject.Animations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.States
{
    public class Jump : IState
    {
        CharacterAnimation _animator;
        CharacterController _characterController;
        IMover _mover;
        Movements.Jump _jumpAction;

        public Jump(CharacterAnimation animator, CharacterController characterController, IMover mover, Movements.Jump jumpAction)
        {
            _animator = animator;
            _characterController = characterController;
            _mover = mover;
            _jumpAction = jumpAction;
        }

        public void Enter()
        {
            if (_characterController.isGrounded)
            {
                _jumpAction.IsJump = true;
                _animator.JumpAnimation(true);
            }
        }

        public void Exit()
        {
            _jumpAction.IsJump = false;
            _animator.JumpAnimation(false);
        }

        public void Tick()
        {
            _mover.TickFixed(1f);

            if (_jumpAction.IsJump)
            {
                _jumpAction.IsJump = false;
            }
        }
    }
}
