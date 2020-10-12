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

        IPlayerInput _input;
        IMover _mover;
        Jump _jump;
        float _horizantal;

        private void Awake()
        {
            _input = new PcInput();
            _jump = new Jump(gravity,jumpForce);
            _mover = new Mover(GetComponent<CharacterController>(),_jump,moveSpeed);
        }

        private void Update()
        {
            _horizantal = _input.Horizonal;

            if (_input.Jump)
            {
                _jump.IsJump = true;
            }
        }

        private void FixedUpdate()
        {
            _mover.TickFixed(_horizantal);
        }
    }
}

