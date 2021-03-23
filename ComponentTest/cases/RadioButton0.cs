using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class RadioButton0: TestUnit
{
    public override void OnCreate(View root)
    {
        // RadioButton1
        var view0 = new RadioButton() { Text = "RadioButton1" };
        root.Add(view0);

        // RadioButton2
        var view1 = new RadioButton
        {
            Position = new Position(0, 100),
            IsSelected = true,
            Text = "RadioButton2"
        };
        root.Add(view1);

        // RadioButton3
        var view2 = new RadioButton
        {
            Position = new Position(0, 200),
            IsEnabled = false,
            Text = "RadioButton3"
        };
        root.Add(view2);

        // RadioButton4
        var view3 = new RadioButton
        {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
            Text = "RadioButton4"
        };
        root.Add(view3);

        var group0 = new RadioButtonGroup();
        group0.Add(view0);
        group0.Add(view1);
        group0.Add(view2);
        group0.Add(view3);

        //================================================================
        var style = ThemeManager.GetStyle(typeof(RadioButton)) as ButtonStyle;
        style.PositionX = 400;

        // RadioButton5
        var view4 = new RadioButton(new ButtonStyle() {
            Text = new TextLabelStyle() { Text = "RadioButton5" }
        }.Merge(style));
        root.Add(view4);

        // RadioButton6
        var view5 = new RadioButton(new ButtonStyle() {
            Position = new Position(0, 100),
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "RadioButton6" }
        }.Merge(style));
        root.Add(view5);

        // RadioButton7
        var view6 = new RadioButton(new ButtonStyle() {
            Position = new Position(0, 200),
            IsEnabled = false,
            Text = new TextLabelStyle() { Text = "RadioButton7" }
        }.Merge(style));
        root.Add(view6);

        // RadioButton8
        var view7 = new RadioButton(new ButtonStyle() {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "RadioButton8" }
        }.Merge(style));
        root.Add(view7);

        var group1 = new RadioButtonGroup();
        group1.Add(view4);
        group1.Add(view5);
        group1.Add(view6);
        group1.Add(view7);
    }

    public override string RunningDescription => "* Numbering from the top-left corner, counter clockwise:\n"
                                               + " (1),(5) Unselected normal radio button.\n"
                                               + " (2),(6) Seleceted normal radio button.\n"
                                               + " (3),(7) Unseleced disabled radio button.\n"
                                               + " (2),(6) Selected disabled radio button.\n";

    public override string PassCondition => "* Check the look of the radio buttons by their state.\n"
                                          + "* Check (1),(2),(3),(4) are grouped well.\n"
                                          + "* Check (5),(6),(7),(8) are grouped well.\n"
                                          + "* When click (1),(2),(5),(6) -> Normal: white, Pressed: blue, Selected: blue-in-white-ring\n"
                                          + "* When click (3),(4),(7),(8) -> no change\n";
}
