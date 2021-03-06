﻿using System;
using System.Collections.Generic;
using System.Linq;
using DiscUsage.Model;
using DiscUsage.ViewModels;
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
            var discSpaceCanvasViewModel = new DiscSpaceCanvasViewModel();

            discCache.Created += discSpaceCanvasViewModel.Manager.Create;
            discCache.Loaded += discSpaceCanvasViewModel.Manager.Load;

            discSpaceCanvasViewModel.Manager.Loaded += discSpaceCanvasViewModel.Loaded;
            discSpaceCanvasViewModel.Manager.Created += discSpaceCanvasViewModel.Create;
            discSpaceCanvasViewModel.Manager.Created += Manager_Created;

            discCache.LoadAsync(testDir).Wait();

            foreach (var rectangle in discSpaceCanvasViewModel.VisibleRectangles)
            {
                Assert.IsNotNull(rectangle.ManagerRectangle);
            }

            Assert.IsNotNull(discSpaceCanvasViewModel.VisibleRoot);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.Height, 600 );
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRectangles.Count, 31);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRectangles.Where(x => x.Parent == discSpaceCanvasViewModel.VisibleRoot).Count(), 3);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle.Count, 3);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[0].Height, 600 - 6);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[1].Height, 600 - 6);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[2].Height, 600 - 6);

            //Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.Children[2].Width + discSpaceCanvasViewModel.VisibleRoot.Children[2].X, 600 - 6);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[0].X, 3);
            Assert.AreNotEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[1].X, 3);
            Assert.AreNotEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[2].X, 3);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[0].Y, 3);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[1].Y, 3);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[2].Y, 3);

            var first = discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[0];
            Assert.AreEqual(first.Children.Count(), 2);
            Assert.AreEqual(first.ChildrenRectangle[0].Width, first.Width-6);
            Assert.AreEqual(first.ChildrenRectangle[1].Width, first.Width-6);

            Assert.AreEqual(first.ChildrenRectangle[0].X, first.X+3);
            Assert.AreEqual(first.ChildrenRectangle[1].X, first.X+3);

            Assert.AreEqual(first.ChildrenRectangle[0].Y, first.Y+3);
            Assert.AreNotEqual(first.ChildrenRectangle[1].Y, first.Y+3);

            var second = discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[1];
            Assert.AreEqual(second.Children.Count(), 2);
            Assert.AreEqual(second.ChildrenRectangle[0].Width, second.Width-6);
            Assert.AreEqual(second.ChildrenRectangle[1].Width, second.Width-6);

            Assert.AreEqual(second.ChildrenRectangle[0].Parent, second);
            Assert.AreEqual(second.ChildrenRectangle[1].Parent, second);

            Assert.AreEqual(second.ChildrenRectangle[0].X, second.X+3);
            Assert.AreEqual(second.ChildrenRectangle[1].X, second.X+3);

            Assert.AreEqual(second.ChildrenRectangle[0].Y, second.Y+3);
            Assert.AreNotEqual(second.ChildrenRectangle[1].Y, second.Y+3);

            Assert.AreEqual(CreatedEvents.Where(x=>x.Height>=6&&x.Width>=6).Count(), discSpaceCanvasViewModel.VisibleRectangles.Count);
        }

        private List<DiscSpaceRectangle> CreatedEvents = new List<DiscSpaceRectangle>();

        private void Manager_Created(DiscSpace space)
        {
            CreatedEvents.Add((DiscSpaceRectangle)space);
        }

        [TestMethod]
        public void TestOtherVisibleRoot()
        {
            var discCache = new DiscCache();
            var discSpaceCanvasViewModel = new DiscSpaceCanvasViewModel();

            discCache.Created += discSpaceCanvasViewModel.Manager.Create;
            discCache.Loaded += discSpaceCanvasViewModel.Manager.Load;

            discSpaceCanvasViewModel.Manager.Loaded += discSpaceCanvasViewModel.Loaded;
            discSpaceCanvasViewModel.Manager.Created += discSpaceCanvasViewModel.Create;
            discSpaceCanvasViewModel.Manager.Created += Manager_Created;

            discCache.LoadAsync(testDir).Wait();

            foreach (var rectangle in discSpaceCanvasViewModel.VisibleRectangles)
            {
                Assert.IsNotNull(rectangle.ManagerRectangle);
            }

            Assert.IsNotNull(discSpaceCanvasViewModel.VisibleRoot);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRectangles.Count, 31);

            discSpaceCanvasViewModel.VisibleRoot = (DiscSpaceRectangle)discSpaceCanvasViewModel.VisibleRoot.Children[0];

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRectangles.Count, 16);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.Height, 600);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle.Count, 2);
            
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[0].Height, 600 - 6);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[1].Height, 600 - 6);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[0].X, 3);
            Assert.AreNotEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[1].X, 3);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[0].Y, 3);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[1].Y, 3);

        }

        [TestMethod]
        public void TestMethodBetterLayoutAlgo()
        {
            var discCache = new DiscCache();
            var discSpaceCanvasViewModel = new DiscSpaceCanvasViewModel();

            discCache.Created += discSpaceCanvasViewModel.Manager.Create;
            discCache.Loaded += discSpaceCanvasViewModel.Manager.Load;

            discSpaceCanvasViewModel.Manager.Loaded += discSpaceCanvasViewModel.Loaded;
            discSpaceCanvasViewModel.Manager.Created += discSpaceCanvasViewModel.Create;
            discSpaceCanvasViewModel.Manager.Created += Manager_Created;
            discSpaceCanvasViewModel.UseAdvancedAlgoForLayout = true;

            discCache.LoadAsync(testDir).Wait();

            foreach (var rectangle in discSpaceCanvasViewModel.VisibleRectangles)
            {
                Assert.IsNotNull(rectangle.ManagerRectangle);
            }

            Assert.IsNotNull(discSpaceCanvasViewModel.VisibleRoot);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.Height, 600 );
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRectangles.Count, 31);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRectangles.Where(x => x.Parent == discSpaceCanvasViewModel.VisibleRoot).Count(), 3);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle.Count, 3);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[0].Height, 600 - 6);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[1].Height, 600 - 6);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[2].Height, 600 - 6);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[0].ChildrenRectangle.Count, 2);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.ChildrenRectangle[1].ChildrenRectangle.Count, 2);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.GetFirstLineForAlgo().Count, 1);
            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.GetSecondLineForAlgo().Count, 1);

            Assert.AreEqual(discSpaceCanvasViewModel.VisibleRoot.GetLinesForAlgo().Count, 3);

            Assert.AreEqual(((DiscSpaceRectangle)discSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0]).GetLinesForAlgo().Count, 2);
            Assert.AreEqual(((DiscSpaceRectangle)discSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0]).GetLinesForAlgo()[0].Count, 1);
            Assert.AreEqual(((DiscSpaceRectangle)discSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0]).GetLinesForAlgo()[1].Count, 1);

            Assert.AreEqual(((DiscSpaceRectangle)discSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0].OrderedChildren[0]).GetLinesForAlgo().Count, 2);
            Assert.AreEqual(((DiscSpaceRectangle)discSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0].OrderedChildren[0]).GetLinesForAlgo()[0].Count, 1);

            Assert.AreEqual(((DiscSpaceRectangle)discSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0].OrderedChildren[0].OrderedChildren[0]).GetLinesForAlgo().Count, 3);
            Assert.AreEqual(((DiscSpaceRectangle)discSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0].OrderedChildren[0].OrderedChildren[0]).GetLinesForAlgo()[0].Count, 1);
            Assert.AreEqual(((DiscSpaceRectangle)discSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0].OrderedChildren[0].OrderedChildren[0]).GetLinesForAlgo()[1].Count, 2);
            Assert.AreEqual(((DiscSpaceRectangle)discSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0].OrderedChildren[0].OrderedChildren[0]).GetLinesForAlgo()[2].Count, 1);
        }
    }
}
