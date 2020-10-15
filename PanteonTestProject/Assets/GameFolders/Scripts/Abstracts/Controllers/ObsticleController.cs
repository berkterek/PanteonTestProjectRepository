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
            PlayerController playerController = collider.GetComponent<PlayerController>();

            if (playerController != null)
            {
                StartCoroutine(WaitAndProcess(playerController));
            }
        }        

        protected virtual IEnumerator WaitAndProcess(PlayerController playerController)
        {
            playerController.GetComponent<CharacterController>().enabled = false;
            playerController.IsTouchDeadZone = true;
            playerController.transform.position = startController.GetStartPosition();
            playerController.SetPosition(startController.GetStartPosition());

            yield return new WaitForSeconds(waitTime);

            playerController.IsTouchDeadZone = false;
            playerController.GetComponent<CharacterController>().enabled = true;
        }
    }
}

