using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Switch0 : TestUnit
{
    public override void OnCreate(View root)
    {
        root.BackgroundColor = Color.White;

        var container = new View ()
        {
            WidthResizePolicy = ResizePolicyType.FitToChildren,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
        };
        
        // Switch1
        var view0 = new Switch()
        {
            Text = "1",
            PointSize = 18,
        };
        container.Add(view0);

        // Switch2
        var view1 = new Switch
        {
            Position = new Position(0, 100),
            IsSelected = true,
            PointSize = 18,
            Text = "2"
        };
        container.Add(view1);

        //================================================================
        var style = ThemeManager.GetStyle(typeof(Switch)) as SwitchStyle;
        style.PositionX = 220;
        style.Text.PointSize = 18;

        // Switch5
        container.Add(new Switch(new SwitchStyle() {
            Text = new TextLabelStyle() { Text = "3" }
        }.Merge(style)));

        // Switch6
        container.Add(new Switch(new SwitchStyle() {
            Position = new Position(0, 100),
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "4" }
        }.Merge(style)));

        root.Add(container);
    }

    public override string TestDescription => "This tests switch button with various style.";

    public override string RunningDescription => "* Numbering from the top-left corner, counter clockwise:\n"
                                               + " 1, 3: Unselected normal switch button.\n"
                                               + " 2, 4: Seleceted normal switch button.\n";

    public override string PassCondition => "1. Check the look of the switch buttons by their state.\n"
                                          + "2. When click 1, 2, 3, 4 -> Normal: white-grey, Selected: blue-white.\n";
}
