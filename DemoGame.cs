using ThryDEngine.Engine;

namespace ThryDEngine
{
    public class DemoGame : Game
    {
        /// <summary>
        /// Debug class.
        /// </summary>
        public DemoGame()
            : base(new Vector2(1024, 760), "Demo")
        {
        }

        public override void Draw()
        {
            ScreenManager.Draw();
        }

        public override void OnLoad()
        {
            BackgroundColor = Color.Beige;
            CameraPosition.X = 100;

            var mainScreen = new DemoScreen
            {
                IsInFocus = true
            };
            ScreenManager.AddScreen(mainScreen);
        }

        public override void Unload()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            ScreenManager.Update();
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            ScreenManager.GetKeyDown(e);
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            ScreenManager.GetKeyUp(e);
        }
    }
}
