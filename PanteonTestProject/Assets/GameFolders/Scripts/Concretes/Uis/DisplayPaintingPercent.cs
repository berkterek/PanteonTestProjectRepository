using PanteonTestProject.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PanteonTestProject.Uis
{
    public class DisplayPaintingPercent : MonoBehaviour
    {
        RedImageManager _redImageManager;
        TextMeshProUGUI _currentCountText;

        private void Awake()
        {
            _redImageManager = FindObjectOfType<RedImageManager>();
            _currentCountText = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            _currentCountText.text = _redImageManager.PaintPercent + "%";
        }
    }
}

