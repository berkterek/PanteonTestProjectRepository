using PanteonTestProject.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Movements
{
    public class Mover:IMover
    {
        CharacterController _characterController;
        Jump _jump;
        float _moveSpeed;
        
        Vector3 _currentMovement;

        public Mover(CharacterController characterController, Jump jump, float moveSpeed)
        {
            _characterController = characterController;
            _moveSpeed = moveSpeed;
            _jump = jump;
        }

        public void TickFixed(float vertical)
        {
            Vector3 transformDirection = _characterController.transform.TransformDirection(0f, 0f,vertical);
            Vector3 flatMovement = transformDirection * Time.deltaTime * _moveSpeed;
            _currentMovement = new Vector3(flatMovement.x, _currentMovement.y, flatMovement.z);

            if (_jump.IsJump)
            {
                _currentMovement.y = _jump.JumpForce;
                _jump.IsJump = false;
            }
            else if (_characterController.isGrounded)
            {
                _currentMovement.y = 0f;
            }
            else
            {
                _currentMovement.y -= _jump.Gravity * Time.deltaTime;
            }

            _characterController.Move(_currentMovement);
        }
    }
}
