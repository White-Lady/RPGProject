using System;
using System.Linq;

namespace FinalFantasy.Sprite
{
    public class NumberOutOfRangeException : ApplicationException
    {
        private int Num { get; set; }

        public NumberOutOfRangeException(string msg)
            : base(msg)
        {
        }

        public NumberOutOfRangeException(string msg, int num)
            : base(msg)
        {
            this.Num = num;
        }

        public NumberOutOfRangeException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }

        public override string Message
        {
            get
            {
                return base.Message + " " + this.Num;
            }
        }

    }
}
