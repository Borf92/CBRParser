using System;
using System.Windows;

namespace CBRParser
{
    public class Logger
    {
        public void Error(Exception exception)
        {
            MessageBox.Show(exception.Message);
        }

        public void Notify(string message)
        {
            MessageBox.Show(message);
        }
    }
}
