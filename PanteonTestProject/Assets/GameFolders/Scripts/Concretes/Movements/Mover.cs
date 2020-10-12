﻿using PanteonTestProject.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Movements
{
    public class Mover:IMover
    {
        CharacterController _characterController;
        Jump _jump;
        //IPlayerInput _input;
        float _moveSpeed;
        //float _gravity = 0.5f;
        //float _jumpForce = 0.2f;
        
        Vector3 _currentMovement;

        public Mover(CharacterController characterController, Jump jump, float moveSpeed)
        {
            _characterController = characterController;
            //_input = input;
            _moveSpeed = moveSpeed;
            _jump = jump;
        }

        public void TickFixed(float horizontal)
        {
            Vector3 transformDirection = _characterController.transform.TransformDirection(horizontal,0f,0f);
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