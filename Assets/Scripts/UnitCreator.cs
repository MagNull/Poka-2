using UnityEngine;

public abstract class UnitCreator
{
    [SerializeField] private Unit _unitPrefab;

    protected abstract Unit CreateUnit();
}