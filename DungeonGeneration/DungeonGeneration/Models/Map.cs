using System;
using System.Drawing;
using System.IO;

namespace DungeonGeneration.Models
{
    public enum TileType
    {
        Dead,
        Alive
    }

    public class Map : ICloneable
    {
        public TileType[,] Tiles { get; set; }
        public int width { get; private set; }
        public int height { get; private set; }

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.Tiles = new TileType[width, height];
        }

        public void SaveToImageFile()
        {
            var bmp = new Bitmap(this.width, this.height);
            for (int x = 0; x < this.width; x++) {
                for (int y = 0; y < this.height; y++) {
                    bmp.SetPixel(x, y, this.Tiles[x, y] == TileType.Dead ? Color.FromArgb(25, 25, 25) : Color.White);
                }
            }

            var rng = new Random();
            string filename = string.Empty;

            do {
                filename = rng.Next() + ".png";
            } while (File.Exists(filename));
            
            bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
        }

        public object Clone()
        {
            var map = new Map(this.width, this.height);

            for (int x = 0; x < map.width; x++) {
                for (int y = 0; y < map.height; y++) {
                    map.Tiles[x, y] = this.Tiles[x, y];
                }
            }

            return map;
        }
    }
}
