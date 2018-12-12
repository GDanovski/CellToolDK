using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellToolDK
{
    //create new control
    public class Transmiter
    {
        //add event handler
        public event TransmiterEventHandler Changed;
        //function for changing value
        public void ReloadImage(string Value = "")
        {
            if (Changed != null)
                Changed(this, new TransmiterEventArgs(Value));
        }
    }
    //declare event handler
    public delegate void TransmiterEventHandler(object sender, TransmiterEventArgs e);
    //declare new event arg
    public class TransmiterEventArgs : EventArgs
    {
        private string m_Data;
        public TransmiterEventArgs(string myData = "")
        {
            m_Data = myData;
        }
        public string Value { get { return m_Data; } }
    }
}
