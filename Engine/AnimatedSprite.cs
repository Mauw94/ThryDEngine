namespace ThryDEngine.Engine
{
    /// <summary>
    /// Animated sprite base class, inherits from Sprite.
    /// </summary>
    public class AnimatedSprite : Sprite
    {
        public Animation Animation { get; private set; }
        public Bitmap[] Animations { get; private set; }
        public int AnimationSpeed { get; set; } = 250;

        public AnimatedSprite(Vector2 position, Vector2 scale, List<string> imageNames, string tag)
            : base(position, scale, tag)
        {
            Animations = SpriteLoader.Load(imageNames, (int)Scale.X, (int)Scale.Y);
            Image = Animations.First();
            Animation = new(AnimationSpeed, Animations.ToArray());

            Log.Info($"[ANIMATED_SPRITE]({Tag}) - has been registered");

            GameEngineBase.RegisterSprite(this);
        }

        public override void Update()
        {
            Animation.Update();
            Image = Animation.CurrentImage;
        }
    }
}
