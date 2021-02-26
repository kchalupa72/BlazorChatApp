using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChat.Data
{
    interface IChatState
    {
        bool GetIsChatting();

        void SetIsChatting(bool val);
    }
}
