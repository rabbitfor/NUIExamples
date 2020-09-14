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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

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
        NUIApplication.GetDefaultWindow().BackgroundColor = Color.White;
        var root = NUIApplication.GetDefaultWindow();

        var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        themeBlack = new Theme(resourcePath + "Theme/Black.xaml");
        themeGreen = new Theme(resourcePath + "Theme/Green.xaml");

        ThemeManager.ApplyTheme(themeBlack);

        var themeChangeButton = new Button() {
            Position = new Position(30, 30),
            Size = new Size(400, 50),
            Text = "Click to change theme",
        };
        themeChangeButton.Clicked += OnClicked;
        root.Add(themeChangeButton);

        root.Add(new TextLabel() {
            Position = new Position(30, 100),
            ThemeChangeSensitive = true,
            Text = "Hello World!",
        });

        root.Add(new Button() {
            Position = new Position(30, 160),
            ThemeChangeSensitive = true,
        });

        root.Add(new CheckBox() {
            Position = new Position(30, 240),
            ThemeChangeSensitive = true,
            IsSelected = true,
        });

        root.Add(new CheckBox() {
            Position = new Position(130, 240),
            ThemeChangeSensitive = true,
        });

        root.Add(new CheckBox() {
            Position = new Position(230, 240),
            ThemeChangeSensitive = true,
            IsEnabled = false,
        });

        root.Add(new Switch() {
            Position = new Position(30, 320),
            ThemeChangeSensitive = true,
        });
    }

    private void OnClicked(object target, ClickedEventArgs args)
    {
        clickCount++;

        if ((clickCount) % 2 == 0) ThemeManager.ApplyTheme(themeBlack);
        else ThemeManager.ApplyTheme(themeGreen);
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
