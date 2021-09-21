using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Communication
{
    class ErrorResource
    {
        public bool Success => false;
        public List<string> Messages { get; private set; }

        public ErrorResource(List<string> messages) => Messages = messages ?? new List<string>();

    }
}
