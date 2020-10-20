using PanteonTestProject.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] ImagePainting imagePainting;

        private void Start()
        {
            if (imagePainting.gameObject.activeSelf)
            {
                imagePainting.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            FindObjectOfType<FinishLineController>().OnRaceFinished += EnableImages;
        }

        //private void OnDisable()
        //{
        //    FindObjectOfType<FinishLineController>().OnRaceFinished -= EnableImages;
        //}

        private void EnableImages()
        {
            imagePainting.gameObject.SetActive(true);
        }
    }
}
