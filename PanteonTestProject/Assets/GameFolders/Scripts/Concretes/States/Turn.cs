using PanteonTestProject.Abstracts.Movements;
using PanteonTestProject.Abstracts.States;
using PanteonTestProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : IState
{
    IRotator _rotator;
    IMover _mover;
    CheckObsticle _checkObsticle;
    float _turnSpeed = 100f;

    public Turn(IRotator rotator, IMover mover, CheckObsticle checkObsticle)
    {
        _rotator = rotator;
        _checkObsticle = checkObsticle;
        _mover = mover;
    }

    public void Enter()
    {
        _turnSpeed *= _checkObsticle.TurnRight ? 1 : -1;
    }

    public void Exit()
    {
    }

    public void Tick()
    {
        if (_checkObsticle.IsAnyFarObsticle)
        {
            _rotator.Tick(100 * Time.deltaTime);
        }

        _mover.TickFixed(0.3f);
    }
}