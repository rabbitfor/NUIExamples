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
        var style = ThemeManager.GetStyle(typeof(Switch)) as SwitchStyle;
        style.PositionX = 400;

        // Switch5
        root.Add(new Switch(new SwitchStyle() {
            Text = new TextLabelStyle() { Text = "Switch5" }
        }.Merge(style)));

        // Switch6
        root.Add(new Switch(new SwitchStyle() {
            Position = new Position(0, 100),
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "Switch6" }
        }.Merge(style)));

        // Switch7
        root.Add(new Switch(new SwitchStyle() {
            Position = new Position(0, 200),
            IsEnabled = false,
            Text = new TextLabelStyle() { Text = "Switch7" }
        }.Merge(style)));

        // Switch8
        root.Add(new Switch(new SwitchStyle() {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "Switch8" }
        }.Merge(style)));
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
