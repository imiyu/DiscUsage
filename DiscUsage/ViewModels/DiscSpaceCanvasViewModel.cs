﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscUsage.Model;
using System.Windows.Media;
using System.ComponentModel;
using Prism.Mvvm;
using System.Diagnostics;
using System.Timers;

namespace DiscUsage.ViewModels
{
    public class DiscSpaceCanvasViewModel : DiscSpaceViewModel
    {

        public DiscSpaceCanvasViewModel()
        {
        }

        private double _Width = 600;
        public double Width
        {
            get { return _Width; }
            set { SetProperty(ref _Width, value); }
        }

        private double _Height=600;
        public double Height
        {
            get { return _Height; }
            set { SetProperty(ref _Height, value); }
        }

        private ObservableCollection<DiscSpaceRectangle> _DiscSpaceRectangles=new ObservableCollection<DiscSpaceRectangle>();
        public ObservableCollection<DiscSpaceRectangle> DiscSpaceRectangles
        {
            get { return _DiscSpaceRectangles; }
            set { SetProperty(ref _DiscSpaceRectangles,value); }
        }
        public ObservableCollection<DiscSpaceRectangle> DiscSpaceRectanglesInternal = new ObservableCollection<DiscSpaceRectangle>();

        public DiscSpaceRectangle Root => (DiscSpaceRectangle)Manager.Root;

        private DiscSpaceRectangle _FocusedRectangle;
        public DiscSpaceRectangle FocusedRectangle
        {
            get { return _FocusedRectangle; }
            set { SetProperty(ref _FocusedRectangle, value); }
        }
        private System.Threading.SynchronizationContext _uiContext;
        public void Create(DiscSpace space)
        {
            base.Create(space);
            if (_uiContext == null)
            {
                _uiContext = System.Threading.SynchronizationContext.Current;
            }

            var rectangle = (DiscSpaceRectangle)space;
            rectangle.ManagerRectangle = this;
            DiscSpaceRectanglesInternal.Add(rectangle);
            Debug.Assert(rectangle.ManagerRectangle!=null);
            //RaiseAllEvents();
        }

        public void Loaded(DiscSpace space)
        {
            base.Loaded(space);
            if (space == Root)
            {
                int i = 0;
                IsTimerEnabled = false;
            }
            else
            {
                IsTimerEnabled = true;
            }
        }

        public void RaiseAllEvents()
        {
            //DiscSpaceRectangles.Clear();
            foreach (var rectangle in DiscSpaceRectanglesInternal)
            {
                rectangle.ReCalcProperties(this);

            }
            var bigRectangles = DiscSpaceRectanglesInternal.Where(x => x.Width >= 6 && x.Height >= 6).ToList();

            // add
            var notInRectangles=bigRectangles.Where(x => !DiscSpaceRectangles.Contains(x)).ToList();
            notInRectangles.ForEach(x => DiscSpaceRectangles.Add(x));

            //remove
            var notInBigRectangles = DiscSpaceRectangles.Where(x => !bigRectangles.Contains(x)).ToList();
            notInBigRectangles.ForEach(x => DiscSpaceRectangles.Remove(x));

            foreach (var rectangle in DiscSpaceRectangles)
            {
                rectangle.IsCurrentlyLoading = !rectangle.IsLoaded && rectangle.Children.Where(x => !x.IsLoaded && DiscSpaceRectangles.Contains(x)).Count() == 0;
                if (rectangle.IsCurrentlyLoading)
                {
                    var i = 0;
                }
                rectangle.RaisePropertiesChanged(this);
            }
            var loading = DiscSpaceRectangles.Where(x => x.IsCurrentlyLoading).ToList();
            //Debug.Assert(loading.Count== 1);
            if (loading.Count>1)
            {
                var i = 0;
            }
        }

        private Timer _Timer;

        public bool IsTimerEnabled
        {
            get
            {
                return _Timer != null;
            }
            set
            {
                if (value)
                {
                    if (_Timer == null)
                    {
                        _Timer = new Timer(1000);
                        _Timer.Elapsed += _Timer_Elapsed;
                        _Timer.Start();
                    }
                }
                else
                {
                    if (_Timer != null)
                    {
                        _Timer.Stop();
                        _Timer = null;
                        _Timer_Elapsed(null, null);
                    }
                }
            }
        }
        /// <summary>
        /// hack to avoid multiple timer waiting for update
        /// </summary>
        private bool timerHackRunning = false;

        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (timerHackRunning)
            {
                return;
            }
            timerHackRunning = true;
            if (_uiContext != null)
            {
                _uiContext.Send(x => RaiseAllEvents(), null);
            }
            else
            {
                RaiseAllEvents();
            }
            
            timerHackRunning = false;
            
        }
    }
}
