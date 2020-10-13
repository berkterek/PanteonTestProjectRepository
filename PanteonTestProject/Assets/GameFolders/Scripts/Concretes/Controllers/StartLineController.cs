using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class StartLineController : MonoBehaviour
    {
        [SerializeField] Vector3 minPosition;
        [SerializeField] Vector3 maxPosition;

        public Vector3 GetStartPosition()
        {
            float xRandom = Random.Range(minPosition.x, maxPosition.x);
            float yRandom = Random.Range(minPosition.y, maxPosition.y);
            float zRandom = Random.Range(minPosition.z, maxPosition.z);

            return new Vector3(xRandom, yRandom, zRandom);
        }
    }
}

