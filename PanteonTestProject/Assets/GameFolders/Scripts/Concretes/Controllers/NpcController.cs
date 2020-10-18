using PanteonTestProject.Abstracts.Controllers;
using PanteonTestProject.Enums;
using PanteonTestProject.Movements;
using PanteonTestProject.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class NpcController : EntityController
    {
        NpcStateMachine _npcStateMachine;
        CheckObsticle _checkObsticle;
        ChooseState _chooseState;

        protected override void Awake()
        {
            base.Awake();
            _npcStateMachine = new NpcStateMachine();
            _checkObsticle = GetComponent<CheckObsticle>();
        }

        protected override void Start()
        {
            base.Start();

            Idle idle = new Idle(this.transform, _animator, _mover, _touchOnRollGround, maxDistance);
            Walk walk = new Walk(_animator, _characterController, _mover, _touchOnRollGround, maxDistance,ChooseWalkToAnotherState);
            NewStart newStart = new NewStart(this.transform);
            States.Jump jump = new States.Jump(_animator,_characterController,_mover,_jump);

            _npcStateMachine.AddStateTransition(idle, walk, () => !idle.IsIdle);
            _npcStateMachine.AddStateTransition(jump, walk, () => !_jump.IsJump);

            _npcStateMachine.AddStateTransition(walk, idle, () => _checkObsticle.IsAnyObsticle && _chooseState == ChooseState.Idle);
            _npcStateMachine.AddStateTransition(walk, jump, () => _checkObsticle.IsAnyObsticle && _chooseState == ChooseState.Jump);

            _npcStateMachine.AddStateTransition(newStart, idle, () => !newStart.IsNewStart);

            _npcStateMachine.AddAnyStateTransition(newStart, () => IsTouchDeadZone);

            _npcStateMachine.SetState(idle);
        }

        private void FixedUpdate()
        {
            _npcStateMachine.Tick();
        }

        protected override void HandleFinishRace()
        {
            Debug.Log(this.gameObject.name + " finish race");
        }

        private void ChooseWalkToAnotherState()
        {
            int index = Random.Range(0, 2);

            //_chooseState = ChooseState.Jump;
            switch (index)
            {
                case 0:
                    _chooseState = ChooseState.Idle;
                    break;
                case 1:
                    _chooseState = ChooseState.Jump;
                    break;
                default:
                    _chooseState = ChooseState.Turn;
                    break;
            }
        }
    }
}

