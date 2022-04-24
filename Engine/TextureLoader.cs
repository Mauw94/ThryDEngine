namespace ThryDEngine.Engine
{
    public class TextureLoader
    {
        public static Bitmap Load(string directory, int width, int height, string extension = "png")
        {
            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.{extension}");
            return new Bitmap(tmp, width, height);
        }
    }
}
