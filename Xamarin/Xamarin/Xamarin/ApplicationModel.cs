using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using static CommonDivisorLibrary.CommonMultiple;
using static CommonDivisorLibrary.LongestWordFinder;

namespace Xamarin
{
    public class ApplicationModel : INotifyPropertyChanged
    {

        private int? _number;

        private string _text = "";

        string Text
        {
            get => _text;
            set
            {
                _text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }

        string Number
        {
          set
            {
                if (int.TryParse(value, out int n))
                {
                    _number = n;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }

          get
            {
                return _number.ToString() ?? "";
            }
            
        }

        string Result
        {
            get
            {
                return _number.HasValue 
                    ? FindLeastCommonMultiple(_number.Value, FindLongestWord(Text).Length).ToString() 
                    : "";
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
