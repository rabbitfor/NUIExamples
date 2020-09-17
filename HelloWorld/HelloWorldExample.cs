/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using Tizen.NUI;
// using Tizen.FH.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Wearable;
// using Tizen.FH.NUI.Components;


public class NUISampleApplication : NUIApplication
{
    private class Config
    {
        public const int PAGINATION_POSITION_Y = 263 + 1266;
        public const int PAGINATION_HEIGHT = 170;
        public const int PAGINATION_INDICATOR_WIDTH = 14;
        public const int PAGINATION_INDICATOR_HEIGHT = PAGINATION_INDICATOR_WIDTH;
        public const int PAGINATION_PADDING = 10;
    }

    private Button button;
    private Pagination pagination;

    protected override void OnCreate()
    {
        base.OnCreate();

        Initialize();
    }

    void Initialize()
    {
        var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        NUIApplication.GetDefaultWindow().BackgroundColor = new Color("#ebba34");

        SetupButtons();

        View rootSettingView = new View()
        {
            Layout = new AbsoluteLayout(),

            WidthSpecification = Window.Instance.Size.Width,
            HeightSpecification = Window.Instance.Size.Height,
        };
        Window.Instance.Add(rootSettingView);

        View paginationLayout = new View()
        {
            Layout = new AbsoluteLayout(),
            PositionY = Config.PAGINATION_POSITION_Y,
            WidthSpecification = LayoutParamPolicies.WrapContent,
            HeightSpecification = LayoutParamPolicies.WrapContent,
        };
        rootSettingView.Add(paginationLayout);

        pagination = new Pagination()
        {
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
            WidthSpecification = Window.Instance.Size.Width,
            HeightSpecification = Config.PAGINATION_HEIGHT,
            IndicatorSize = new Size(Config.PAGINATION_INDICATOR_WIDTH, Config.PAGINATION_INDICATOR_HEIGHT),
            IndicatorImageUrl = new StringSelector
            {
                Normal = resourcePath + "edit_mode_indicator_dim.png",
                Selected = resourcePath + "edit_mode_indicator_focus.png"
            },
            LastIndicatorImageUrl = new StringSelector
            {
                Normal = resourcePath + "edit_ic_plus_nor.png",
                Selected = resourcePath + "edit_ic_plus_sel.png"
            },
            IndicatorSpacing = Config.PAGINATION_PADDING,
            IndicatorCount = 3,
            SelectedIndex = 0
        };
        paginationLayout.Add(pagination);
    }

    private void SetupButtons()
    {
        var prevButton = new Button()
        {
            Text = "<",
            PointSize = 18,
            Size = new Size(200, 100),
            Position = new Position(0, 0)
        };
        prevButton.Clicked += OnPrev;
        Window.Instance.Add(prevButton);

        var AddButton = new Button()
        {
            Text = "ADD",
            PointSize = 18,
            Size = new Size(200, 100),
            Position = new Position(210, 0)
        };
        AddButton.Clicked += OnAdded;
        Window.Instance.Add(AddButton);

        var removeButton = new Button()
        {
            Text = "REMOVE",
            PointSize = 18,
            Size = new Size(200, 100),
            Position = new Position(420, 0)
        };
        removeButton.Clicked += OnRemoved;
        Window.Instance.Add(removeButton);

        var nextButton = new Button()
        {
            Text = ">",
            PointSize = 18,
            Size = new Size(200, 100),
            Position = new Position(630, 0)
        };
        nextButton.Clicked += OnNext;
        Window.Instance.Add(nextButton);
    }

 
    // private void OnClicked(object target, ClickedEventArgs args)
    // {
    //     Tizen.NUI.StyleManager.Instance.ApplyTheme(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "tempTheme.json");
    //     Tizen.NUI.Components.StyleManager.Instance.Theme = "SomeTheme";
    // }

    private void OnAdded(object target, ClickedEventArgs args)
    {
        pagination.IndicatorCount += 1;
    }

    private void OnRemoved(object target, ClickedEventArgs args)
    {
        if (pagination.IndicatorCount <= 1) return;
        if (pagination.SelectedIndex == pagination.IndicatorCount - 1)
        {
            pagination.SelectedIndex -= 1;
        }
        pagination.IndicatorCount -= 1;
    }

    private void OnPrev(object target, ClickedEventArgs args)
    {
        if (pagination.SelectedIndex > 0)
        {
            pagination.SelectedIndex -= 1;
        }
    }

    private void OnNext(object target, ClickedEventArgs args)
    {
        if (pagination.SelectedIndex < pagination.IndicatorCount - 1)
        {
            pagination.SelectedIndex += 1;
        }
    }

    public void OnKeyEvent(object sender, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
        {
            Exit();
        }
    }

    static void Main(string[] args)
    {
        NUISampleApplication example = new NUISampleApplication();
        example.Run(args);
    }
}
