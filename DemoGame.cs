using ThryDEngine.Engine;

namespace ThryDEngine
{
    public class DemoGame : Game
    {
        bool left;
        bool right;
        bool up;
        bool down;

        // 32 width
        // 24 height
        string[,] Map =
        {
            {".",".",".",".",".",".","." },
            {".",".","g","g",".",".","." },
            {"g",".","g",".",".",".","." },
            {".",".","g",".",".",".","." },
            {"g","g","g","g","g","g","." },
            {".",".",".",".",".",".","." },
        };

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

            //for (int i = 0; i < Map.GetLength(1); i++)
            //{
            //    for (int j = 0; j < Map.GetLength(0); j++)
            //    {
            //        if (Map[j, i] == "g")
            //            new Sprite(new Vector2(i * 20, j * 20), new Vector2(20, 20), "Stones/Stone-1", "Ground");
            //    }
            //}
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
