using System;
using UnityEngine;

namespace Interfaces
{
    public interface IZoomable
    {
        public Transform ZoomPosition { get; }
        
        public bool IsZoomed { get; }

        void Zoom();

        void Unzoom();
    }
}