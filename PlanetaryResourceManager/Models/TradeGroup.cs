﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryResourceManager.Models
{
    class TradeGroup : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public List<TradeItem> Items { get; set; }
        public double ProfitMargin
        {
            get
            {
                if (Items.Count > 0)
                {
                    return Items.Max(arg => arg.ProfitMargin);
                }

                return 0.0;
            }
        }

        internal void Update(double securityLevel)
        {
            Items.ForEach(arg => arg.Update(securityLevel));
            Items = Items.OrderByDescending(arg => arg.ProfitMargin).ToList();
            RaisePropertyChanged("ProfitMargin");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}