namespace ThryDEngine.Engine
{
    public class Sprite2D
    {
        public Vector2 Position;
        public Vector2 Scale;
        public string Directory = string.Empty;
        public string Tag = string.Empty;
        public Bitmap Sprite;

        public Sprite2D(Vector2 position, Vector2 scale, string directory, string tag)
        {
            Position = position;
            Scale = scale;
            Directory = directory;
            Tag = tag;

            Sprite = TextureLoader.Load(directory, (int)Scale.X, (int)Scale.Y);

            Log.Info($"[SPRITE]({Tag}) - has been registered");
            GameEngineBase.RegisterSprite(this);
        }

        public bool IsColliding(Sprite2D a, Sprite2D b)
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
    }
}
