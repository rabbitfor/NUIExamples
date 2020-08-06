using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Switch0 : TestUnit
{
    public override void OnCreate(View root)
    {
        root.BackgroundColor = Color.Black;
        
        var view0 = new Switch();
        root.Add(view0);

        var view1 = new Switch
        {
            Position = new Position(0, 100),
            IsSelected = true,
        };
        root.Add(view1);

        var view2 = new Switch
        {
            Position = new Position(0, 200),
            IsEnabled = false,
        };
        root.Add(view2);

        var view3 = new Switch
        {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
        };
        root.Add(view3);

        var view4 = new Switch(new SwitchStyle(view0.Style)
        {
            PositionX = 400,
        });
        root.Add(view4);

        var view5 = new Switch(new SwitchStyle(view1.Style)
        {
            PositionX = 400,
        });
        root.Add(view5);

        var view6 = new Switch(new SwitchStyle(view2.Style)
        {
            PositionX = 400,
        });
        root.Add(view6);

        var view7 = new Switch(new SwitchStyle(view3.Style)
        {
            PositionX = 400,
        });
        root.Add(view7);
    }

    public override string RunningDescription => "* Numbering from the top-left corner, counter clockwise:\n"
                                               + " (1),(5) Unselected normal switch button.\n"
                                               + " (2),(6) Seleceted normal switch button.\n"
                                               + " (3),(7) Unseleced disabled switch button.\n"
                                               + " (2),(6) Selected disabled switch button.\n";

    public override string PassCondition => "* Check the look of the switch buttons by their state.\n"
                                          + "* When click (1),(2),(5),(6) -> Normal: white-grey, Selected: blue-white.\n"
                                          + "* When click (3),(4),(7),(8) -> no change\n";
}
