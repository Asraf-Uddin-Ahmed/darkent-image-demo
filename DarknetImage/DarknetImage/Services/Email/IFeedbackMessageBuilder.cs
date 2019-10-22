using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarknetImage.Services.Email
{
    public interface IFeedbackMessageBuilder : IMessageBuilder
    {
        void Build(string message);
    }
}
