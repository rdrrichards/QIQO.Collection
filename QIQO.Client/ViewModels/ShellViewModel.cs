using Prism.Events;
using Prism.Mvvm;
using QIQO.Client.Controls;
using QIQO.Client.Services;
using System.Collections.ObjectModel;
using System;

namespace QIQO.Client.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private readonly ILRPClient _lrpClient;
        private readonly IEventAggregator _eventAggregator;
        private string _number;
        private ObservableCollection<BaseTile> _tiles = new ObservableCollection<BaseTile>();

        public ShellViewModel(ILRPClient lrpClient, IEventAggregator eventAggregator)
        {
            _lrpClient = lrpClient;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<NumberUpdatedEvent>().Subscribe(DoSomething, ThreadOption.UIThread); // (val) => Number = val);
        }

        private void DoSomething(string val)
        {
            Number = val;
            Tiles.Add(new BaseTile { TileLabel = $"Tile: {val}", TileValue = val });
            RaisePropertyChanged(nameof(Tiles));
        }

        public string ViewTitle => "Main Window";
        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }
        public ObservableCollection<BaseTile> Tiles
        {
            get { return _tiles; }
            set { SetProperty(ref _tiles, value); }
        }
    }
}
