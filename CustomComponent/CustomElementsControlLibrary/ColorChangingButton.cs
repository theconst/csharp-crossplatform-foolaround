using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomElementsControlLibrary
{
    [Description("Button that changes its color on click, selecting its properties from the predefined color sequence")]
    public partial class ColorChangingButton : Button
    {

        private List<Color> _colors;

        private IEnumerator<Color> ColorSequence;

        public Color CurrentColor
        {
            get => ColorSequence.Current;
        }

        private event EventHandler<ColorsChangedEventArgs> _onColorsChanged;

        [Category("Appearence"), Description("Invoked each time sequence of colors changed")]
        public event EventHandler<ColorsChangedEventArgs> OnColorsChanged
        {
            add
            {
                _onColorsChanged += value;
            }
            remove
            {
                _onColorsChanged -= value;
            }
        }

        [Category("Appearence"), Description("List of colors that button will be painted in")]
        public List<Color> Colors
        {
            get => _colors;
            set
            {
                if (value != null) {
                    _onColorsChanged?.Invoke(this, new ColorsChangedEventArgs(_colors, value));
                    _colors = value;
                    ColorSequence = _colors.Forever().GetEnumerator();
                }
            }
        }

        public ColorChangingButton()
        {
            InitializeComponent();
            this._colors = new List<Color>()
            {
                Color.Red,
                Color.Green,
                Color.Blue
            };
            this.ColorSequence = _colors.Forever().GetEnumerator();
            if (ColorSequence.MoveNext())
            {
                this.BackColor = ColorSequence.Current;
            }
        }    

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (ColorSequence.MoveNext())
            { 
                this.BackColor = ColorSequence.Current;
            }
        }
    }
}
