using Domain;
using Domain.Exceptions;
using Domain.Validators;
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
        private Command _removeFrame;
        private IList<Material> currentMaterials;
        private IList<OrderItem> currentOrderItems;
        private Command _newOrder;
        private string exception;
        private OrderItem _selectedOrderItem;

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel(IFrameInteractor frameInteractor, IOrderInteractor orderInteractor)
        {
            Frames = frameInteractor.GetAllFrames();
            OrderInteractor = orderInteractor;
            _currentOrder = new Order();
        }

        public string ExceptionField
        {
            get => exception;
            set
            {
                exception = value;
                OnPropertyChanged("ExceptionField");
            }
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
        public OrderItem SelectedOrderItem
        {
            get => _selectedOrderItem;
            set
            {
                _selectedOrderItem = value;
                OnPropertyChanged("SelectedOrderItem");
            }
        }

        public IList<OrderItem> CurrentOrderItems
        {
            get => currentOrderItems;
            set
            {
                currentOrderItems = value;
                OnPropertyChanged("CurrentOrderItems");
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
                    try
                    {
                        FrameValidator.AssertFrameIsValid(SelectedFrame);
                        FieldValidator.AssertFieldIsValid(Quantity);
                        FieldValidator.AssertFieldIsValid(Width);
                        FieldValidator.AssertFieldIsValid(Height);
                        OrderInteractor.AddOrderItem(_currentOrder, SelectedFrame, Quantity, Width, Height);
                        CurrentMaterials = OrderInteractor.CountOrderMaterials(_currentOrder);
                        CurrentOrderItems = OrderInteractor.GetOrderItems(_currentOrder);
                    }
                    catch (ValidatorException e)
                    {
                        ExceptionField = e.Message;
                    }
                });
            }
        }

        public Command RemoveFrame
        {
            get
            {
                return _removeFrame ??= new Command(obj =>
                {
                    try
                    {
                        OrderItemValidator.AssertOrderItemsIsValid(currentOrderItems);
                        OrderItemValidator.AssertOrderItemIsValid(SelectedOrderItem);
                        OrderInteractor.DeleteOrderItem(_currentOrder, SelectedOrderItem);
                        CurrentMaterials = OrderInteractor.CountOrderMaterials(_currentOrder);
                        CurrentOrderItems = OrderInteractor.GetOrderItems(_currentOrder);
                    }
                    catch (ValidatorException e)
                    {
                        ExceptionField = e.Message;
                    }

                });
            }
        }
        public Command NewOrder
        {
            get
            {
                return _newOrder ??= new Command(obj =>
                {
                    _currentOrder = new Order();
                    CurrentMaterials = OrderInteractor.CountOrderMaterials(_currentOrder);
                    CurrentOrderItems = OrderInteractor.GetOrderItems(_currentOrder);
                });
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

}
