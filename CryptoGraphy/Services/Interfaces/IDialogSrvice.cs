﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoGraphy
{
    public interface IDialogService
    {
        void ShowMessage(string message);   // message
        string FilePath { get; set; }   // path
        bool OpenFileDialog();  // open
        bool SaveFileDialog();  // save
    }
}
