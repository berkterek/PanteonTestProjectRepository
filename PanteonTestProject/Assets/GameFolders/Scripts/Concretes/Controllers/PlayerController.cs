using PanteonTestProject.Abstracts.Controllers;
using PanteonTestProject.Abstracts.Inputs;
using PanteonTestProject.Inputs;

namespace PanteonTestProject.Controllers
{
    public class PlayerController : EntityController
    {
        IPlayerInput _input;

        protected override void Awake()
        {
            _input = new PcInput();
            base.Awake();
        }
        
        private void OnEnable()
        {
            FindObjectOfType<FinishLineController>().OnRaceFinished += HandleFinishRace;
        }

        private void Update()
        {
            if (IsTouchDeadZone || _isRaceFinish) return;
            
            _vertical = _input.Vertical;

            if (_input.Jump && _characterController.isGrounded)
            {
                _jump.IsJump = true;
            }

            _rotator.Tick(_input.MouseX);
        }

        private void FixedUpdate()
        {
            _mover.TickFixed(_vertical);
            
            _animator.MoveLocomotion(_vertical);
            _animator.JumpAnimation(_jump.IsJump && !_characterController.isGrounded);

            if (_jump.IsJump)
            {
                _jump.IsJump = false;
            }

            _touchOnRollGround.TouchOnGround(this.transform,maxDistance);
        }

        protected override void HandleFinishRace()
        {
            _isRaceFinish = true;
            _vertical = 0f;
            _animator.MoveLocomotion(0f);
        }
    }
}

