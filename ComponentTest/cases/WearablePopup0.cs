using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Wearable;

public class WearablePopup0 : TestUnit
{
    private Tizen.NUI.Wearable.Popup popup;
    private TextLabel content;

    public override void OnCreate(View root)
    {
        var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        ButtonStyle buttonStyle = new ButtonStyle()
        {
            BackgroundImage = resourcePath + "WearablePopup0/tw_ic_popup_btn_bg.png",
            Size = new Size(73, 121),
            Color = new Color(11.0f / 255.0f, 6.0f / 255.0f, 92.0f / 255.0f, 1),
            Icon = new ImageViewStyle()
            {
                Size = new Size(50, 50),
                Color = Color.Cyan,
            },
        };

        buttonStyle.Icon.ResourceUrl = resourcePath + "WearablePopup0/tw_ic_popup_btn_check.png";
        Button leftButton = new Button(buttonStyle);
        leftButton.ClickEvent += LeftButton_ClickEvent;

        buttonStyle.Icon.ResourceUrl = resourcePath + "WearablePopup0/tw_ic_popup_btn_delete.png";
        Button rightButton = new Button(buttonStyle);
        rightButton.ClickEvent += RightButton_ClickEvent;


        popup = new Tizen.NUI.Wearable.Popup();
        popup.AppendButton("LeftButton", leftButton);
        popup.AppendButton("RightButton", rightButton);

        TextLabel t = popup.GetTitle();
        t.Text = "Title Area";

        content = new TextLabel();
        content.Text = "Click? \n GPS location \n and use of your \n location data \n are controlled \n by the applications you \n \n \n this is additional text!";
        content.MultiLine = true;
        content.Size = new Size(200, 800);
        content.PointSize = 6;
        content.HorizontalAlignment = HorizontalAlignment.Center;
        content.VerticalAlignment = VerticalAlignment.Top;
        content.TextColor = Color.White;
        content.PositionUsesPivotPoint = true;
        content.ParentOrigin = ParentOrigin.Center;
        content.PivotPoint = PivotPoint.Center;
        popup.AppendContent("ContentText", content);
        
        popup.OutsideClicked += Mp_OutsideClicked;

        popup.ContentContainer.WidthResizePolicy = ResizePolicyType.FitToChildren;
        popup.ContentContainer.HeightResizePolicy = ResizePolicyType.FitToChildren;

        popup.Post(NUIApplication.GetDefaultWindow());
        popup.AfterDissmising += popup_AfterDissmising;
    }

    public override void OnDestroy(View root)
    {
        popup?.Dismiss();
    }

    private void RightButton_ClickEvent(object sender, Button.ClickEventArgs e)
    {
        popup.Dismiss();
    }

    private void LeftButton_ClickEvent(object sender, Button.ClickEventArgs e)
    {
        content.TextColor = Color.Yellow;
    }

    private void popup_AfterDissmising(object sender, EventArgs e)
    {
        var t1 = new TextLabel("please go back to main menu!")
        {
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
            PointSize = 8,
            MultiLine = true,
        };
        NUIApplication.GetDefaultWindow().Add(t1);
    }

    private void Mp_OutsideClicked(object sender, EventArgs e)
    {
        var popup = sender as Tizen.NUI.Wearable.Popup;
        if (popup != null)
        {
            popup.Dismiss();
        }
    }

    public override string RunningDescription => "Black popup appears in the center.";

    public override string PassCondition => "The text will be yellow and click the left button.\nThe popup will disappear when click the right button.";
}
