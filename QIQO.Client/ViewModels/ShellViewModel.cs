using Prism.Events;
using Prism.Mvvm;
using QIQO.Client.Services;

namespace QIQO.Client.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private readonly ILRPClient _lrpClient;
        private readonly IEventAggregator _eventAggregator;
        private string _number;

        public ShellViewModel(ILRPClient lrpClient, IEventAggregator eventAggregator)
        {
            _lrpClient = lrpClient;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<NumberUpdatedEvent>().Subscribe((val) => Number = val);
        }
        public string ViewTitle => "Main Window";
        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }
    }
}
