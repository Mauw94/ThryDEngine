namespace ThryDEngine.Engine
{
    public class Shape2D
    {
        public Vector2 Position;
        public Vector2 Scale;
        public string Tag = string.Empty;

        public Shape2D(Vector2 position, Vector2 scale, string tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;

            Log.Info($"[SHAPE2D]({Tag}) - has been registered");
            ExpressedEngine.RegisterShape(this);
        }

        public void DestroySelf()
        {
            Log.Info($"[SHAPE2D]({Tag}) - has been destroyed");
            ExpressedEngine.UnRegisterShape(this);
        }
    }
}
