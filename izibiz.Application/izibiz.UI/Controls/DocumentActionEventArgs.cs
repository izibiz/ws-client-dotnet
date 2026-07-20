using System;

namespace izibiz.UI.Controls
{
    public class DocumentActionEventArgs : EventArgs
    {
        public string Format { get; }

        public DocumentActionEventArgs(string format)
        {
            Format = format;
        }
    }
}
