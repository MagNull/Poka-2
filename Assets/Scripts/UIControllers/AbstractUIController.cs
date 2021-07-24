using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UIControllers
{
    public abstract class AbstractUIController : MonoBehaviour
    {
        [SerializeField] protected Canvas _buildingInterfaceCanvas;
        [SerializeField] protected GameObject _resourceIcon;
        [SerializeField] protected TextMeshProUGUI[] _neededLines;

        
        public virtual void OpenInterface()
        {
            SetInterfaceActiveState(true);
            ChangeStateOfNeededLines(true);

            _buildingInterfaceCanvas.transform.localScale = Vector3.zero;
            _buildingInterfaceCanvas.transform.DOScale(Vector3.one, 1);
        }
        
        public virtual void CloseInterface()
        {
            SetInterfaceActiveState(false);
            ChangeStateOfNeededLines(false);
        }
        
        private void ChangeStateOfNeededLines(bool state)
        {
            foreach (var line in _neededLines)
            {
                line.gameObject.SetActive(state);
            }
        }

        private void SetInterfaceActiveState(bool state)
        {
            _buildingInterfaceCanvas.gameObject.SetActive(state);
            _resourceIcon.SetActive(state);
        }

        public abstract void ChangeTextsValue();
    }
}