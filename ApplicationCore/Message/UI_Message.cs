using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Message
{
    public class UI_Message
    {
        private string _dataInsertionSuccess = "All information has been saved successfully.";
        private string _dataInsertionFailed = "Data insertion has been failed!";
        private string _updateSuccess = "All information has been updated successfully.";
        private string _updateFailed = "Data has not been updated!";
        private string _invalidModel = "Please provide all the information correctly!";
        private string _recordExist = "Record already exist!";

        public string DataInsertionSuccess { get { return _dataInsertionSuccess; } }
        public string DataInsertionFailed { get { return _dataInsertionFailed; } }
        public string UpdateSuccess { get { return _updateSuccess; } }
        public string UpdateFailed { get { return _updateFailed; } }
        public string InvalidModel { get { return _invalidModel; } }
        public string RecordExist { get { return _recordExist; } }
    }

}
