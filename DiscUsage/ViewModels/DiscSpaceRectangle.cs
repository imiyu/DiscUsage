﻿using DiscUsage.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DiscUsage.ViewModels
{
    public class DiscSpaceRectangle : DiscSpace
    {
        private List<Brush> brushes = new List<Brush> { Brushes.Gray, Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Orange, Brushes.LightBlue, Brushes.Yellow, Brushes.LightGray };

        private double CanvasWidth => ManagerRectangle.Height;
        private double CanvasHeight => ManagerRectangle.Height;
        private double Margin = 6;
        private double _strokeWidth = 1;
        private double _CornerRadius=8;

        public DiscSpaceRectangle ParentRectangle => (DiscSpaceRectangle)Parent;
        public List<DiscSpaceRectangle> ChildrenRectangle => OrderedChildren.ConvertAll(x => (DiscSpaceRectangle)x);
        public DiscSpaceCanvasViewModel ManagerRectangle { get; set; }

        public DiscSpaceRectangle(DiscSpaceManager manager, DiscSpace parent,  String name, String fullname) : base(manager,parent,name,fullname)
        {
          //  ManagerRectangle = model;
            FocusChangedCommand = new DelegateCommand<string>(OnFocus);
        }
        public DelegateCommand<string> FocusChangedCommand { get; set; }

        public void OnFocus(string parameter)
        {
            if (parameter == "Enter")
            {
                ManagerRectangle.FocusedRectangle = this;
                RaisePropertyChanged("Opacity");
            }
            else
            {
                if (ManagerRectangle.FocusedRectangle == this)
                {
                    ManagerRectangle.FocusedRectangle = null;
                    RaisePropertyChanged("Opacity");
                }
                
            }
        }

        public void RaisePropertiesChanged()
        {
            RaisePropertyChanged("X");
            RaisePropertyChanged("Y");
            RaisePropertyChanged("Width");
            RaisePropertyChanged("Height");
            RaisePropertyChanged("Radius");
            RaisePropertyChanged("Children");
        }

        public double X => (Parent == null) ? 0 : (Level % 2 == 1) ? Position + ParentRectangle.X: ParentRectangle.X+Margin/2;
        public double Y => (Parent == null) ? 0 : (Level % 2 == 0) ? Position + ParentRectangle.Y: ParentRectangle.Y+Margin/2;

        public double Width => (Parent == null)? CanvasWidth : (Level % 2 == 1) ? Size : ParentRectangle.Width-Margin;
        public double Height => (Parent == null) ? CanvasHeight : (Level % 2 == 0) ? Size : ParentRectangle.Height-Margin;
        public double Radius => Math.Min(_CornerRadius, Math.Min(Width,Height)/2);

        public Brush FillColor => brushes[Level%brushes.Count];
        public double StrokeWidth => this._strokeWidth;
        public double Opacity => (ManagerRectangle.FocusedRectangle == this) ? 0.6 : 0.3;

        private double Size => (Parent == null) ? CanvasHeight : (double)Length / (double)Parent.Length * ParentRectangle.Size - Margin;
        private double Position => (Parent == null) ? 0 : (double)LengthOfAllPreviousChildren / (double)Parent.Length * ParentRectangle.Size+Margin/2;

    }
}
