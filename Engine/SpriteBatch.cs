namespace ThryDEngine.Engine
{
    public class SpriteBatch
    {
        public static void Draw(Image image, float x, float y, float width, float height)
        {
            Game.Graphics.DrawImage(image, x, y, width, height);
        }
    }
}
