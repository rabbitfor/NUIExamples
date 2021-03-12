using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

// Test reuse of button style
public class Pagination0 : TestUnit
{
    Pagination pagination;

    public override void OnCreate(View root)
    {       
        var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        root.BackgroundColor = new Color("#ebba34");

        var addButton = new Button() { Text = "Add", PointSize = 10, Size = new Size(100, 50), ParentOrigin = ParentOrigin.TopLeft, PivotPoint = PivotPoint.TopLeft };
        var removeButton = new Button() { Text = "Remove", PointSize = 10, Size = new Size(100, 50), ParentOrigin = ParentOrigin.TopRight, PivotPoint = PivotPoint.TopRight, PositionUsesPivotPoint = true };
        var prevButton = new Button() { Text = "<<", PointSize = 10, Size = new Size(100, 50), ParentOrigin = ParentOrigin.BottomLeft, PivotPoint = PivotPoint.BottomLeft, PositionUsesPivotPoint = true };
        var nextButton = new Button() { Text = ">>", PointSize = 10, Size = new Size(100, 50), ParentOrigin = ParentOrigin.BottomRight, PivotPoint = PivotPoint.BottomRight, PositionUsesPivotPoint = true };

        addButton.Clicked += OnAddClicked;
        removeButton.Clicked += OnRemoveClicked;
        prevButton.Clicked += OnPrevClicked;
        nextButton.Clicked += OnNextClicked;

        pagination = new Pagination() {
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
            IndicatorCount = 3,
            SelectedIndex = 5,
        };

        root.Add(addButton);
        root.Add(removeButton);
        root.Add(prevButton);
        root.Add(nextButton);
        root.Add(pagination);
    }

    void OnAddClicked(object sender, EventArgs args)
    {
        pagination.IndicatorCount++;
    }

    void OnRemoveClicked(object sender, EventArgs args)
    {
        pagination.IndicatorCount--;
    }

    void OnPrevClicked(object sender, EventArgs args)
    {
        pagination.SelectedIndex--;
    }

    void OnNextClicked(object sender, EventArgs args)
    {
        pagination.SelectedIndex++;
    }

    public override string RunningDescription => "";

    public override string PassCondition => "";
}
