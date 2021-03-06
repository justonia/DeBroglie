﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeBroglie.Test
{
    [TestFixture]
    public class TileRotationTest
    {
        [Test]
        public void TestTileRotationBuilderContradiction1()
        {
            var builder = new TileRotationBuilder();

            builder.Add(new Tile(1), 0, true, new Tile(2));
            Assert.Throws<Exception>(() => builder.Add(new Tile(1), 0, true, new Tile(3)));
        }

        [Test]
        public void TestTileRotationBuilderContradiction2()
        {
            var builder = new TileRotationBuilder();

            builder.Add(new Tile(1), 0, true, new Tile(2));
            Assert.Throws<Exception>(() => builder.Add(new Tile(2), 0, true, new Tile(3)));
        }

        [Test]
        public void TestTileRotationBuilderCompounding()
        {
            var builder = new TileRotationBuilder();

            builder.Add(new Tile(1), 0, true, new Tile(2));
            builder.Add(new Tile(2), 1, false, new Tile(2));

            var rotation = builder.Build();
            var b1 = rotation.Rotate(new Tile(1), 1, false, out var r1);
            Assert.IsTrue(b1);
            Assert.AreEqual(new Tile(1), r1);
        }
    }
}
