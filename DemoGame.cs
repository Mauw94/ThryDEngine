using ThryDEngine.Engine;

namespace ThryDEngine
{
    public class DemoGame : ExpressedEngine
    {
        Sprite2D player;

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
        }

        public override void Initialize()
        {
        }

        public override void OnLoad()
        {
            BackgroundColor = Color.Beige;
            player = new(new Vector2(20, 20), new Vector2(20, 20), "player-explore", "player");

            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "g")
                        new Sprite2D(new Vector2(i * 20, j * 20), new Vector2(20, 20), "Stones/Stone-1", "Ground");
                }
            }
        }

        float x = 0.1f;
        public override void Update()
        {
            player.Position.X += x;
            //player.Scale.X += x;
        }
    }
}
