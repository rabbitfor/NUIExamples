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
        var view0 = new CheckBox() { Text = "CheckBox1" };
        root.Add(view0);

        // CheckBox2
        var view1 = new CheckBox
        {
            Position = new Position(0, 100),
            IsSelected = true,
            Text = "CheckBox2"
        };
        root.Add(view1);

        // CheckBox3
        var view2 = new CheckBox
        {
            Position = new Position(0, 200),
            IsEnabled = false,
            Text = "CheckBox3"
        };
        root.Add(view2);

        // CheckBox4
        var view3 = new CheckBox
        {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
            Text = "CheckBox4"
        };
        root.Add(view3);

        
        //================================================================

        // CheckBox5
        root.Add(new CheckBox(new ButtonStyle()
        {
            IncludeDefaultStyle = true,
            Text = new TextLabelStyle() { Text = "CheckBox5" },
            PositionX = 300,
        }));

        // CheckBox6
        root.Add(new CheckBox(new ButtonStyle()
        {
            IncludeDefaultStyle = true,
            Position = new Position(300, 100),
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "CheckBox6" }
        }));

        // CheckBox7
        root.Add(new CheckBox(new ButtonStyle()
        {
            IncludeDefaultStyle = true,
            Position = new Position(300, 200),
            IsEnabled = false,
            Text = new TextLabelStyle() { Text = "CheckBox7" }
        }));


        // CheckBox8
        root.Add(new CheckBox(new ButtonStyle()
        {
            IncludeDefaultStyle = true,
            Position = new Position(300, 300),
            IsEnabled = false,
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "CheckBox8" }
        }));
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
