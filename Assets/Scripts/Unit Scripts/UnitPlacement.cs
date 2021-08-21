using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unit_Scripts
{
    public class UnitPlacement : MonoBehaviour
    {
        [SerializeField] private Collider _placementCollider;
        [SerializeField] private bool _canPlace;
        [SerializeField] private Renderer[] _meshRenderers;
        [SerializeField] private Material _canPlaceMaterial;
        [SerializeField] private Material _cantPlaceMaterial;
        [FormerlySerializedAs("_defaultMaterials")] [SerializeField] private Material _defaultMaterial;

        private void OnTriggerStay(Collider other) => _canPlace = false;

        private void OnTriggerExit(Collider other) => _canPlace = true;

        public bool Place()
        {
            if (_canPlace)
            {
                _placementCollider.enabled = false;
                Destroy(this);
                
                foreach (var meshRenderer in _meshRenderers)
                {
                    meshRenderer.material = _defaultMaterial;
                }
                
                Destroy(GetComponent<Rigidbody>());
            }

            return _canPlace;
        }

        private void Update()
        {
            ChangeColor();
        }

        private void ChangeColor()
        {
            Material currentMaterial = _canPlace ? _canPlaceMaterial : _cantPlaceMaterial;
            foreach (var meshRenderer in _meshRenderers)
            {
                meshRenderer.material = currentMaterial;
            }
        }
    }
}