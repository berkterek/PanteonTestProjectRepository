using PanteonTestProject.Abstracts.Movements;
using PanteonTestProject.Animations;
using PanteonTestProject.Controllers;
using PanteonTestProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Abstracts.Controllers
{
    public abstract class EntityController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] protected float gravity = 0.5f; //0.5f
        [SerializeField] protected float jumpForce = 0.2f; //0.11f
        [SerializeField] protected float moveSpeed = 10f; //2f
        [SerializeField] protected float turnSpeed = 5f; //100f
        [SerializeField] protected float maxDistance = 1f;
        [SerializeField] protected LayerMask layerMask;

        [Header("Transforms")]
        [SerializeField] Transform footTransform;

        protected IMover _mover;
        protected IRotator _rotator;
        protected CharacterAnimation _animator;
        protected CharacterController _characterController;
        protected TouchOnRollGround _touchOnRollGround;
        protected Jump _jump;
        protected float _vertical;
        protected bool _isRaceFinish;

        public bool IsTouchDeadZone { get; set; }

        protected virtual void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _jump = new Jump(gravity, jumpForce);
            _animator = new CharacterAnimation(GetComponent<Animator>());
            _mover = new Mover(_characterController, _jump, moveSpeed);
            _rotator = new Rotator(this.transform, turnSpeed);
            _touchOnRollGround = new TouchOnRollGround(footTransform, layerMask);
        }

        protected virtual void Start()
        {
            IsTouchDeadZone = false;
            _isRaceFinish = false;
        }

        protected virtual void OnEnable()
        {
            FindObjectOfType<FinishLineController>().OnRaceFinished += HandleFinishRace;
        }

        protected virtual void OnDisable()
        {
            FindObjectOfType<FinishLineController>().OnRaceFinished -= HandleFinishRace;
        }

        protected abstract void HandleFinishRace();

        public void SetPosition(Vector3 newPosition)
        {
            _mover.SetStartPosition(newPosition);
        }
    }
}

