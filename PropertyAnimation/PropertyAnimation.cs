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
    View root;
    static readonly Size sampleBoxSize = new Size(80, 80);
    static readonly Color sampleBoxColor = new Color(0.537f, 0.725f, 0.78f, 1.0f);
    private Animation animation;

    public NUISampleApplication() : base(new Size2D(480, 800), new Position2D(0, 0))
    {}

    protected override void OnCreate()
    {
        base.OnCreate();

        Initialize();
    }

    void Initialize()
    {
        SetTitleAndBackgrounds();

        animation = new Animation(2000) { Looping = true, EndAction = Animation.EndActions.Discard };

        CreateItem("CornerRadius [0 ⟷ 40]", (View view)=>{
            animation.AnimateTo(view, "CornerRadius", 40.0f, 0, 1000);
            animation.AnimateTo(view, "CornerRadius", 0.0f, 1000, 2000);
        });

        CreateItem("BackgroundColor [sky ⟷ yellow]", (View view)=>{
            animation.AnimateTo(view, "BackgroundColor", new Vector3(1.0f, 1.0f, 0), 0, 1000);
            animation.AnimateTo(view, "BackgroundColor", new Vector3(0.537f, 0.725f, 0.78f), 1000, 2000);
        });

        CreateItem("BoxShadow.BlurRadius [0 ⟷ 10]", (View view)=>{
            animation.AnimateTo(view, "BoxShadow.BlurRadius", 10.0f, 0, 1000);
            animation.AnimateTo(view, "BoxShadow.BlurRadius", 0.0f, 1000, 2000);
        });
    }

    void SetTitleAndBackgrounds()
    {
        var window = NUIApplication.GetDefaultWindow();
        window.BackgroundColor = new Color(0.678f, 0.655f, 0.576f, 1.0f);
        window.Add(new TextLabel() { Text = " Animation", PointSize = 13, Position = new Position(300, 18) });

        var button = new Switch()
        {
            Size = new Size(60, 40),
            Position = new Position(400, 10)
        };
        button.Track.Size = new Size(60, 40);
        button.Thumb.Size = new Size(40, 40);
        button.SelectedChanged += OnAnimationButtonSelected;
        window.Add(button);

        root = new View()
        {
            Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical, CellPadding = new Size2D(0, 20) },
            Padding = 20,
            PositionY = 40,
        };
        window.Add(root);
    }

    void OnAnimationButtonSelected(object sender, SelectedChangedEventArgs args)
    {
        if (args.IsSelected) animation.Play();
        else animation.Stop();
    }

    void CreateItem(string title, Action<View> animationRegister)
    {
        var item = new View()
        {
            Size = new Size(440, 160),
            BackgroundColor = Color.White,
            Padding = new Extents(20, 20, 20, 20),
            CornerRadius = 6,
            Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical, CellPadding = new Size2D(0, 20) },
        };

        item.Add(new TextLabel() { Text = title, PointSize = 13 });

        var target = new View()
        {
            Size = new Size(80, 80),
            BackgroundColor = new Color(0.537f, 0.725f, 0.78f, 1.0f),
            CornerRadius = 4.0f,
            BoxShadow = new Shadow()
            {
                Color = new Color(0, 0, 0, 0.5f),
                Offset = new Vector2(5, 5)
            }
        };
        item.Add(target);
        root.Add(item);
        animationRegister?.Invoke(target);
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
