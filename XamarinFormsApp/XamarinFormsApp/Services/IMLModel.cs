using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.Services
{
    interface IMLModel
    {
        SmartReply[] Predict(string Message);
    }
}
