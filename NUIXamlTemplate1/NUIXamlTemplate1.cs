using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIXamlTemplate1
{
    class Program : NUIApplication
    {
        Animation animation;
        protected override void OnCreate()
        {
            base.OnCreate();
            Window.Instance.BackgroundColor = Color.Blue;
            Window.Instance.KeyEvent += OnKeyEvent;

            XamlPage page = new XamlPage();
            Window.Instance.Add(page);

            // animation = new Animation(2000);
            // animation.AnimateTo(page.text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
            // animation.AnimateTo(page.text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
            // animation.Looping = true;
            // animation.Play();

            // Window.Instance.Add(new Button());

            // TextLabel text = new TextLabel(new TextLabelStyle
            // {
            //     TextColor = Color.Yellow,
            // });
            // text.Text = "Hello!!!!!";
            // Window.Instance.Add(page);
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
            var app = new Program();
            app.Run(args);
        }
    }
}
