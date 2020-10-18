using PanteonTestProject.Abstracts.Controllers;
using System.Collections;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class RotatingStickController : MonoBehaviour
    {
        [SerializeField] float pushForce = 10f;
        [SerializeField] int maxLoop = 10;
        [SerializeField] float waitTime = 0.1f;

        private void OnTriggerEnter(Collider other)
        {
            EntityController entityController = other.GetComponent<EntityController>();

            if (entityController != null)
            {
                StartCoroutine(PushBack(entityController));
            }
        }

        private IEnumerator PushBack(EntityController entityController)
        {
            entityController.GetComponent<CharacterController>().enabled = false;

            int i = 0;
            while (i < maxLoop)
            {
                entityController.transform.position += -entityController.transform.forward * pushForce * Time.deltaTime;
                i++;
                yield return new WaitForSeconds(waitTime);
            }

            entityController.GetComponent<CharacterController>().enabled = true;
        }
    }
}

