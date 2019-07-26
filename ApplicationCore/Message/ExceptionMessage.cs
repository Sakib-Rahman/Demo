using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Message
{
    public class ExceptionMessage
    {
        private string _invalidOperationException = "Please update the database.";
        private string _commonException = "Something went wrong! Please try again later!";

        public string InvalidOperationException { get { return _invalidOperationException; } }
        public string CommonException { get { return _commonException; } }
    }
}
