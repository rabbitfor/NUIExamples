using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Theme4 : TestUnit
{
    public override void OnCreate(View root)
    {
        Tizen.NUI.Components.StyleManager.Instance.Theme = "DarkTheme";

        root.Add(new Switch()
        {
        });
    }

    public override string RunningDescription => "There is a normal switch.";

    public override string PassCondition => "";
}
