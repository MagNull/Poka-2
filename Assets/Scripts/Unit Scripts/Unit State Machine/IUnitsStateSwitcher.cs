namespace Unit_Scripts.Unit_State_Machine
{
    public interface IUnitsStateSwitcher
    {
        void SwitchState<T>() where T : UnitsState;
    }
}