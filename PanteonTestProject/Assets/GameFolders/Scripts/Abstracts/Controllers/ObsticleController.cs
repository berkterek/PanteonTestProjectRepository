using PanteonTestProject.Controllers;
using System.Collections;
using UnityEngine;

namespace PanteonTestProject.Abstracts.Controllers
{
    public abstract class ObsticleController : MonoBehaviour
    {
        [Header("Touch Settings")]
        [SerializeField] StartLineController startController;
        [SerializeField] float waitTime = 0.5f;

        protected virtual void OnTriggerEnter(Collider collider)
        {
            EntityController entityController = collider.GetComponent<EntityController>();

            if (entityController != null)
            {
                StartCoroutine(WaitAndProcess(entityController));
            }
        }        

        protected virtual IEnumerator WaitAndProcess(EntityController entityController)
        {
            entityController.GetComponent<CharacterController>().enabled = false;
            entityController.IsTouchDeadZone = true;
            entityController.transform.position = startController.GetStartPosition();
            entityController.SetPosition(startController.GetStartPosition());

            yield return new WaitForSeconds(waitTime);

            entityController.IsTouchDeadZone = false;
            entityController.GetComponent<CharacterController>().enabled = true;
        }
    }
}

