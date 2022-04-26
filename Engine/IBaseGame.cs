namespace ThryDEngine.Engine
{
    public interface IBaseGame
    {
        void OnLoad();
        void Unload();
        void Update();
        void Draw();
        abstract void GetKeyDown(KeyEventArgs e);
        abstract void GetKeyUp(KeyEventArgs e);
    }
}
