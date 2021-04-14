using Tizen.NUI;
using Tizen.NUI.BaseComponents;

public abstract class TestUnit
{
    public abstract void OnCreate(View root);
    public virtual void OnDestroy(View root) {}

    public abstract string RunningDescription { get; }
    public abstract string PassCondition { get; }
    public abstract string TestDescription { get; }
}