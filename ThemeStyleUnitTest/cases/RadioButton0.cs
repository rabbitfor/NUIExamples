using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class RadioButton0: TestUnit
{
    public override void OnCreate(View root)
    {
        var container = new View ()
        {
            WidthResizePolicy = ResizePolicyType.FitToChildren,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
        };

        // RadioButton1
        var view0 = new RadioButton()
        {
            Text = "1",
            PointSize = 18,
        };
        container.Add(view0);

        // RadioButton2
        var view1 = new RadioButton
        {
            Position = new Position(0, 100),
            IsSelected = true,
            PointSize = 18,
            Text = "2"
        };
        container.Add(view1);

        // RadioButton3
        var view2 = new RadioButton
        {
            Position = new Position(0, 200),
            IsEnabled = false,
            PointSize = 18,
            Text = "3"
        };
        container.Add(view2);

        // RadioButton4
        var view3 = new RadioButton
        {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
            PointSize = 18,
            Text = "4"
        };
        container.Add(view3);

        var group0 = new RadioButtonGroup();
        group0.Add(view0);
        group0.Add(view1);
        group0.Add(view2);
        group0.Add(view3);

        //================================================================
        var style = ThemeManager.GetStyle(typeof(RadioButton)) as ButtonStyle;
        style.PositionX = 220;
        style.Text.PointSize = 18;

        // RadioButton5
        var view4 = new RadioButton(new ButtonStyle() {
            Text = new TextLabelStyle() { Text = "5" }
        }.Merge(style));
        container.Add(view4);

        // RadioButton6
        var view5 = new RadioButton(new ButtonStyle() {
            Position = new Position(0, 100),
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "6" }
        }.Merge(style));
        container.Add(view5);

        // RadioButton7
        var view6 = new RadioButton(new ButtonStyle() {
            Position = new Position(0, 200),
            IsEnabled = false,
            Text = new TextLabelStyle() { Text = "7" }
        }.Merge(style));
        container.Add(view6);

        // RadioButton8
        var view7 = new RadioButton(new ButtonStyle() {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
            Text = new TextLabelStyle() { Text = "8" }
        }.Merge(style));
        container.Add(view7);

        var group1 = new RadioButtonGroup();
        group1.Add(view4);
        group1.Add(view5);
        group1.Add(view6);
        group1.Add(view7);

        root.Add(container);
    }

    public override string TestDescription => "This tests radio button with various style.";

    public override string RunningDescription => "* Numbering from the top-left corner, counter clockwise:\n"
                                               + " 1, 5: Unselected normal radio button.\n"
                                               + " 2, 6: Seleceted normal radio button.\n"
                                               + " 3, 7: Unseleced disabled radio button.\n"
                                               + " 4, 8: Selected disabled radio button.";

    public override string PassCondition => "1. Check the look of the radio buttons by their state.\n"
                                          + "2. When click 1, 5: Change to filled circle.\n"
                                          + "3. When click 2, 6: Change to empty circle.\n"
                                          + "4. When click 3, 4, 7, 8 -> No change.\n"
                                          + "5. Check 1, 2, 3, 4 are grouped well.\n"
                                          + "6. Check 5, 6, 7, 8 are grouped well.";
}
