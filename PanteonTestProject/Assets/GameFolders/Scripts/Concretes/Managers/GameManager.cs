using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            SingletonThisObject();
        }

        private void SingletonThisObject()
        {
            if (Instance == null)
            {
                Instance = GetComponent<GameManager>();
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}

