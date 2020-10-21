using PanteonTestProject.Managers;
using TMPro;
using UnityEngine;

namespace PanteonTestProject.Uis
{
    public class DisplayRaceCount : MonoBehaviour
    {
        CharacterManager _characterManager;
        TextMeshProUGUI _currentCountText;

        private void Awake()
        {
            _characterManager = FindObjectOfType<CharacterManager>();
            _currentCountText = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            _currentCountText.text = _characterManager.RacePlace.ToString();
        }
    }
}

