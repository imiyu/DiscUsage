﻿using System;
using System.Linq;
using DiscUsage.Model;
using DiscUsage.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestDiscSpaceRectangle
    {
        private string testDir = @"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples";

        [TestMethod]
        public void TestMethodLoadAndParents()
        {
            var discCache = new DiscCache();
            var discSpace = new DiscSpaceManager();
            discCache.Created += discSpace.Added;
            discCache.Load(testDir);

            var discSpaceCanvasViewModel = new DiscSpaceCanvasViewModel();
            discSpaceCanvasViewModel.Add(discSpace.OrderedByLevel);
            foreach(var rectangle in discSpaceCanvasViewModel.DiscSpaceRectangles)
            {
                Assert.AreEqual(rectangle.Parent, discSpaceCanvasViewModel.Map(rectangle.space.Parent));
            }
            Assert.IsNotNull(discSpaceCanvasViewModel.Root);

            Assert.AreEqual(discSpaceCanvasViewModel.DiscSpaceRectangles.Where(x => x.Parent == discSpaceCanvasViewModel.Root).Count(), 3);

            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[0].Height, 300);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[1].Height, 300);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[2].Height, 300);

            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[0].X, 0);
            Assert.AreNotEqual(discSpaceCanvasViewModel.Root.Children[1].X, 0);
            Assert.AreNotEqual(discSpaceCanvasViewModel.Root.Children[2].X, 0);

            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[0].Y, 0);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[1].Y, 0);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[2].Y, 0);

            var first = discSpaceCanvasViewModel.Root.Children[0];
            Assert.AreEqual(first.Children.Count(), 2);
            Assert.AreEqual(first.Children[0].Width, first.Width);
            Assert.AreEqual(first.Children[1].Width, first.Width);

            Assert.AreEqual(first.Children[0].X, first.X);
            Assert.AreEqual(first.Children[1].X, first.X);

            Assert.AreEqual(first.Children[0].Y, first.Y);
            Assert.AreNotEqual(first.Children[1].Y, first.Y);

            var second = discSpaceCanvasViewModel.Root.Children[1];
            Assert.AreEqual(second.Children.Count(), 2);
            Assert.AreEqual(second.Children[0].Width, second.Width);
            Assert.AreEqual(second.Children[1].Width, second.Width);

            Assert.AreEqual(second.Children[0].Parent, second);
            Assert.AreEqual(second.Children[1].Parent, second);

            Assert.AreEqual(second.Children[0].X, second.X);
            Assert.AreEqual(second.Children[1].X, second.X);

            Assert.AreEqual(second.Children[0].Y, second.Y);
            Assert.AreNotEqual(second.Children[1].Y, second.Y);
        }
    }
}
