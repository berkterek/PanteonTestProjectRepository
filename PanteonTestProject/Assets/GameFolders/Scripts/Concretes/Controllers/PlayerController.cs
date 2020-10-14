using PanteonTestProject.Abstracts.Inputs;
using PanteonTestProject.Abstracts.Movements;
using PanteonTestProject.Animations;
using PanteonTestProject.Inputs;
using PanteonTestProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] float gravity = 0.5f; //0.5f
        [SerializeField] float jumpForce = 0.2f; //0.11f
        [SerializeField] float moveSpeed = 10f; //2f
        [SerializeField] float turnSpeed = 5f; //100f

        IPlayerInput _input;
        IMover _mover;
        IRotator _rotator;
        CharacterAnimation _animator;
        CharacterController _characterController;
        Jump _jump;
        float _vertical;

        public bool IsTouchDeadZone { get; set; }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _input = new PcInput();
            _jump = new Jump(gravity, jumpForce);
            _animator = new CharacterAnimation(GetComponent<Animator>());
            _mover = new Mover(_characterController, _jump, moveSpeed);
            _rotator = new Rotator(this.transform, turnSpeed);
        }

        private void Start()
        {
            IsTouchDeadZone = false;
        }

        private void Update()
        {
            if (IsTouchDeadZone) return;
            
            _vertical = _input.Vertical;

            if (_input.Jump && _characterController.isGrounded)
            {
                _jump.IsJump = true;
            }

            _rotator.Tick(_input.MouseX);
        }

        private void FixedUpdate()
        {
            if (_characterController != null)
            {
                _mover.TickFixed(_vertical);
            }
            
            _animator.MoveLocomotion(_vertical);
            _animator.JumpAnimation(_jump.IsJump && !_characterController.isGrounded);

            if (_jump.IsJump)
            {
                _jump.IsJump = false;
            }
        }

        public void SetPosition(Vector3 newPosition)
        {
            _mover.SetStartPosition(newPosition);
        }
    }
}

