using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

// Test reuse of button style
public class ScrollableBase0 : TestUnit
{
    ScrollableBase scrollable;
    List<ImageView> items = new List<ImageView>();

    void OnAddButtonClicked(object sender, EventArgs args)
    {
        var image = new ImageView() { Size = new Size(360, 360), ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/image.jpg" };
        items.Add(image);
        scrollable.Add(image);
    }

    void OnRemoveButtonClicked(object sender, EventArgs args)
    {
        if (items.Count == 0) { return; }

        scrollable.Remove(items[items.Count - 1]);
        items.RemoveAt(items.Count - 1);
    }

    public override void OnCreate(View root)
    {       
        var addButton = new Button() { Text = "Add", Size = new Size(100, 50), PointSize = 10 };
        addButton.Clicked += OnAddButtonClicked;
        root.Add(addButton);

        var removeButton = new Button() { Text = "Remove", Size = new Size(100, 50), PointSize = 10, ParentOrigin = ParentOrigin.TopRight, PivotPoint = PivotPoint.TopRight, PositionUsesPivotPoint = true };
        removeButton.Clicked += OnRemoveButtonClicked;
        root.Add(removeButton);

        scrollable = new ScrollableBase() {
            Size = new Size(360, 360),
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
            PositionUsesPivotPoint = true,
            Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical },
            HideScrollbar = false,
            Scrollbar = new Scrollbar()
            {
                // TrackColor = Color.Blue,
                // ThumbColor = new Color(1.0f, 0.0f, 0.0f, 0.5f),
                TrackPadding = new Extents(24, 24, 40, 40)
            }
        };
        root.Add(scrollable);

        OnAddButtonClicked(null, null);
    }

    public override string RunningDescription => "";

    public override string PassCondition => "";
}
