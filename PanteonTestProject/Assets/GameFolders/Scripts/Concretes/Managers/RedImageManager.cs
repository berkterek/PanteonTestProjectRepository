using PanteonTestProject.Uis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace PanteonTestProject.Managers
{
    public class RedImageManager : MonoBehaviour
    {
        [SerializeField] bool _isFull;
        
        RedPaintingImage[] _imagePaintings;

        public bool IsFull => _isFull;

        private void Awake()
        {
            _imagePaintings = GetComponentsInChildren<RedPaintingImage>();
        }

        private void Update()
        {
            if (_isFull) return;

            _isFull = _imagePaintings.All(x => x.IsFull);

            if (_isFull)
            {
                GameManager.Instance.StartGame();
            }
        }
    }
}

