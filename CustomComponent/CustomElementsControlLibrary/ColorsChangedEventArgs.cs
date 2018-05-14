using System;
using System.Collections.Generic;
using System.Drawing;

namespace CustomElementsControlLibrary
{
    public class ColorsChangedEventArgs : EventArgs
    {
        private readonly List<Color> _oldColors;
        private readonly List<Color> _newColors;

        public ColorsChangedEventArgs(List<Color> oldClrs, List<Color> newClrs)
        {
            _oldColors = oldClrs;
            _newColors = newClrs;
        }

        public List<Color> OldColors
        {
            get => _oldColors;
        }

        public List<Color> NewColors
        {
            get => _newColors;
        }
    }
}