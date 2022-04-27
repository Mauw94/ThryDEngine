using ThryDEngine.Engine;

namespace ThryDEngine
{
    public class DemoGame : Game
    {
        GameScreen _mainScreen;

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

            _mainScreen = new DemoScreen
            {
                IsInFocus = true,
                Game = Engine
            };
            ScreenManager.AddScreen(_mainScreen);
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
