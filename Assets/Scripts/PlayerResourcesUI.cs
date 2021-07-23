using TMPro;
using UnityEngine;

public class PlayerResourcesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _woodText;
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _foodText;
    [SerializeField] private TextMeshProUGUI _humanText;

    public void ChangeValue(ResourcesType resourcesType, int value, int max = 0)
    {
        switch (resourcesType)
        {
            case ResourcesType.WOOD:
                _woodText.text = value.ToString();
                break;
            case ResourcesType.GOLD:
                _goldText.text = value.ToString();
                break;
            case ResourcesType.HUMANS:
                _humanText.text = value.ToString();
                break;
            case ResourcesType.FOOD:
                _foodText.text = value + "/" + max;
                break;
        }
    }
}