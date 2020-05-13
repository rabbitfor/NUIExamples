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
using Tizen.NUI.Wearable;

public class NUISampleApplication : NUIApplication
{
    CircularScrollBar scrollbar;
    float currentPosition = 0;
    float contentLength = 2000;
    float lastY = 0;

    NUISampleApplication() : base()
    {
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        Initialize();
    }

    void Initialize()
    {
        var window = NUIApplication.GetDefaultWindow();
        var windowSize = Math.Min(window.Size.Width, window.Size.Height);

        scrollbar = new CircularScrollBar(contentLength, windowSize, currentPosition);
        scrollbar.Thickness = 60.0f;
        scrollbar.TrackColor = Color.Blue;

        window.Add(scrollbar);
        window.TouchEvent += OnTouch;
        window.KeyEvent += OnKeyEvent;
    }

    void OnTouch(object target, Window.TouchEventArgs args)
    {
        var currentY = args.Touch.GetScreenPosition(0).Y;

        if (args.Touch.GetState(0) == PointStateType.Motion)
        {
            var nextPosition = currentPosition + currentY - lastY;

            if (nextPosition < 0)
            {
                nextPosition = 0;
            }
            else if (nextPosition > contentLength)
            {
                nextPosition = contentLength;
            }

            scrollbar.GoTo(nextPosition);

            currentPosition = nextPosition;
        }

        lastY = currentY;
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
