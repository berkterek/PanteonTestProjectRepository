using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PanteonTestProject.Uis
{
    public class ImagePainting : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IDragHandler,IPointerExitHandler
    {
        [SerializeField] Image paintingImage;
        [SerializeField] float currentPaintAmount = 0.2f;

        public void OnDrag(PointerEventData eventData)
        {
            if (paintingImage != null)
            {
                if (paintingImage.fillAmount != 1f)
                {
                    paintingImage.fillAmount += currentPaintAmount;
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            paintingImage = eventData.pointerCurrentRaycast.gameObject?.GetComponent<Image>();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (paintingImage != null)
            {
                paintingImage = null;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (paintingImage != null)
            {
                paintingImage = null;
            }
        }
    }
}

