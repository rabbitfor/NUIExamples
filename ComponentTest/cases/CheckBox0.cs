using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class CheckBox0: TestUnit
{
    public override void OnCreate(View root)
    {
        root.BackgroundColor = Color.White;
        
        // CheckBox1
        var view0 = new CheckBox();
        root.Add(view0);

        // CheckBox2
        var view1 = new CheckBox
        {
            Position = new Position(0, 100),
            IsSelected = true,
        };
        root.Add(view1);

        // CheckBox3
        var view2 = new CheckBox
        {
            Position = new Position(0, 200),
            IsEnabled = false,
        };
        root.Add(view2);

        // CheckBox4
        var view3 = new CheckBox
        {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
        };
        root.Add(view3);

        
        //================================================================
        var style = ThemeManager.GetStyle(typeof(CheckBox)) as ButtonStyle;
        style.PositionX = 400;

        // CheckBox5
        root.Add(new CheckBox(style));

        // CheckBox6
        root.Add(new CheckBox(new ButtonStyle()
        {
            Position = new Position(0, 100),
            IsSelected = true,
        }.Merge<ButtonStyle>(style)));

        // CheckBox7
        root.Add(new CheckBox(new ButtonStyle()
        {
            Position = new Position(0, 200),
            IsEnabled = false,
        }.Merge(style)));


        // CheckBox8
        root.Add(new CheckBox(new ButtonStyle()
        {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
        }.Merge(style)));
    }

    public override string RunningDescription => "Numbering from the top-left corner, counter clockwise:\n"
                                          + "(1),(5) Unselected normal checkbox.\n"
                                          + "(2),(6) Seleceted normal checkbox.\n"
                                          + "(3),(7) Unseleced disabled checkbox.\n"
                                          + "(2),(6) Selected disabled checkbox.\n";

    public override string PassCondition => "* Check the look of the checkboxes by their state.\n"
                                          + "* When click (1),(2),(5),(6) -> Normal: white, Pressed: blue, Selected: blue-checked\n"
                                          + "* When click (3),(4),(7),(8) -> no change\n";
}
