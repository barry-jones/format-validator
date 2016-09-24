﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormatValidator
{
    public class ValidationError
    {
        private int _atCharacter;
        private string _message;

        public ValidationError(int at, string message)
        {
            _atCharacter = at;
            _message = message;
        }

        public string Message
        {
            get
            {
                return _message;
            }
        }

        public int AtCharacter
        {
            get
            {
                return _atCharacter;
            }
        }
    }
}
