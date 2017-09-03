using System;
using DungeonGeneration.Generators;

namespace DungeonGeneration
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var gen = new CellularAutomataGenerator();

            while (true) {
                string[] input = Console.ReadLine().Split(' ');

                int[] values = {
                    100, // Width
                    100, // Height
                    45, // Alive
                    5, // Birth
                    4, // Survival
                    5 // Iterations
                };

                int[] otherGoodConfig = {
                    100,
                    100,
                    30,
                    6,
                    5,
                    5
                };
                
                for (int i = 0; i < input.Length && i < values.Length; i++) {
                    int prevVal = values[i];
                    if (!Int32.TryParse(input[i], out values[i])) {
                        values[i] = prevVal;
                    }
                }

                gen.Generate(values[0], values[1], values[2], values[3], values[4], values[5]).SaveToImageFile();
            }
        }
    }
}
