/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

class HelloWorldExample : NUIApplication
{
    static readonly Color CardColor = new Color("#88888888");

    public HelloWorldExample() : base(ThemeOptions.PlatformThemeEnabled | ThemeOptions.ThemeChangeSensitive)
    {
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        string ResPath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        var themes = new Theme[] {
            new Theme(ResPath + "dark/Tizen.NUI.Components.Theme.xaml"),
            new Theme(ResPath + "light/Tizen.NUI.Components.Theme.xaml")
        };
        int i = 0;

        // Main container
        var closeButton = new Button()
        {
            Text = "Theme"
        };
        closeButton.Clicked += (s, e) => {
            ThemeManager.ApplyTheme(themes[i]);
            i = (i + 1)%2;

            // if (ThemeManager.PlatformThemeId == ThemeManager.DefaultDarkThemeName)
            // {
            //     ThemeManager.SetPlatformTheme(ThemeManager.DefaultLightThemeName);
            //     text.Text = "Current theme: Light";
            // }
            // else
            // {
            //     ThemeManager.SetPlatformTheme(ThemeManager.DefaultDarkThemeName);
            //     text.Text = "Current theme: Dark";
            // }
        };

        var mainPage = new ContentPage()
        {
            AppBar = new AppBar()
            {
                AutoNavigationContent = false,
                Title = "NUI theme sample",
                Actions = new View[] { closeButton },
            },
            Content = new ScrollableBase()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(20, 20)
                },
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Padding = new Extents(30, 30, 20, 20)
            }
        };

        mainPage.Content.Add(CreateLinearLayout("Switch", delegate(View view) {
            view.Add(new Switch() { Text = "Normal" });
            view.Add(new Switch() { Text = "Selected", IsSelected = true });
            view.Add(new Switch() { Text = "Disabled", IsEnabled = false });
            view.Add(new Switch() { Text = "Disabled Selected", IsSelected = true, IsEnabled = false });
        }));

        mainPage.Content.Add(CreateLinearLayout("Button", delegate(View view) {
            ((LinearLayout)view.Layout).LinearAlignment = LinearLayout.Alignment.Center;
            view.Add(new Button() { Text = "Button", IconURL = ResPath + "icon/icon0.png"});
            view.Add(new Button() { Text = "Button", IconURL = ResPath + "icon/icon0.png", IconRelativeOrientation = Button.IconOrientation.Right });
            view.Add(new Button() { Text = "Button (Disabled)", IconURL = ResPath + "icon/icon0.png", IsEnabled = false });
            view.Add(new Button("Tizen.NUI.Components.Button.Outlined") { Text = "Outlined Button"});
            view.Add(new Button("Tizen.NUI.Components.Button.TextOnly") { Text = "TextOnly Button"});
        }));

        mainPage.Content.Add(CreateLinearLayout("TextField", delegate(View view) {
            view.Add(new TextField() {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                PlaceholderText = "Search",
            });
        }));

        mainPage.Content.Add(CreateLinearLayout("RadioButton", delegate(View view) {
            RadioButton radio1, radio2, radio3;
            var group = new RadioButtonGroup();
            group.Add(radio1 = new RadioButton() { Text = "Radio1", IsSelected = true });
            group.Add(radio2 = new RadioButton() { Text = "Radio2"});
            group.Add(radio3 = new RadioButton() { Text = "Radio3", IsEnabled = false});
            view.Add(radio1);
            view.Add(radio2);
            view.Add(radio3);
        }));

        mainPage.Content.Add(CreateLinearLayout("Progress", delegate(View view) {
            view.Add(new Progress() {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                MaxValue = 100,
                CurrentValue = 30
            });
            view.Add(new Progress() {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                ProgressState = Progress.ProgressStatusType.Indeterminate
            });
        }));

        mainPage.Content.Add(CreateLinearLayout("Loading", delegate(View view) {
            ((LinearLayout)view.Layout).LinearAlignment = LinearLayout.Alignment.Center;
            view.Add(new Loading());
        }));

        mainPage.Content.Add(CreateLinearLayout("Slider", delegate(View view) {
            Slider slider;
            view.Add(slider = new Slider() {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                MinValue = 0,
                MaxValue = 100,
                CurrentValue = 40,
                Indicator = Slider.IndicatorType.Text,
                IsValueShown = true,
            });
            slider.ValueChanged += (s, e) => {
                ((Slider)s).ValueIndicatorText = ((SliderValueChangedEventArgs)e).CurrentValue.ToString();
            };
            view.Add(new Slider() {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                MinValue = 0,
                MaxValue = 100,
                CurrentValue = 60,
                Indicator = Slider.IndicatorType.Text,
                IsEnabled = false
            });
        }));

        mainPage.Content.Add(CreateItem("Pagination", delegate(View view) {
            var container = new View() {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                SizeHeight = 200,
            };
            view.Add(container);
            Button addButton, removeButton, prevButton, nextButton;
            Pagination pagination;
            container.Add(addButton = new Button() { Text = "+", PointSize = 10, Size = new Size(50, 30) });
            container.Add(removeButton = new Button() { Text = "-", PointSize = 10, Size = new Size(50, 30), ParentOrigin = ParentOrigin.TopRight, PivotPoint = PivotPoint.TopRight, PositionUsesPivotPoint = true });
            container.Add(prevButton = new Button() { Text = "<<", PointSize = 10, Size = new Size(50, 30), ParentOrigin = ParentOrigin.BottomLeft, PivotPoint = PivotPoint.BottomLeft, PositionUsesPivotPoint = true });
            container.Add(nextButton = new Button() { Text = ">>", PointSize = 10, Size = new Size(50, 30), ParentOrigin = ParentOrigin.BottomRight, PivotPoint = PivotPoint.BottomRight, PositionUsesPivotPoint = true });

            container.Add(pagination = new Pagination() {
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                IndicatorCount = 2,
                SelectedIndex = 2
            });
            addButton.Clicked += (s, e) => { pagination.IndicatorCount++; };
            removeButton.Clicked += (s, e) => { pagination.IndicatorCount--; };
            prevButton.Clicked += (s, e) => { pagination.SelectedIndex--; };
            nextButton.Clicked += (s, e) => { pagination.SelectedIndex++; };
        }));

        mainPage.Content.Add(CreateClickableItem("AlertDialog", "Click to post alert", delegate(View view) {
            var dialogPage = new DialogPage()
            {
                Size = new Size(300, 200),
                ScrimColor = CardColor,
                Content = new AlertDialog()
                {
                    Title = "Notice",
                    Message = "Please touch outer area to dismiss",
                    // Actions =  actions,
                },
            };

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(dialogPage);
        }));

        mainPage.Content.Add(CreateLinearLayout("CheckBox", delegate(View view) {
            view.Add(new CheckBox() { Text = "Item1" });
            view.Add(new CheckBox() { Text = "Item2", IsSelected = true });
            view.Add(new CheckBox() { Text = "Long long item", IsEnabled = false });
        }));

        mainPage.Content.Add(CreateClickableItem("Exit", "Click to exit application", delegate(View view) {
            Exit();
        }));

        NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(mainPage);
    }

    private View CreateItem(string title, Action<View> afterCreated)
    {
        var item = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            },
            BackgroundColor = CardColor,
            CornerRadius = 8.0f,
            Padding = 10,
        };
        item.Add(new TextLabel()
        {
            PixelSize = 22.0f,
            Text = title,
            Margin = new Extents(0, 0, 0, 20)
        });
        afterCreated?.Invoke(item);
        return item;
    }

    private View CreateLinearLayout(string title, Action<View> afterCreated)
    {
        return CreateItem(title, delegate(View view) {
            var item = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(10, 10)
                },
            };
            view.Add(item);
            afterCreated?.Invoke(item);
        });
    }

    private View CreateClickableItem(string title, string subtitle, Action<View> clicked)
    {
        var item = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            },
            BackgroundColor = CardColor,
            CornerRadius = 16.0f,
            Padding = 20,
            LeaveRequired = true,
        };
        item.TouchEvent += (s, e) => {
            var state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                ((View)s).BackgroundColor = new Color("#888888BB");
            }
            else if (state == PointStateType.Up)
            {
                ((View)s).BackgroundColor = new Color("#88888860");
                clicked?.Invoke(item);
            }
            else if (state == PointStateType.Leave || state == PointStateType.Interrupted)
            {
                ((View)s).BackgroundColor = new Color("#88888860");
            }
            return true;
        };
        item.Add(new TextLabel()
        {
            PixelSize = 22.0f,
            Text = title,
            Padding = new Extents(0, 0, 0, 20)
        });
        item.Add(new TextLabel()
        {
            PixelSize = 32.0f,
            Text = subtitle,
            VerticalAlignment = VerticalAlignment.Center,
        });
        return item;
    }

    private View CreateTimePickerExample()
    {
        // var timePicker = new TimePicker()
        // {
        //     // ParentOrigin = ParentOrigin.Center,
        //     // PivotPoint = PivotPoint.Center,
        //     // PositionUsesPivotPoint = true,
        //     Size = new Size(200, 200),
        //     Hour = 12,
        //     Minute = 30,
        //     Is24HourView = false,
        // };
        // // timePicker.TimeChanged += TimeChanged;
        // // window.Add(timePicker);
        // return timePicker;
        return null;
    }

    private void FullGC()
    {
        global::System.GC.Collect();
        global::System.GC.WaitForPendingFinalizers();
        global::System.GC.Collect();
    }

    /// <summary>
    /// Called when any key event is received.
    /// Will use this to exit the application if the Back or Escape key is pressed
    /// </summary>
    private void OnKeyEvent( object sender, Window.KeyEventArgs eventArgs )
    {
        if( eventArgs.Key.State == Key.StateType.Down )
        {
            switch( eventArgs.Key.KeyPressedName )
            {
                case "Escape":
                case "Back":
                {
                    Exit();
                }
                break;
            }
        }
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        HelloWorldExample example = new HelloWorldExample();
        example.Run(args);
    }
}
