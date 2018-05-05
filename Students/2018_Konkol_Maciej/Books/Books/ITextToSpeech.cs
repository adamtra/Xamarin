using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
