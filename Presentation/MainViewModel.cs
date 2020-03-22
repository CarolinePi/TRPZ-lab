using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Presentation
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Frame> Frames { get; private set; }

        private Order _currentOrder;

        private IFrameInteractor frameInteractor;
        private IOrderInteractor orderInteracto;

        public MainViewModel(IFrameInteractor frameInteractor, IOrderInteractor orderInteracto)
        {
            this.Frames = frameInteractor.GetAllFrames();
            this._currentOrder = new Order();
            //CurrentFrames = new ObservableCollection<Frame>(orderService.GetGoods(_currentOrder));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
