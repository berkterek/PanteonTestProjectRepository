using PanteonTestProject.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Movements
{
    public class TouchOnRollGround
    {
        Transform _footTransform;
        Collider[] _colliders = new Collider[10];
        LayerMask _layerMask;

        public TouchOnRollGround(Transform footTransform, LayerMask layerMask)
        {
            _footTransform = footTransform;
            _layerMask = layerMask;
        }

        public void TouchOnGround(Transform characterTransform, float maxDistance)
        {
            int hitCount = Physics.OverlapSphereNonAlloc(_footTransform.position, _footTransform.position.y * maxDistance, _colliders, _layerMask);

            for (int i = 0; i < hitCount; i++)
            {
                RollPlatformController rollPlatform = _colliders[i].GetComponentInParent<RollPlatformController>();

                if (rollPlatform != null)
                {
                    Vector3 addForceVector = new Vector3(rollPlatform.MoveForce, 0);
                    characterTransform.transform.position += addForceVector;
                }
            }
        }
    }
}

