namespace ThryDEngine.Engine
{
    public class Sprite2D
    {
        public Vector2 Position;
        public Vector2 Scale;
        public string Directory = string.Empty;
        public string Tag = string.Empty;
        public Bitmap Sprite = null;

        public Sprite2D(Vector2 position, Vector2 scale, string directory, string tag)
        {
            Position = position;
            Scale = scale;
            Directory = directory;
            Tag = tag;

            Sprite = TextureLoader.Load(directory, (int)Scale.X, (int)Scale.Y);

            Log.Info($"[SPRITE]({Tag}) - has been registered");
            ExpressedEngine.RegisterSprite(this);
        }

        public void DestroySelf()
        {
            Log.Info($"[SPRITE]({Tag}) - has been destroyed");
            ExpressedEngine.UnRegisterSprite(this);
        }
    }
}
