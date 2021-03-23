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

            // Tizen.NUI.EnvironmentVariable.SetEnvironmentVariable("DALI_WEB_ENGINE_NAME", "lwe");

            // Tizen.Log.Fatal("NUI", "\n\nDALI_WEB_ENGINE_NAME uses lwe\n\n");

            string nextUrl = mUrl[mUrlIndex];
            mUrlIndex = (mUrlIndex + 1) % mUrl.Length;

            Window.Instance.BackgroundColor = Color.Blue;

            // string[] args = new string[] { "com.samsung.tv.flux-example", "--enable-features=NativeScrollbar" };
            string webviewPath = "https://terms.account.samsung.com/contents/legal/kor/kor/customizedservicecontent.html";

            mWebView = new WebView();
            mWebView.Size2D = new Size2D(2000, 2000);
            mWebView.Focusable = true;
            Window.Instance.GetDefaultLayer().Add(mWebView);
            mWebView.LoadUrl(webviewPath);

            mText = new TextLabel(webviewPath);
            mText.TouchEvent += OnTouchEvent;
            mText.HorizontalAlignment = HorizontalAlignment.Center;
            mText.VerticalAlignment = VerticalAlignment.Center;
            mText.TextColor = Color.White;
            mText.BackgroundColor = Color.Blue;
            mText.PointSize = 12.0f;
            Window.Instance.GetDefaultLayer().Add(mText);

            // Window.Instance.TouchEvent += OnTouchEvent;

            FocusManager.Instance.SetCurrentFocusView(mWebView);

        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        int touchCount = 0;

        public bool OnTouchEvent(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down) {
                touchCount++;
                if (touchCount % 2 == 1)
                {
                    Window.Instance.Remove(mWebView);
                    mWebView.Dispose();
                    mWebView = null;
                }
                else
                {
                    string webviewPath = "https://terms.account.samsung.com/contents/legal/kor/kor/customizedservicecontent.html";

                    mWebView = new WebView();
                    mWebView.Size2D = new Size2D(2000, 2000);
                    mWebView.Focusable = true;
                    Window.Instance.GetDefaultLayer().Add(mWebView);
                    mWebView.LoadUrl(webviewPath);
                }
                // string nextUrl = mUrl[mUrlIndex];
                // mUrlIndex = (mUrlIndex + 1) % mUrl.Length;

                // mText.Text = nextUrl;
                // mWebView.LoadUrl(nextUrl);
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
