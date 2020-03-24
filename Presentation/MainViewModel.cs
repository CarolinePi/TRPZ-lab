using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Presentation
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Frame> Frames { get; private set; }
        public IOrderInteractor OrderInteractor { get; }

        public int Quantity { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        private Order _currentOrder;
        private Frame _selectedFrame;
        private Command _addFrame;
        private IList<Material> currentMaterials;
        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel(IFrameInteractor frameInteractor, IOrderInteractor orderInteractor)
        {
            Frames = frameInteractor.GetAllFrames();
            OrderInteractor = orderInteractor;
            _currentOrder = new Order();
        }

        public Frame SelectedFrame
        {
            get => _selectedFrame;
            set
            {
                _selectedFrame = value;
                OnPropertyChanged("SelectedFrame");
            }
        }

        public IList<Material> CurrentMaterials
        {
            get => currentMaterials;
            set
            {
                currentMaterials = value;
                OnPropertyChanged("CurrentMaterials");
            }
        }

        public Command AddFrame
        {
            get
            {
                return _addFrame ??= new Command(obj =>
                {
                    OrderInteractor.AddOrderItem(_currentOrder, SelectedFrame, Quantity, Width, Height);
                    CurrentMaterials = OrderInteractor.CountOrderMaterials(_currentOrder);
                });
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

}
