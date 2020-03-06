using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DPINT_Wk1_Strategies
{
    public class ValueConverterViewModel : ViewModelBase
    {
        private string _fromText;

        private INumberConverter _fromConverter;
        private INumberConverter _toConverter;
        private ConverterFactory _converterFactory;

        public string FromText
        {
            get { return _fromText; }
            set
            {
                _fromText = value;
                RaisePropertyChanged("FromText");
            }
        }

        private string _toText;
        public string ToText
        {
            get { return _toText; }
            set
            {
                _toText = value;
                RaisePropertyChanged("ToText");
            }
        }

        private string _fromConverterName;
        public string FromConverterName
        {
            get { return _fromConverterName; }
            set
            {
                _fromConverterName = value;
                _fromConverter = _converterFactory.getConverter(_fromConverterName);
                RaisePropertyChanged("FromConverterName");
            }
        }

        private string _toConverterName;
        public string ToConverterName
        {
            get { return _toConverterName; }
            set
            {
                _toConverterName = value;
                _toConverter = _converterFactory.getConverter(_toConverterName);
                RaisePropertyChanged("ToConverterName");
                this.ConvertNumbers();
            }
        }

        public ObservableCollection<string> ConverterNames { get; set; }
        public ICommand ConvertCommand { get; set; }

        public ValueConverterViewModel()
        {
            _converterFactory = new ConverterFactory();
            ConverterNames = new ObservableCollection<string>(_converterFactory.ConverterNames);

            FromText = "0";
            ToText = "0";
            FromConverterName = "Numerical";
            ToConverterName = "Numerical";

            ConvertCommand = new RelayCommand(ConvertNumbers);
        }

        private void ConvertNumbers()
        {
            int number = _fromConverter.ToNumerical(FromText);
            ToText = _toConverter.ToLocalString(number);
        }
    }
}
