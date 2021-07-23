using System;
using DG.Tweening;
using UnityEngine;

namespace Buildings
{
    public class DragOnClick : MonoBehaviour
    {
        [SerializeField] private float _sizeChangeOnClickValue;
        [SerializeField] private float _sizeChangeOnClickTime;

        public void Shrink()
        {
            if(transform.transform.localScale == Vector3.one) transform.DOPunchScale(Vector3.one * _sizeChangeOnClickValue, _sizeChangeOnClickTime);
        }
    }
}