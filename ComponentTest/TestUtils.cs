using Tizen.NUI;
using Tizen.NUI.BaseComponents;

public class TestUtils
{
    static public View CreateEmptyView()
    {
        return new View
        {
            Size = new Size(600, 500),
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.TopLeft,
            PivotPoint = PivotPoint.TopLeft,
        };
    }
}