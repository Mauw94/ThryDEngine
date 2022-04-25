namespace ThryDEngine.Engine
{
    public class Sprite : IComponent
    {
        public Vector2 Position;
        public Vector2 Scale;
        public string Directory = string.Empty;
        public string Tag = string.Empty;
        public Bitmap Image;

        public Sprite(Vector2 position, Vector2 scale, string directory, string tag)
        {
            Position = position;
            Scale = scale;
            Directory = directory;
            Tag = tag;

            Image = TextureLoader.Load(directory, (int)Scale.X, (int)Scale.Y);

            Log.Info($"[SPRITE]({Tag}) - has been registered");
            GameEngineBase.RegisterSprite(this);
        }

        public Sprite(Vector2 position, Vector2 scale, string tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;

            Log.Info($"[SPRITE]({Tag}) - has been registered (with no texture)");
            GameEngineBase.RegisterSprite(this);
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
            GameEngineBase.UnRegisterSprite(this);
        }

        public void Update()
        {
        }
    }
}
