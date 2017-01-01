﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace GoogleMaps.Bindings.ViewModels
{
    public class PolylinesPageViewModel : ViewModelBase
    {
        public ObservableCollection<Polyline> Polylines { get; set; }
        public Command<MapClickedEventArgs> MapClickedCommand => new Command<MapClickedEventArgs>(
            args =>
            {
                var position = args.Point;
                var polyline = new Polyline();
                polyline.Positions.Add(position);
                polyline.Positions.Add(new Position(position.Latitude - 0.02d, position.Longitude - 0.01d));
                polyline.Positions.Add(new Position(position.Latitude - 0.02d, position.Longitude + 0.01d));
                polyline.Positions.Add(position);

                polyline.IsClickable = true;
                polyline.StrokeColor = Color.Blue;
                polyline.StrokeWidth = 5f;
                polyline.Tag = "POLYLINE"; // Can set any object
                Polylines.Add(polyline);
            });
    }
}
