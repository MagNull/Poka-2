using System;
using Buildings;
using DG.Tweening;
using Interfaces;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Transform _originPosition;
    [SerializeField] private float _zoomTime;
    [SerializeField] private GameObject _unzoomButton;
    private IZoomable _target;
    private Camera _camera;

    public void Zoom(IZoomable zoomable)
    {
        if (!(_target is null))
        {
            _target.Unzoom();
        }
        _target = zoomable;
        _target.Zoom();
        transform.DOMove(_target.ZoomPosition.position, _zoomTime);
        transform.DORotate(_target.ZoomPosition.rotation.eulerAngles, _zoomTime);
        _unzoomButton.SetActive(true);
    }

    public void Unzoom()
    {
        if (!(_target is null))
        {
            _target.Unzoom();
            _target = null;
            transform.DOMove(_originPosition.position, _zoomTime);
            transform.DORotate(_originPosition.rotation.eulerAngles, _zoomTime);
            _unzoomButton.SetActive(false);
        }
    }

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        TryToZoom();
    }

    private void TryToZoom()
    {
        if (Input.GetMouseButtonDown(0) && (_target is null))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.gameObject.TryGetComponent(out IZoomable zoomable))
                {
                    Zoom(zoomable);
                }
            }
        }
    }
}