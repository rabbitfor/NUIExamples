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

public class NUISampleApplication : NUIApplication
{
    private const float DefaultShadowOffset = 20;
    private const float DefaultShadowBlurRadius = 10;

    private float mCurrentAbsRadian = 0.7f;
    private float mLastRadian = 0;
    private float mLastDistance = 0;

    public NUISampleApplication() : base()
    {
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        Window window = NUIApplication.GetDefaultWindow();
        window.BackgroundColor = Color.White;

        var view = new View()
        {
            BackgroundColor = Color.Blue,
            Size = new Size(300, 300),
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
            PositionUsesPivotPoint = true,
            BoxShadow = new Shadow
            {
                Offset = GetShadowOffsetByCurrentAngle(),
                BlurRadius = DefaultShadowBlurRadius,
            }
        };

        view.TouchEvent += OnControlTouch;
        window.Add(view);
    }

    private Vector2 GetShadowOffsetByCurrentAngle()
    {

        return new Vector2((float)(DefaultShadowOffset * Math.Sin(mCurrentAbsRadian)), (float)(DefaultShadowOffset * Math.Cos(mCurrentAbsRadian)));
    }

    private bool OnControlTouch(object target, View.TouchEventArgs args)
    {
        View view = target as View;
        Touch touch = args.Touch;

        if (view == null || touch.GetPointCount() != 2)
        {
            return false;
        }

        Vector2 p1 = touch.GetScreenPosition(0);
        Vector2 p2 = touch.GetScreenPosition(1);

        float radian = (float)Math.Atan2(p1.Y - p2.Y, p1.X - p2.X);
        float distance = (p1 - p2).Length();

        if (!(touch.GetState(0) == PointStateType.Started || touch.GetState(1) == PointStateType.Started))
        {
            Radian r = new Radian(radian - mLastRadian);
            view.RotateBy(r, new Vector3(0, 0, 1));

            float s = distance / mLastDistance;
            view.ScaleBy(new Vector3(s, s, 1));

            mCurrentAbsRadian += (radian - mLastRadian);

            view.BoxShadow = new Shadow
            {
                Offset = GetShadowOffsetByCurrentAngle(),
                BlurRadius = DefaultShadowBlurRadius,
            };
        }

        mLastRadian = radian;
        mLastDistance = distance;

        return true;
    }

    static void Main(string[] args)
    {
        NUISampleApplication example = new NUISampleApplication();
        example.Run(args);
    }
}
