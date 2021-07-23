using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Buildings
{
    public class GranaryInterfaceController : AbstractInterfaceController
    {
        [SerializeField] private Button _upgradeButton;
        private Granary _granary;
        [Inject] private PlayerResources _playerResources;
        
        private void Awake()
        {
            _granary = GetComponent<Granary>();
        }

        private void Update()
        {
            if (_granary.IsZoomed)
            {
                ChangeTextsValue();
            }
        }
        

        public override void OpenInterface()
        {
            base.OpenInterface();
            _upgradeButton.onClick.AddListener(_granary.Upgrade);
        }
        
        public override void CloseInterface()
        {
            base.CloseInterface();
            _upgradeButton.onClick.RemoveListener(_granary.Upgrade);
        }
        

        public override void ChangeTextsValue()
        {
            _neededLines[0].text = $"Maximum storage = {_playerResources.MAXFoodAmount}" ;
        }
    }
}