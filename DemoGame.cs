using ThryDEngine.Engine;

namespace ThryDEngine
{
    public class DemoGame : GameEngineBase
    {
        Sprite player;
        Sprite player2;

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
        }

        public override void Initialize()
        {
        }

        public override void OnLoad()
        {
            BackgroundColor = Color.Beige;
            CameraPosition.X = 100;

            player = new(new Vector2(20, 20), new Vector2(20, 20), "player-explore", "player");
            player2 = new(new Vector2(100, 100), new Vector2(20, 20), "player-explore", "player");

            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "g")
                        new Sprite(new Vector2(i * 20, j * 20), new Vector2(20, 20), "Stones/Stone-1", "Ground");
                }
            }
        }

        public override void Update()
        {
            if (up) player.Position.Y -= 1f;
            if (down) player.Position.Y += 1f;
            if (left) player.Position.X -= 1f;
            if (right) player.Position.X += 1f;

            if (player.IsColliding(player, player2))
            {
                Log.Warning("Colliding");
            }

            // check collision with walls.

            //CameraPosition.X += 0.5f;
            //CameraPosition.Y += 0.5f;
            //CameraAngle += 0.8f;
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) up = true;
            if (e.KeyCode == Keys.S) down = true;
            if (e.KeyCode == Keys.A) left = true;
            if (e.KeyCode == Keys.D) right = true;
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) up = false;
            if (e.KeyCode == Keys.S) down = false;
            if (e.KeyCode == Keys.A) left = false;
            if (e.KeyCode == Keys.D) right = false;
        }
    }
}
