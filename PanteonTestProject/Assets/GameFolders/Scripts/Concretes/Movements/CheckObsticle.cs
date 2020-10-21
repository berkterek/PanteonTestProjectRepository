using PanteonTestProject.Abstracts.Controllers;
using UnityEngine;

namespace PanteonTestProject.Movements
{
    public class CheckObsticle : MonoBehaviour
    {
        [SerializeField] float radius;
        [SerializeField] LayerMask layerMask;
        [SerializeField] bool isAnyNearObsticle;
        [SerializeField] bool isAnyFarObsticle;

        public bool IsAnyNearObsticle => isAnyNearObsticle;
        public bool IsAnyFarObsticle => isAnyFarObsticle;
        public bool TurnRight { get; private set; }
        public ObsticleController Obsticle { get; private set; }

        Collider[] _hitColliders;
        Quaternion _startingAngle = Quaternion.AngleAxis(-30, Vector3.up);
        Quaternion _steptingAngle = Quaternion.AngleAxis(5, Vector3.up);

        private void Awake()
        {
            _hitColliders = new Collider[10];
        }

        private void Update()
        {
            CheckForGeneralObsticle();
            CheckNearObsticles();
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

        private void CheckNearObsticles()
        {
             _hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);

            foreach (Collider collider in _hitColliders)
            {
                if (collider != null)
                {
                    isAnyNearObsticle = true;
                    return;
                }
            }

           isAnyNearObsticle = false;
        }

        public void CheckForGeneralObsticle()
        {
            float obsticleRadius = 0.5f;

            RaycastHit hit;
            var angle = transform.rotation * _startingAngle;
            var direction = angle * Vector3.forward;
            var position = transform.position;

            for (int i = 0; i < 12; i++)
            {
                if (Physics.Raycast(position,direction,out hit,obsticleRadius))
                {
                    Debug.DrawRay(position, direction * hit.distance, Color.red);
                   isAnyFarObsticle = true;

                    if (i < 6)
                    {
                        TurnRight = true;
                    }
                    else if(i == 6)
                    {
                        TurnRight = Random.Range(0f, 100f) < 50;
                    }
                    else
                    {
                        TurnRight = false;
                    }
                    
                    Obsticle = hit.collider.GetComponent<ObsticleController>();
                    return;
                }

                direction = _steptingAngle * direction;
            }

            isAnyFarObsticle = false;
        }
    }
}

