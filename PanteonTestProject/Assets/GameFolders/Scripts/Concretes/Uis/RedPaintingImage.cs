using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PanteonTestProject.Uis
{
    public class RedPaintingImage : MonoBehaviour
    {
        Image _image;

        public float FillAmount { get => _image.fillAmount; set => _image.fillAmount = value; }
        public bool IsFull => _image.fillAmount == 1f;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
    }
}
