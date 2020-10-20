using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void StartGame()
        {
            StartCoroutine(StartGameAsync());
        }

        private IEnumerator StartGameAsync()
        {
            yield return new WaitForSeconds(2f);
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
        }
    }
}

