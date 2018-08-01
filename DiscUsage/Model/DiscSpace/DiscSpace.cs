﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.Model
{
    public class DiscSpace : BindableBase
    {

        public DiscSpaceManager Manager { get; private set; }
        public DiscSpace(DiscSpaceManager manager, DiscSpace parent, string name, string fullname)
        {
            this.Parent = parent;
            Name = name;
            FullName = fullname;
            //Level = level;
            Manager = manager;
            Children = new List<DiscSpace>();
        }

        public DiscSpace Parent { get; internal set; }
        public List<DiscSpace> Children { get; internal set; }
        public string Name { get; private set; }
        public string FullName { get; set; }

        /// <summary>
        /// Length of all files and directories which are not part of the children space, 
        /// but belong into this disc space.
        /// </summary>
        public Int64 OwnLength { get; internal set; }

        /// <summary>
        /// Length of this disc space, which is the sum of length of all files in all sub directories.
        /// </summary>
        public Int64 Length => OwnLength + OrderedChildren.Sum(x => x.Length);
        public Int64 LengthOfAllPreviousChildren { get; set; }

        public Int64 ParentLength => Parent.Length;
        public int Count { get; internal set; }

        List<DiscSpace> Flatten(List<DiscSpace> e)
        {
            return e.Concat( e.SelectMany(c => Flatten(c.Children))).ToList();
        }

        public List<DiscSpace> ChildrenRecursive => Flatten(Children).Where(x=>x.Length>= Manager.MinimalLimit).ToList();

        public List<DiscSpace> OrderedChildren => Children.OrderByDescending( x=> x.Length).Where(x=>x.Length>= Manager.MinimalLimit).ToList();

        public int Level => (Parent == null) ? 0 : Parent.Level + 1;
        public int IndexInParentOrderedCollection => (Parent == null) ? 0 : Parent.OrderedChildren.IndexOf(this);
        
    }
}
