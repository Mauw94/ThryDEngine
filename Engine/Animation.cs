namespace ThryDEngine.Engine
{
    /// <summary>
    /// Instantiate a new animation for a sprite.
    /// </summary>
    public class Animation
    {
        public Bitmap[] Frames { get; private set; }
        public int CurrentFrame { get; private set; }
        public bool PlayedOnce { get; private set; }
        public int FrameCount => Frames.Length;

        private readonly int _animationSpeed;
        private float _timer = 0f;

        public Animation(int animationSpeed, Bitmap[] frames)
        {
            Frames = frames;
            _animationSpeed = animationSpeed;
        }

        public void Update()
        {
            _timer += (float)GameEngineBase.ElapsedGameTime.TotalMilliseconds;

            if (CurrentFrame > FrameCount)
                CurrentFrame = 0;

            if (!(_timer > _animationSpeed)) return;
            _timer = 0f;
            CurrentFrame++;
            PlayedOnce = false;

            if (CurrentFrame < FrameCount) return;
            PlayedOnce = true;
            CurrentFrame = 0;
        }

        public Bitmap CurrentImage => Frames[CurrentFrame];
    }
}
