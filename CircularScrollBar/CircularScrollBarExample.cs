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
using Tizen.NUI.Wearable;

public class NUISampleApplication : NUIApplication
{
    CircularScrollbar scrollbar;
    float currentPosition = 0;
    float contentLength = 5760;
    float lastY = 0;

    NUISampleApplication() : base(new Size2D(360, 360), new Position2D(0, 0))
    {
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        var window = NUIApplication.GetDefaultWindow();
        var screenLength = Math.Min(window.Size.Width, window.Size.Height);

        scrollbar = new CircularScrollbar();
        scrollbar.Initialize(contentLength, screenLength, currentPosition);

        window.Add(scrollbar);
        scrollbar.TouchEvent += OnTouch;
    }

    bool OnTouch(object target, View.TouchEventArgs args)
    {
        if (args.Touch.GetState(0) == PointStateType.Down)
        {
            currentPosition = currentPosition == 0 ? contentLength : 0;
            scrollbar.ScrollTo(currentPosition, 500);
        }

        return true;
    }

    void OnKeyEvent(object sender, Window.KeyEventArgs e)
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
