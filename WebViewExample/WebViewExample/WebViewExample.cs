using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace WebViewExample
{
    class Program : NUIApplication
    {
        private TextLabel mText;
        private WebView mWebView;
        private int mUrlIndex = 0;
        private string[] mUrl = {
            "https://www.naver.com",
            "https://www.daum.net/",
            "https://www.google.com" };

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Tizen.Log.Fatal("NUI", "[MYLOG] --test WebView Sample");
            
            Window.Instance.KeyEvent += OnKeyEvent;

            Tizen.NUI.EnvironmentVariable.SetEnvironmentVariable("DALI_WEB_ENGINE_NAME", "lwe");

            // Tizen.Log.Fatal("NUI", "\n\nDALI_WEB_ENGINE_NAME uses lwe\n\n");

            string nextUrl = mUrl[mUrlIndex];
            mUrlIndex = (mUrlIndex + 1) % mUrl.Length;

            mWebView = new WebView("ko-KR", "Asia/Seoul");
            mWebView.ParentOrigin = ParentOrigin.TopLeft;
            mWebView.PivotPoint = PivotPoint.TopLeft;
            mWebView.Position2D = new Position2D(0, 0);
            mWebView.Size2D = new Size2D(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height);
            mWebView.LoadUrl(nextUrl);
            Window.Instance.GetDefaultLayer().Add(mWebView);

            mText = new TextLabel(nextUrl);
            mText.TouchEvent += OnTouchEvent;
            mText.HorizontalAlignment = HorizontalAlignment.Center;
            mText.VerticalAlignment = VerticalAlignment.Center;
            mText.TextColor = Color.White;
            mText.BackgroundColor = Color.Blue;
            mText.PointSize = 12.0f;
            Window.Instance.GetDefaultLayer().Add(mText);

        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        public bool OnTouchEvent(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down) {
                string nextUrl = mUrl[mUrlIndex];
                mUrlIndex = (mUrlIndex + 1) % mUrl.Length;

                mText.Text = nextUrl;
                mWebView.LoadUrl(nextUrl);
            }
            return true;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
