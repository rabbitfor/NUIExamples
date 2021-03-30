/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

public class NUISampleApplication : NUIApplication
{
    protected override void OnCreate()
    {
        base.OnCreate();

        Initialize();
    }

    Theme themeBlack, themeGreen;
    int clickCount = 0;

    void Initialize()
    {
        var root = NUIApplication.GetDefaultWindow();
        var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        // Load and apply theme from xaml file.
        themeBlack = new Theme(resourcePath + "Theme/Black.xaml");
        themeGreen = new Theme(resourcePath + "Theme/Green.xaml");
        ThemeManager.ApplyTheme(themeBlack);

        root.Add(new TextLabel()
        {
            Text = "Please press 1 to change theme",
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            WidthResizePolicy = ResizePolicyType.FillToParent,
            SizeHeight = 60,
            BackgroundColor = new Color("#AAAAAA")
        });
        root.BackgroundColor = Color.White;

        // [Sample 1]
        // The default TextLabel style is named "Tizen.NUI.BaseComponents.TextLabel" in theme file.
        root.Add(new TextLabel() {
            Position = new Position(30, 120),
            Text = "Hello World!",
        });

        // [Sample 2]
        // ThemeChangeSensitive need to be set to get notified theme change.
        root.Add(new TextLabel() {
            Position = new Position(30, 180),
            Text = "Hello World!",
            ThemeChangeSensitive = true,
        });

        // [Sample 3]
        root.Add(new TextLabel() {
            StyleName = "TextLabelTypeA",
            Position = new Position(30, 240),
            Text = "Hello World!",
            ThemeChangeSensitive = true,
        });

        // [Sample 4]
        root.Add(new TextLabel() {
            StyleName = "TextLabelTypeB",
            Position = new Position(30, 300),
            Text = "Hello World!",
            ThemeChangeSensitive = true,
        });

        // [Sample 5]
        root.Add(new TextField() {
            StyleName = "TextFieldTypeA",
            Position = new Position(30, 360),
            ThemeChangeSensitive = true,
        });
    }

    public void OnKeyEvent(object sender, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down)
        {
            if (e.Key.KeyPressedName == "1")
            {
                clickCount++;
                if ((clickCount) % 2 == 0) ThemeManager.ApplyTheme(themeBlack);
                else ThemeManager.ApplyTheme(themeGreen);
            }
            else if (e.Key.KeyPressedName == "XF86Back")
            {
                Exit();
            }
        }
    }

    static void Main(string[] args)
    {
        NUISampleApplication example = new NUISampleApplication();
        example.Run(args);
    }
}
