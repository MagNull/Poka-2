namespace UnitsLogic
{
    public interface IUnitsStateSwitcher
    {
        void SwitchState<T>() where T : UnitState;
    }
}