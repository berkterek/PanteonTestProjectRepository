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
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                StartCoroutine(PushBack(playerController));
            }
        }

        private IEnumerator PushBack(PlayerController playerController)
        {
            playerController.GetComponent<CharacterController>().enabled = false;

            int i = 0;
            while (i < maxLoop)
            {
                playerController.transform.position += -playerController.transform.forward * pushForce * Time.deltaTime;
                i++;
                yield return new WaitForSeconds(waitTime);
            }
            
            playerController.GetComponent<CharacterController>().enabled = true;
            
        }
    }
}

