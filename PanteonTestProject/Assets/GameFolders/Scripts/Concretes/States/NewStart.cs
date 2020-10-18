using PanteonTestProject.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.States
{
    public class NewStart : IState
    {
        Transform _characterTransform;
        float _currentTime = 0f;
        float _maxTime = 3f;

        public bool IsNewStart { get; set; }

        public NewStart(Transform characterTransform)
        {
            _characterTransform = characterTransform;
        }

        public void Enter()
        {
            IsNewStart = true;
            _characterTransform.transform.rotation = Quaternion.identity;
            _currentTime = 0f;
        }

        public void Exit()
        {
            _currentTime = 0f;
        }

        public void Tick()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _maxTime)
            {
                IsNewStart = false;
            }
        }
    }
}

