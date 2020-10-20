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
        [SerializeField] Transform target;

        NpcStateMachine _npcStateMachine;
        CheckObsticle _checkObsticle;
        ChooseState _chooseState;

        protected override void Awake()
        {
            base.Awake();
            _npcStateMachine = new NpcStateMachine();
            _checkObsticle = GetComponent<CheckObsticle>();
            _chooseState = ChooseState.Turn;
        }

        protected override void Start()
        {
            base.Start();

            Idle idle = new Idle(this.transform, _animator, _mover, _touchOnRollGround, maxDistance);
            Walk walk = new Walk(target,_animator, _mover, _touchOnRollGround, maxDistance,ChooseWalkToAnotherState);
            NewStart newStart = new NewStart(this.transform);
            States.Jump jump = new States.Jump(_animator,_characterController,_mover,_jump);
            Turn turn = new Turn(_rotator, _mover, _checkObsticle);
            FinishRace finishRace = new FinishRace();

            _npcStateMachine.AddStateTransition(idle, walk, () => !idle.IsIdle);
            _npcStateMachine.AddStateTransition(jump, walk, () => !_jump.IsJump);
            _npcStateMachine.AddStateTransition(turn, walk, () => !_checkObsticle.IsAnyFarObsticle);

            _npcStateMachine.AddStateTransition(walk, idle, () =>
            _checkObsticle.IsAnyNearObsticle && _checkObsticle.Obsticle is HorizontalObsticleController);
            
            _npcStateMachine.AddStateTransition(walk, jump, () =>
            _checkObsticle.IsAnyNearObsticle && _chooseState == ChooseState.Jump);
            
            _npcStateMachine.AddStateTransition(walk, turn, () => 
            _chooseState == ChooseState.Turn && _checkObsticle.IsAnyFarObsticle);

            _npcStateMachine.AddStateTransition(newStart, idle, () => !newStart.IsNewStart);

            _npcStateMachine.AddAnyStateTransition(newStart, () => IsTouchDeadZone);
            _npcStateMachine.AddAnyStateTransition(finishRace, () => _isRaceFinish);

            _npcStateMachine.SetState(idle);
        }

        private void FixedUpdate()
        {
            _npcStateMachine.Tick();
        }

        private void ChooseWalkToAnotherState()
        {
            int index = Random.Range(0, 2);
            
            switch (index)
            {
                case 0:
                    _chooseState = ChooseState.Turn;
                    break;
                case 1:
                    _chooseState = ChooseState.Jump;
                    break;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<FinishLineController>() != null)
            {
                HandleFinishRace();
            }
        }
    }
}

