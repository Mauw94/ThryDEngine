namespace ThryDEngine.Engine
{
    /// <summary>
    /// Sprite base class.
    /// </summary>
    public class Sprite : Component
    {
        public Vector2 Position;
        public Vector2 Scale;
        public string SpriteName = string.Empty;
        public string Tag = string.Empty;
        public Bitmap Image;

        public Sprite(Vector2 position, Vector2 scale, string spriteName, string tag)
        {
            Position = position;
            Scale = scale;
            SpriteName = spriteName;
            Tag = tag;

            Image = SpriteLoader.Load(spriteName, (int)Scale.X, (int)Scale.Y);

            Log.Info($"[SPRITE]({Tag}) - has been registered");
            Game.RegisterSprite(this);
        }

        public Sprite(Vector2 position, Vector2 scale, string tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;

            Log.Info($"[SPRITE]({Tag}) - has been registered (with no texture)");
            Game.RegisterSprite(this);
        }

        public void OverrideSpriteLoad(string spriteName, string extension)
        {
            Image = SpriteLoader.Load(spriteName, (int)Scale.X, (int)Scale.Y, extension);
        }

        public bool IsColliding(Sprite a, Sprite b)
        {
            if (a.Position.X < b.Position.X + b.Scale.X &&
                a.Position.X + a.Scale.X > b.Position.X &&
                a.Position.Y < b.Position.Y + b.Scale.Y &&
                a.Position.Y + a.Scale.Y > b.Position.Y)
                return true;

            return false;
        }

        public void DestroySelf()
        {
            Log.Info($"[SPRITE]({Tag}) - has been destroyed");
            Game.UnRegisterSprite(this);
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
        }
    }
}
