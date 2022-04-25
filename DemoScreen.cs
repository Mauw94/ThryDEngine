using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThryDEngine.Engine;

namespace ThryDEngine
{
    public class DemoScreen : GameScreen
    {
        Sprite player;
        AnimatedSprite player2;

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
        }

        public override void Draw()
        {
        }
    }
}
