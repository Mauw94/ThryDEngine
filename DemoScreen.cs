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

        public override void LoadContent()
        {
            player = new(new Vector2(20, 20), new Vector2(20, 20), "player-explore", "player");

            player2 = new(new Vector2(100, 100), new Vector2(20, 20),
                new List<string>(){
                    "earth_planet",
                    "rocky_planet",
                    "gas_planet"}, "player");
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
            {
                Log.Warning("Colliding");
            }
        }

        public override void Draw()
        {
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
