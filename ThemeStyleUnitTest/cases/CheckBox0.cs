using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class CheckBox0: TestUnit
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
        
        // CheckBox1
        var view0 = new CheckBox()
        {
            Text = "1",
            PointSize = 18,
        };
        container.Add(view0);

        // CheckBox2
        var view1 = new CheckBox
        {
            Position = new Position(0, 100),
            IsSelected = true,
            Text = "2",
            PointSize = 18,
        };
        container.Add(view1);

        // CheckBox3
        var view2 = new CheckBox
        {
            Position = new Position(0, 200),
            IsEnabled = false,
            Text = "3",
            PointSize = 18,
        };
        container.Add(view2);

        // CheckBox4
        var view3 = new CheckBox
        {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
            Text = "4",
            PointSize = 18,
        };
        container.Add(view3);

        
        //================================================================
        var style = ThemeManager.GetStyle(typeof(CheckBox)) as ButtonStyle;
        style.PositionX = 220;
        style.Text.PointSize = 18;

        // CheckBox5
        container.Add(new CheckBox(new ButtonStyle()
        {
            Text = new TextLabelStyle() { Text = "5" }
        }.Merge<ButtonStyle>(style)));

        // CheckBox6
        container.Add(new CheckBox(new ButtonStyle()
        {
            Position = new Position(0, 100),
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "6" }
        }.Merge<ButtonStyle>(style)));

        // CheckBox7
        container.Add(new CheckBox(new ButtonStyle()
        {
            Position = new Position(0, 200),
            IsEnabled = false,
            Text = new TextLabelStyle() { Text = "7" }
        }.Merge(style)));


        // CheckBox8
        container.Add(new CheckBox(new ButtonStyle()
        {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "8" }
        }.Merge(style)));

        root.Add(container);
    }

    public override string TestDescription => "This tests checkbox with various style.";

    public override string RunningDescription => "1, 5: Unselected normal checkbox.\n"
                                          + "2, 6: Seleceted normal checkbox.\n"
                                          + "3, 7: Unseleced disabled checkbox.\n"
                                          + "4, 8: Selected disabled checkbox.\n";

    public override string PassCondition => "1. Check the look of the checkboxes by their state.\n"
                                          + "2. When click 1, 5 -> Check sign should apprear.\n"
                                          + "3. When click 2, 6 -> Check sign should disapprear.\n"
                                          + "3. When click 3, 4, 7, 8 -> No change\n";
}
