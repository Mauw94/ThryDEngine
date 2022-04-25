namespace ThryDEngine.Engine
{
    public class AnimatedSprite : Sprite, IComponent
    {
        public Animation Animation { get; private set; }
        public List<Bitmap> Animations { get; private set; }
        public int AnimationSpeed { get; set; } = 25;

        public AnimatedSprite(Vector2 position, Vector2 scale, List<string> imageNames, string tag)
            : base(position, scale, tag)
        {
            // Load all separate textures here for the animations.

            Animations = new();
            foreach (var animation in imageNames)
            {
                Animations.Add(TextureLoader.Load(animation, (int)Scale.X, (int)Scale.Y));
            }

            Image = Animations.First();
            Animation = new(AnimationSpeed, Animations.ToArray());

            Log.Info($"[ANIMATED_SPRITE]({Tag}) - has been registered");

            GameEngineBase.RegisterSprite(this);
        }

        public new void Update()
        {
            Animation.Update();
            Image = Animation.CurrentImage;
            //Log.Info($"Image count: {Animation.FrameCount}");
            //Log.Warning($"Image changed");
        }
    }
}
