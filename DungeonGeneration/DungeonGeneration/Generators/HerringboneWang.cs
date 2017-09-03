using System.Collections.Generic;
using System.Drawing;

namespace DungeonGeneration.Generators
{
    public class HerringboneWangGenerator
    {
        private Dictionary<string, HerringboneWangTile>[] _verticalTiles = new Dictionary<string, HerringboneWangTile>[2];

        public HerringboneWangGenerator()
        {
            for (int i = 0; i < this._verticalTiles.Length; i++) {
                this._verticalTiles[i] = new Dictionary<string, HerringboneWangTile>();
            }
        }
    }

    public enum HerringboneWangTileType
    {
        Horizontal,
        Vertical
    }

    public class HerringboneWangTile
    {
        private Bitmap _bitmap;

    }
}
