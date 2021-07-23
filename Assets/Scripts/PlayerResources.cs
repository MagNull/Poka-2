using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Resources", menuName = "Player Resources", order = 0)]
public class PlayerResources : ScriptableObject
{
    public PlayerResourcesUI PlayerResourcesUI;

    [SerializeField] private int _goldAmount;
    [SerializeField] private int _foodAmount;
    [SerializeField] private int _maxFoodAmount;
    [SerializeField] private int _woodAmount;
    [SerializeField] private int _humansAmount;
    
    public int GoldAmount
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

    public int FoodAmount
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

    public int WoodAmount
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

    public int HumansAmount
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