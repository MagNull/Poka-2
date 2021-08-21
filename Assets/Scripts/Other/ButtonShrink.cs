using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonShrink : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _shrinkTime = .5f;
    [SerializeField] private float _shrinkSize = 1;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * _shrinkSize, _shrinkTime);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, _shrinkTime);
    }
}
