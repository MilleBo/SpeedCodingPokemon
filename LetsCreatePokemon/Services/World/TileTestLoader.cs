using System;
using System.Collections.Generic;
using LetsCreatePokemon.World.Tiles;

namespace LetsCreatePokemon.Services.World
{
    internal class TileTestLoader : ITileLoader
    {
        private readonly Random rnd;

        public TileTestLoader()
        {
            rnd = new Random();
        }

        public IList<TileGraphic> LoadGraphicTiles(string mapName)
        {
            var list = new List<TileGraphic>();
            list.AddRange(GenerateGrass());
            list.AddRange(GenerateBushes());
            return list;
        }

        private IEnumerable<TileGraphic> GenerateGrass()
        {
            var list = new List<TileGraphic>();
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    list.Add(new TileGraphic
                    {
                        AnimationSpeed = 1000,
                        TextureName = "Tiles/main_tile",
                        TileFrames = new List<TileFrame>
                        {
                            new TileFrame
                            {
                                TextureXPosition = 16*rnd.Next(0, 5),
                                TextureYPosition = 0
                            }
                        },
                        XTilePosition = x,
                        YTilePosition = y,
                        ZTilePosition = 0
                    });
                }
            }
            return list;
        }

        private IEnumerable<TileGraphic> GenerateBushes()
        {
            var list = new List<TileGraphic>();
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    var chance = rnd.Next(0, 100);
                    if (chance < 80)
                        continue;
                    var type = rnd.Next(0, 3);
                    if (type == 0)
                    {
                        list.Add(new TileGraphic
                        {
                            AnimationSpeed = 200,
                            TextureName = "Tiles/main_tile",
                            TileFrames = new List<TileFrame>
                        {
                            new TileFrame
                            {
                                TextureXPosition = 0,
                                TextureYPosition = 16
                            },
                            new TileFrame
                            {
                                TextureXPosition = 16,
                                TextureYPosition = 16
                            },
                            new TileFrame
                            {
                                TextureXPosition = 32,
                                TextureYPosition = 16
                            },
                            new TileFrame
                            {
                                TextureXPosition = 48,
                                TextureYPosition = 16
                            }

                        },
                            XTilePosition = x,
                            YTilePosition = y,
                            ZTilePosition = 0
                        });
                    }
                    if (type == 1)
                    {
                        list.Add(new TileGraphic
                        {
                            AnimationSpeed = 1000,
                            TextureName = "Tiles/main_tile",
                            TileFrames = new List<TileFrame>
                        {
                            new TileFrame
                            {
                                TextureXPosition = 0,
                                TextureYPosition = 32
                            }
                        },
                            XTilePosition = x,
                            YTilePosition = y,
                            ZTilePosition = 0
                        });
                    }
                    if (type == 2)
                    {
                        list.Add(new TileGraphic
                        {
                            AnimationSpeed = 1000,
                            TextureName = "Tiles/main_tile",
                            TileFrames = new List<TileFrame>
                        {
                            new TileFrame
                            {
                                TextureXPosition = 16,
                                TextureYPosition = 32
                            }
                        },
                            XTilePosition = x,
                            YTilePosition = y,
                            ZTilePosition = 0
                        });
                    }
                }
            }
            return list;
        }
    }
}