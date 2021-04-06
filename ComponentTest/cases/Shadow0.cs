using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Shadow0 : TestUnit
{
    public override void OnCreate(View root)
    {
        var view = new View
        {
            Size = new Size(200, 200),
            PositionUsesPivotPoint = true,
            PivotPoint = PivotPoint.Center,
            ParentOrigin = ParentOrigin.Center,
            BackgroundColor = Color.Red,
            ImageShadow = new ImageShadow(null, new Rectangle(24, 24, 24, 24), extents: new Vector2(48, 48)),
            BoxShadow = new Shadow(50, null, null, new Vector2(50, 50))
        };
        root.Add(view);
    }

    public override string RunningDescription => "";

    public override string PassCondition => "Blurred shadow is wrap around four sides of the red square.";
}
