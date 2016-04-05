using System;
using System.Collections.Generic;
using LetsCreatePokemon.World;
using LetsCreatePokemon.World.Components.Tiles;

namespace LetsCreatePokemon.Services.World
{
    internal class TileTestLoader : ITileLoader
    {
        private readonly Random rnd;

        public TileTestLoader()
        {
            rnd = new Random();
        }

        public IList<WorldObject> LoadTiles(string mapName)
        {
            var list = new List<WorldObject>();
            list.AddRange(GenerateGrass());
            list.AddRange(GenerateBushes());
            return list;
        }

        private IEnumerable<WorldObject> GenerateGrass()
        {
            var list = new List<WorldObject>();
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    var worldObject = new WorldObject($"tile_0_{x}_{y}");
                    worldObject.AddComponent(new TileGraphic(worldObject, x, y)
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
                        ZTilePosition = 0
                    });
                    list.Add(worldObject);
                }
            }
            return list;
        }

        private IEnumerable<WorldObject> GenerateBushes()
        {
            var list = new List<WorldObject>();
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    var chance = rnd.Next(0, 100);
                    if (chance < 80 || (x == 8 && y == 8))
                        continue;
                    var collisionObject = new WorldObject($"tile_collision_{x}_{y}");
                    collisionObject.AddComponent(new TileCollision(collisionObject, x, y));
                    list.Add(collisionObject);
                    var type = rnd.Next(0, 3);
                    var worldObject = new WorldObject($"tile_1_{x}_{y}");
                    if (type == 0)
                    {
                        worldObject.AddComponent(new TileGraphic(worldObject, x, y)
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
                            ZTilePosition = 0
                        });
                    }
                    if (type == 1)
                    {
                        worldObject.AddComponent(new TileGraphic(worldObject, x, y)
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
                            ZTilePosition = 0
                        });
                    }
                    if (type == 2)
                    {
                        worldObject.AddComponent(new TileGraphic(worldObject, x, y)
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
                            ZTilePosition = 0
                        });
                    }
                    list.Add(worldObject);
                }
            }
            return list;
        }
    }
}