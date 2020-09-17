using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class RadioButton0: TestUnit
{
    public override void OnCreate(View root)
    {
        var view0 = new RadioButton();
        root.Add(view0);

        var view1 = new RadioButton
        {
            Position = new Position(0, 100),
            IsSelected = true,
        };
        root.Add(view1);

        var view2 = new RadioButton
        {
            Position = new Position(0, 200),
            IsEnabled = false,
        };
        root.Add(view2);

        var view3 = new RadioButton
        {
            Position = new Position(0, 300),
            IsEnabled = false,
            IsSelected = true,
        };
        root.Add(view3);

        var group0 = new RadioButtonGroup();
        group0.Add(view0);
        group0.Add(view1);
        group0.Add(view2);
        group0.Add(view3);

        var view4 = new RadioButton(new ButtonStyle(view0.Style)
        {
            PositionX = 400,
        });
        root.Add(view4);

        var view5 = new RadioButton(new ButtonStyle(view1.Style)
        {
            PositionX = 400,
        });
        root.Add(view5);

        var view6 = new RadioButton(new ButtonStyle(view2.Style)
        {
            PositionX = 400,
        });
        root.Add(view6);

        var view7 = new RadioButton(new ButtonStyle(view3.Style)
        {
            PositionX = 400,
        });
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