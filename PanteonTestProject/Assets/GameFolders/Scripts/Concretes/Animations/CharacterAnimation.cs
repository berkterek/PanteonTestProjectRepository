using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Animations
{
    public class CharacterAnimation
    {
        Animator _animator;

        public CharacterAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void MoveLocomotion(float moveSpeed)
        {
            _animator.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));
        }
    }
}

