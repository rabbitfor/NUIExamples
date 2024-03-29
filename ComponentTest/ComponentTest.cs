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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class NUISampleApplication : NUIApplication
{
    private TestUnit currentTest;
    private View currentView;
    private TextLabel runningDescription;
    private TextLabel passCondition;
    private TextLabel testDescription;
    private int currentIndex;
    private bool testDone = false;
    private List<string> list = new List<string>();


    public NUISampleApplication() : base(new Size2D(720, 980), new Position2D(0, 0))
    {
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        var window = NUIApplication.GetDefaultWindow();
        window.BackgroundColor = Color.White;
        window.KeyEvent += OnKeyEvent;

        Assembly assembly = this.GetType().Assembly;

        Type testUnitType = typeof(TestUnit);

        foreach (Type type in assembly.GetTypes())
        {
            if (testUnitType.IsAssignableFrom(type) && true != type.IsAbstract && true == type.IsClass)
            {
                list.Add(type.Name);
            }
        }

        Next();
    }

    public void Next()
    {
        var window = NUIApplication.GetDefaultWindow();

        if (currentIndex == list.Count)
        {
            currentTest?.OnDestroy(currentView);
            window.Remove(currentView);
            currentView = null;
            testDescription.Text = "All test is done!";
            window.Remove(runningDescription);
            window.Remove(passCondition);
            testDone = true;
            return;
        }

        if (currentIndex >= list.Count) Exit();

        string testName = list[currentIndex++];
        TestUnit testUnit = this.GetType().Assembly.CreateInstance(testName) as TestUnit;

        if (testUnit == null)
        {
            Next();
            return;
        }

        if (currentTest != null)
        {
            currentTest.OnDestroy(currentView);
            window.Remove(currentView);
            currentView = null;
        }
        currentTest = testUnit;

        if (testDescription == null)
        {
            testDescription = new TextLabel
            {
                TextColor = Color.White,
                MultiLine = true,
                BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 1.0f),
                PixelSize = 12,
                Position = new Position(0, 580),
                Size = new Size(720, 400),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
            };
            window.Add(testDescription);
            testDescription.TouchEvent += OnDescriptionTouch;
        }

        if (runningDescription == null)
        {
            runningDescription = new TextLabel
            {
                TextColor = Color.Black,
                MultiLine = true,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1.0f),
                PixelSize = 12,
                Size = new Size(710, 175),
                Position = new Position(5, 620),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
            };
            window.Add(runningDescription);
        }

        if (passCondition == null)
        {
            passCondition = new TextLabel
            {
                TextColor = Color.Black,
                MultiLine = true,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1.0f),
                PixelSize = 12,
                Size = new Size(710, 175),
                Position = new Position(5, 805),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
            };
            window.Add(passCondition);
        }

        currentView = TestUtils.CreateEmptyView();
        testUnit.OnCreate(currentView);
        testDescription.Text = "<TC: " + testName + ">\n" + testUnit.TestDescription;
        runningDescription.Text = "[First Look]\n" + testUnit.RunningDescription;
        passCondition.Text = "[Pass Condition]\n" + testUnit.PassCondition;
        window.Add(currentView);
    }

    public bool OnDescriptionTouch(object sender, View.TouchEventArgs args)
    {
        if (args.Touch.GetState(0) == PointStateType.Down)
        {
            if (testDone) Exit();
            else Next();
        }

        return false;
    }

    public void OnKeyEvent(object sender, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
        {
            Exit();
        }
        else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
        {
            Next();
        }
    }

    static void Main(string[] args)
    {
        NUISampleApplication example = new NUISampleApplication();
        example.Run(args);
    }
}
