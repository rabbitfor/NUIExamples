using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Wearable;


// Test reuse of button style
public class CircularSlider0 : TestUnit
{
    CircularSlider slider;
    TextLabel label;
    TextLabel minusLabel;
    TextLabel plusLabel;
    ImageView iconImage;

    public override void OnCreate(View root)
    {       
        root.BackgroundColor = Color.Black;

        slider = new CircularSlider()
        {
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
        };
        slider.CurrentValue = 0;

        // These properties have default values, so they're set to the following values
        // even if you don't set them separately.
        slider.MinValue = 0;
        slider.MaxValue = 10;
        slider.Thickness = 6;

        root.Add(slider);

        CreateLabelAndIcon(root);
    }

    void CreateLabelAndIcon(View root)
    {
        label = new TextLabel()
        {
            Text = slider.CurrentValue.ToString(),
            TextColor = Color.White,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            PositionUsesPivotPoint = true,
            ParentOrigin = Tizen.NUI.ParentOrigin.Center,
            PivotPoint = Tizen.NUI.PivotPoint.Center,
        };
        root.Add(label);

        iconImage = new ImageView()
        {
            Position = new Position(0, -70),
            PositionUsesPivotPoint = true,
            ParentOrigin = Tizen.NUI.ParentOrigin.Center,
            PivotPoint = Tizen.NUI.PivotPoint.Center,
            ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "CircularSlider0/sound_icon.png"
        };
        root.Add(iconImage);

        TextLabel fixedLabel = new TextLabel()
        {
            Text = "SOUND",
            TextColor = Color.White,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            Position = new Position(0, 70),
            PositionUsesPivotPoint = true,
            ParentOrigin = Tizen.NUI.ParentOrigin.Center,
            PivotPoint = Tizen.NUI.PivotPoint.Center,
        };
        root.Add(fixedLabel);

        minusLabel = new TextLabel()
        {
            Text = "-",
            TextColor = Color.White,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            WidthResizePolicy = ResizePolicyType.UseNaturalSize,
            HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            Position = new Position(-50, 0),
            PositionUsesPivotPoint = true,
            ParentOrigin = Tizen.NUI.ParentOrigin.Center,
            PivotPoint = Tizen.NUI.PivotPoint.Center,
        };
        minusLabel.TouchEvent += OnMinusTouch;
        root.Add(minusLabel);

        plusLabel = new TextLabel()
        {
            Text = "+",
            TextColor = Color.White,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            WidthResizePolicy = ResizePolicyType.UseNaturalSize,
            HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            Position = new Position(50, 0),
            PositionUsesPivotPoint = true,
            ParentOrigin = Tizen.NUI.ParentOrigin.Center,
            PivotPoint = Tizen.NUI.PivotPoint.Center,
        };
        plusLabel.TouchEvent += OnPlusTouch;
        root.Add(plusLabel);
    }

    private bool OnMinusTouch(object source, View.TouchEventArgs e)
    {
        if (e.Touch.GetState(0) == PointStateType.Down)
        {
            if (slider.CurrentValue > 0)
            {
                slider.CurrentValue -= 1;
                label.Text = slider.CurrentValue.ToString();
            }
        }
        return false;
    }

    private bool OnPlusTouch(object source, View.TouchEventArgs e)
    {
        if (e.Touch.GetState(0) == PointStateType.Down)
        {
            if (slider.CurrentValue < slider.MaxValue)
            {
                slider.CurrentValue += 1;
                label.Text = slider.CurrentValue.ToString();
            }
        }
        return false;
    }

    public override string RunningDescription => "";

    public override string PassCondition => "Click the '+' or '-' buttons in the center.\n"
                                          + "The blue line goes forward along the outline of the circle in clockwise when click '+'.\n"
                                          + "It goes backward along the outline of the circle in counter-clockwise when click '-'.";
}
