using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Resources", menuName = "Player Resources", order = 0)]
public class PlayerResources : ScriptableObject
{
    public PlayerResourcesUI PlayerResourcesUI;

    [SerializeField] private float _goldAmount;
    [SerializeField] private float _foodAmount;
    [SerializeField] private int _maxFoodAmount;
    [SerializeField] private float _woodAmount;
    [SerializeField] private float _humansAmount;
    
    public float GoldAmount
    {
        get => _goldAmount;
        set
        {
            if (value < 0) Debug.LogError("Try set negative value");
            else
            {
                _goldAmount = value;
                PlayerResourcesUI.ChangeValue(ResourcesType.GOLD, _goldAmount);
            }
        }
    }

    public float FoodAmount
    {
        get => _foodAmount;
        set
        {
            if (value < 0) Debug.LogError("Try set negative value");
            else
            {
                _foodAmount = value;
                PlayerResourcesUI.ChangeValue(ResourcesType.FOOD, _foodAmount, _maxFoodAmount);
            }
        }
    }

    public float WoodAmount
    {
        get => _woodAmount;
        set
        {
            if (value < 0) Debug.LogError("Try set negative value");
            else
            {
                _woodAmount = value;
                PlayerResourcesUI.ChangeValue(ResourcesType.WOOD, _woodAmount);
            }
        }
    }

    public float HumansAmount
    {
        get => _humansAmount;
        set
        {
            if (value < 0) Debug.LogError("Try set negative value");
            else
            {
                _humansAmount = value;
                PlayerResourcesUI.ChangeValue(ResourcesType.HUMANS, HumansAmount);
            }
        }
    }

    public int MAXFoodAmount
    {
        get => _maxFoodAmount;
        set
        {
            if (value < 0) Debug.LogError("Try set negative value");
            else
            {
                _maxFoodAmount = value;
                PlayerResourcesUI.ChangeValue(ResourcesType.FOOD, _foodAmount, _maxFoodAmount);
            }
        }
    }
}