using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using static CommonDivisorLibrary.CommonMultiple;
using static CommonDivisorLibrary.LongestWordFinder;

namespace Xamarin
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        void OnButtonClicked(object sender, EventArgs args)
        {
            Entry textEntry = Content.FindByName<Entry>("Text");
            Entry numberEntry = Content.FindByName<Entry>("Number");

            string numberString = numberEntry.Text;
            string text = textEntry.Text;

            if (Int32.TryParse(numberString, out int n))
            {
                Entry magicEntry = Content.FindByName<Entry>("Magic");
                magicEntry.Text = FindLeastCommonMultiple((text ?? "").Length, n).ToString();
            }

        }
    }
}
