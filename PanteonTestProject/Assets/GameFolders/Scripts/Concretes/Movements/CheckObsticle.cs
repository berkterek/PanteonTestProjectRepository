using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Movements
{
    public class CheckObsticle : MonoBehaviour
    {
        [SerializeField] float maxDistance;
        [SerializeField] float radius;
        [SerializeField] LayerMask layerMask;
        [SerializeField] bool _isAnyObsticle;

        public bool IsAnyObsticle => _isAnyObsticle;

        Collider[] _hitColliders;

        private void Awake()
        {
            _hitColliders = new Collider[10];
        }

        private void Update()
        {
            CheckObsticles();
        }

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        private void CheckObsticles()
        {
             _hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);

            foreach (Collider collider in _hitColliders)
            {
                if (collider != null)
                {
                    _isAnyObsticle = true;
                    return;
                }
            }

            _isAnyObsticle = false;
        }
    }
}

