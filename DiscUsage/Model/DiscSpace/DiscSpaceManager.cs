﻿using DiscUsage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DiscUsage.Model
{
    public delegate void DiscSpaceDelegate(DiscSpace space);

    public class DiscSpaceManager
    {
        public event DiscSpaceDelegate Created;
        public event DiscSpaceDelegate Updated;
        public event DiscSpaceDelegate Loaded;

        public DiscSpace Root;
        private Dictionary<InfoCache, DiscSpace> mapping = new Dictionary<InfoCache, DiscSpace>();
        public Int64 MinimalLimit = 1024 * 1024;

        //public void Create(InfoCache info)
        //{
        //   Create(info);
        //}

        private static DiscSpace CreateDiscSpace(DiscSpaceManager manager, DiscSpace parent, String name, String fullname)
        {
            return new DiscSpaceRectangle(manager, parent, name, fullname);
        }

        public void Load(InfoCache info)
        {
            var space = Map(info);
            Update(info, space);
            //UpdateAll();
            if (info is DirectoryCache)
            {
                var smallChildren = space.Children.Where(x => x.Length < MinimalLimit).ToList();
                smallChildren.ForEach(x=>mapping.Remove(MapBack(x)));
                space.OwnLength = smallChildren.Sum(x => x.Length);
                space.Children = space.Children.Where(x => x.Length >= MinimalLimit).ToList();

            }

            if (space.Length >= MinimalLimit)
            {
                Created?.Invoke(space);
                Loaded?.Invoke(space);
            }
        }

        private void Update(DiscSpace space)
        {
            Update(MapBack(space),space);
        }

        private void Update(InfoCache info, DiscSpace space)
        {
            space.Count = info.Count;
            //if (info is FileCache)
            //{
            //    space.OwnLength = info.Length;
            //}
            //else
            //{
            //    var directory = (DirectoryCache)info;
            //    space.OwnLength = directory.files.Sum(x => x.Length);
            //}
            

            //if (space.Parent != null)
            //{
            //    space.LengthOfAllPreviousChildren = space.Parent.OrderedChildren.Where(x => x.IndexInParentOrderedCollection < space.IndexInParentOrderedCollection).Sum(x => x.Length);
            //}
           
        }

        private void UpdateCurrentAndAllParents(DiscSpace current)
        {
            Update(current);
            Updated?.Invoke(current);
            if (current.Parent != null)
            {
                UpdateCurrentAndAllParents(current.Parent);
            }
        }

        private void UpdateAll()
        {
            foreach(var keyValuePair in mapping)
            {
                Update(keyValuePair.Key, keyValuePair.Value);
            }
        }

        //private DiscSpace GetAndCreateParent(InfoCache info)
        //{
        //    DiscSpace parentSpace = null;
        //    if (info.Parent != null)
        //    {
        //        parentSpace = Map(info.Parent);
        //        if (parentSpace == null)
        //        {
        //            Create(info.Parent, true);
        //            parentSpace = Map(info.Parent);
        //        }
        //        else
        //        {
        //            //UpdateCurrentAndAllParents(parentSpace);
        //        }
        //    }
        //    return parentSpace;
        //}

        /// <summary>
        /// A new cache info is added to the disc space manager. 
        /// This results in a new disc space, if a new info is given ans the info is not under the minimal limit.
        /// The manager updates all the parent disc spaces.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="forceCreation"> if this parameter is set to true, the mimimal limit is virtually set to 0.</param>
        public void Create(InfoCache info)
        {
            var parentSpace = Map(info.Parent);
            var space = CreateDiscSpace(this, parentSpace, info.Name, info.FullName);
            mapping[info] = space;
            if (info is FileCache)
            {
                space.OwnLength = info.Length;
            }

            //var parentSpace = GetAndCreateParent(info);
            //if (info.Length < MinimalLimit && )
            //{
            //    parentSpace.OwnLength += info.Length;
            //    return;
            //}

            //if (Map(info) != null)
            //{
            //    UpdateAll();
            //    return;
            //}

            //var space = new DiscSpace(this,parentSpace,info.Name, info.FullName);

            //mapping[info] = space;
            //Update(info,space);
            //if (parentSpace != null)
            //{
            //    parentSpace.Children.Add(space);
            //}
            if (info.Parent == null)
            {
                Root = space;
            }
            //if (info.Length > MinimalLimit)
            //{
            //    //UpdateAll();
            //    Created?.Invoke(space);
            //}

        }

        public Dictionary<InfoCache, DiscSpace> Mapping => mapping;
        public DiscSpace Map(InfoCache info)
        {
            if (info == null||!mapping.ContainsKey(info))
            {
                return null;
            }
            return mapping[info];
        }

        public InfoCache MapBack(DiscSpace space)
        {
            if (!mapping.ContainsValue(space))
            {
                return null;
            }
            return mapping.FirstOrDefault(x => x.Value == space).Key;
        }

        public List<DiscSpace> OrderedByLevel
        {
            get
            {
                var orderedByLevel = Root.ChildrenRecursive.ToList();
                orderedByLevel.Add(Root);
                orderedByLevel = orderedByLevel.OrderBy(x => x.Level).ToList();
                return orderedByLevel;
            }
        }
    }
}
