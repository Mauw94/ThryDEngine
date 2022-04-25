namespace ThryDEngine.Engine
{
    /// <summary>
    /// Base class for most components used in the application.
    /// </summary>
    public abstract class Component
    {
        public abstract void Update();
        public abstract void Draw();
    }
}
