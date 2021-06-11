using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Switch0 : TestUnit
{
    public override void OnCreate(View root)
    {
        root.BackgroundColor = Color.White;
        
        // Switch1
        var view0 = new Switch() { Text = "Switch1" };
        root.Add(view0);

        // Switch2
        var view1 = new Switch
        {
            Position = new Position(0, 100),
            IsSelected = true,
            Text = "Switch2"
        };
        root.Add(view1);

        // Switch3
        var view2 = new Switch
        {
            Position = new Position(0, 200),
            IsEnabled = false,
            Text = "Switch3"
        };
        root.Add(view2);

        // Switch4
        var view3 = new Switch
        {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
            Text = "Switch4"
        };
        root.Add(view3);

        //================================================================
        // Switch5
        root.Add(new Switch(new SwitchStyle() {
            IncludeDefaultStyle = true,
            Position = new Position(300, 0),
            Text = new TextLabelStyle() { Text = "Switch5" }
        }));

        // Switch6
        root.Add(new Switch(new SwitchStyle() {
            IncludeDefaultStyle = true,
            Position = new Position(300, 100),
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "Switch6" }
        }));

        // Switch7
        root.Add(new Switch(new SwitchStyle() {
            IncludeDefaultStyle = true,
            Position = new Position(300, 200),
            IsEnabled = false,
            Text = new TextLabelStyle() { Text = "Switch7" }
        }));

        // Switch8
        root.Add(new Switch(new SwitchStyle() {
            IncludeDefaultStyle = true,
            Position = new Position(300, 300),
            IsEnabled = false,
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "Switch8" }
        }));
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
