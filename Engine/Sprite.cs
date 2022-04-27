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
        public bool IsReference = false;

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

        public Sprite(string spriteName)
        {
            IsReference = true;
            SpriteName = spriteName;

            Image = SpriteLoader.Load(spriteName);

            Log.Info($"[SPRITE]({Tag}) - has been registered");
            Game.RegisterSprite(this);
        }

        public Sprite(Vector2 position, Vector2 scale, Sprite reference, string tag)
        {
            Position = position;
            Scale = scale;
            SpriteName = reference.SpriteName;
            Tag = tag;

            Image = reference.Image;

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

        public bool IsColliding(string tag)
        {
            foreach (Sprite b in Game.Sprites)
            {
                if (b.Tag == tag)
                {
                    if (Position.X < b.Position.X + b.Scale.X &&
                        Position.X + Scale.X > b.Position.X &&
                        Position.Y < b.Position.Y + b.Scale.Y &&
                        Position.Y + Scale.Y > b.Position.Y)
                        return true;
                }
            }
            return false;
        }

        public void DestroySelf()
        {
            Log.Info($"[SPRITE]({Tag}) - has been destroyed");
            Game.UnRegisterSprite(this);
        }

        public override void Update()
        {
            if (Game.SpriteBatch == null) return;
            Game.SpriteBatch.MoveCamera(1f, 0f);
            Game.SpriteBatch.Rotate(2f);
        }

        public override void Draw()
        {
        }
    }
}
