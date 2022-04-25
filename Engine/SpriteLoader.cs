namespace ThryDEngine.Engine
{
    /// <summary>
    /// Load sprite as a new Bitmap.
    /// </summary>
    public class SpriteLoader
    {
        public static Bitmap Load(string spriteName, int width, int height, string extension = "png")
        {
            Image tmp = Image.FromFile($"Assets/Sprites/{spriteName}.{extension}");
            return new Bitmap(tmp, width, height);
        }

        public static Bitmap[] Load(List<string> spriteNames, int width, int height, string extension = "png")
        {
            Bitmap[] bitmap = new Bitmap[spriteNames.Count];

            for (int i = 0; i < spriteNames.Count; i++)
            {
                var image = Image.FromFile($"Assets/Sprites/{spriteNames[i]}.{extension}");
                bitmap[i] = new Bitmap(image, width, height);
            }
            return bitmap;
        }
    }
}
