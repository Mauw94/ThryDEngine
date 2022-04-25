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

        private readonly int _threshold;
        private float _timer = 0f;

        public Animation(int threshold, Bitmap[] frames)
        {
            _threshold = threshold;
            Frames = frames;
        }

        public void Update()
        {
            _timer += (float)GameEngineBase.ElapsedGameTime.TotalMilliseconds;

            if (CurrentFrame > FrameCount)
                CurrentFrame = 0;

            if (!(_timer > _threshold)) return;
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
