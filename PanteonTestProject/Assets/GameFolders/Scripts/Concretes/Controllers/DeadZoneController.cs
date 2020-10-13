using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class DeadZoneController : MonoBehaviour
    {
        [SerializeField] StartLineController startController;

        private void OnTriggerEnter(Collider collider)
        {
            PlayerController playerController = collider.GetComponent<PlayerController>();

            if (playerController != null)
            {
                StartCoroutine(WaitAndProcess(playerController));
            }
        }

        private IEnumerator WaitAndProcess(PlayerController playerController)
        {
            playerController.GetComponent<CharacterController>().enabled = false;
            playerController.IsTouchDeadZone = true;
            playerController.transform.position = startController.GetStartPosition();
            playerController.SetPosition(startController.GetStartPosition());

            yield return new WaitForSeconds(0.5f);

            playerController.IsTouchDeadZone = false;
            playerController.GetComponent<CharacterController>().enabled = true;
        }
    }
}

