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
        // Switch5
        root.Add(new Switch(new SwitchStyle() {
            IncludeDefaultStyle = true,
            Position = new Position(220, 0),
            Text = new TextLabelStyle() { Text = "3" }
        }));

        // Switch6
        root.Add(new Switch(new SwitchStyle() {
            IncludeDefaultStyle = true,
            Position = new Position(220, 100),
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "3" }
        }));

        root.Add(container);
    }

    public override string TestDescription => "This tests switch button with various style.";

    public override string RunningDescription => "* Numbering from the top-left corner, counter clockwise:\n"
                                               + " 1, 3: Unselected normal switch button.\n"
                                               + " 2, 4: Seleceted normal switch button.\n";

    public override string PassCondition => "1. Check the look of the switch buttons by their state.\n"
                                          + "2. When click 1, 2 -> Switch thumb moves to the right.\n"
                                          + "3. When click 3, 4 -> Switch thumb moves to the left.";
}
