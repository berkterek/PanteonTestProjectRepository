using PanteonTestProject.Uis;
using System.Linq;
using UnityEngine;

namespace PanteonTestProject.Managers
{
    public class RedImageManager : MonoBehaviour
    {
        [SerializeField] bool _isFull;
        
        RedPaintingImage[] _imagePaintings;

        public float PaintPercent => (_currentCount / _paintCount) * 100;

        float _paintCount;
        float _currentCount;

        private void Awake()
        {
            _imagePaintings = GetComponentsInChildren<RedPaintingImage>();
            _paintCount = _imagePaintings.Length;
        }

        private void Update()
        {
            Debug.Log(PaintPercent);
            
            if (_isFull) return;

            _isFull = _imagePaintings.All(x => x.IsFull);
            _currentCount = _imagePaintings.Count(x => x.IsFull);

            if (_isFull)
            {
                GameManager.Instance.StartGame();
            }
        }
    }
}

