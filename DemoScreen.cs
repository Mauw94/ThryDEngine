using ThryDEngine.Engine;

namespace ThryDEngine
{
    public class DemoScreen : GameScreen
    {
        Sprite player;
        AnimatedSprite player2;

        bool left;
        bool right;
        bool up;
        bool down;

        Vector2 lastPos = Vector2.Zero();

        string[,] Map =
{
            {".",".",".",".",".",".","." },
            {".",".","g","g",".",".","." },
            {"g",".","g",".",".",".","." },
            {".",".","g",".",".",".","." },
            {"g","g","g","g","g","g","." },
            {".",".",".",".",".",".","." },
        };

        public override void OnLoad()
        {
            player = new(new Vector2(20, 20), new Vector2(20, 20), "player-explore", "player");
            
            player2 = new(new Vector2(100, 100), new Vector2(20, 20),
                new List<string>(){
                    "earth_planet",
                    "rocky_planet",
                    "gas_planet"}, "player");

            Sprite wallsRef = new("Stones/Stone-1");

            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "g")
                        new Sprite(new Vector2(i * 20, j * 20), new Vector2(20, 20), wallsRef, "Ground");
                }
            }
        }

        public override void Update()
        {
            base.Update();

            player.Update();
            player2.Update();

            if (up) player.Position.Y -= 1f;
            if (down) player.Position.Y += 1f;
            if (left) player.Position.X -= 1f;
            if (right) player.Position.X += 1f;

            if (player.IsColliding(player, player2))
                Log.Warning("Colliding");

            if (player.IsColliding("Ground"))
            {
                Log.Warning("Colliding");
                player.Position.X = lastPos.X;
                player.Position.Y = lastPos.Y;
            }
            else
            {
                lastPos.X = player.Position.X;
                lastPos.Y = player.Position.Y;
            }

            //Game.CameraPosition.X += 1f;
        }

        public override void Draw()
        {
            //Game.Graphics.DrawRectangle(new Pen(new Brush(Color.AliceBlue)));
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) up = true;
            if (e.KeyCode == Keys.S) down = true;
            if (e.KeyCode == Keys.A) left = true;
            if (e.KeyCode == Keys.D) right = true;

            if (e.KeyCode == Keys.Escape) ScreenState = ScreenState.HIDDEN;
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
