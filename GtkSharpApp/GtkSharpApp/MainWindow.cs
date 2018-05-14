using System;
using Gtk;
using static GtkSharpApp.MagicNumberService;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void HandleSubmit(object sender, EventArgs e) 
    {
        this.ResultOutput.Text = GetMagicNumber((int)this.NumberInput.Value, 
                           this.TextInput.Buffer.Text).ToString();
    }
       
}
