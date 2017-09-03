using DungeonGeneration.Models;
using System;
using System.Collections.Generic;

namespace DungeonGeneration.Generators
{
    public class CellularAutomataGenerator
    {
        private Random _rng = new Random();

        private int AliveProbability;
        private int BirthThreshold;
        private int SurvivalThreshold;

        public Map Generate(int width, int height, int aliveProbability = 45,
            int birthThreshold = 5, int survivalThreshold = 4, int numIterations = 5)
        {
            var map = new Map(width, height);
            this.AliveProbability = aliveProbability % 100;
            this.BirthThreshold = birthThreshold;
            this.SurvivalThreshold = survivalThreshold;

            // Fill it.
            this.Fill(ref map);

            for (int i = 0; i < numIterations; i++) {
                this.RunIteration(ref map);
            }

            return map;
        }

        private void Fill(ref Map map)
        {
            for (int x = 0; x < map.width; x++) {
                for (int y = 0; y < map.height; y++) {
                    map.Tiles[x, y] = (this._rng.Next() % 100 < this.AliveProbability) ? TileType.Dead : TileType.Alive;
                }
            }
        }

        private void RunIteration(ref Map map)
        {
            var originalMap = (Map)map.Clone();

            for (int x = 0; x < originalMap.width; x++) {
                for (int y = 0; y < originalMap.height; y++) {

                    int numNeighbors = originalMap.GetNumNeighbors(x, y);

                    if (map.Tiles[x, y] == TileType.Dead && numNeighbors >= this.BirthThreshold) {
                        map.Tiles[x, y] = TileType.Alive;
                    } else {
                        if (numNeighbors < this.SurvivalThreshold) {
                            map.Tiles[x, y] = TileType.Dead;
                        }
                    }
                }
            }
        }

        private void MakeStronglyConnected(ref Map map)
        {
            var disconnectedMaps = new List<Map>();

            //
            while (true) {
                for (int x = 0; x < map.width; x++) {
                    for (int y = 0; y < map.height; y++) {

                    }
                }
            }

        }

        private void FindEntireConnectedSystem(ref Map map, int x, int y)
        {
            if (x < 0 || x >= map.width || y > 0 || y >= map.height || map.Tiles[x, y] == TileType.Dead) {
                return;
            }
        }
    }

    public static class CellularAutomataExtensions
    {
        public static int GetNumNeighbors(this Map map, int xPos, int yPos)
        {
            // -1 to account for our own tile.
            int numNeighbors = -1;

            for (int x = -1; x < 2; x++) {
                for (int y = -1; y < 2; y++) {
                    int newX = xPos + x;
                    int newY = yPos + y;

                    if (newX < 0 || newX >= map.width || newY < 0 || newY >= map.height) {
                        continue;
                    }

                    if (map.Tiles[newX, newY] == TileType.Alive) {
                        numNeighbors += 1;
                    }
                }
            }

            return numNeighbors;
        }
    }
}
