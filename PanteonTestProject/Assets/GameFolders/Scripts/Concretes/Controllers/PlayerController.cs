using PanteonTestProject.Abstracts.Inputs;
using PanteonTestProject.Abstracts.Movements;
using PanteonTestProject.Inputs;
using PanteonTestProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movements")]
        [SerializeField] float gravity = 0.5f;
        [SerializeField] float jumpForce = 0.2f;
        [SerializeField] float moveSpeed = 10f;
        [SerializeField] float turnSpeed = 5f;

        IPlayerInput _input;
        IMover _mover;
        IRotator _rotator;
        Jump _jump;
        float _vertical;

        private void Awake()
        {
            _input = new PcInput();
            _jump = new Jump(gravity,jumpForce);
            _mover = new Mover(GetComponent<CharacterController>(),_jump,moveSpeed);
            _rotator = new Rotator(this.transform, turnSpeed);
        }

        private void Update()
        {
            _vertical = _input.Vertical;

            if (_input.Jump)
            {
                _jump.IsJump = true;
            }

            _rotator.Tick(_input.MouseX);
        }

        private void FixedUpdate()
        {
            _mover.TickFixed(_vertical);
        }
    }
}

