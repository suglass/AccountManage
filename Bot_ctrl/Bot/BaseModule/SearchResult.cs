using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule
{
    public class SearchResult
    {
        public string strSubject;
        public string strFrom;
        public string strTo;
        public DateTime dtReceived;

        public string strEmlPath;

        public SearchResult()
        {
            strSubject = "";
            strFrom = "";
            strTo = "";
            dtReceived = DateTime.MinValue;
            strEmlPath = "";
        }
        public SearchResult(SearchResult _temp)
        {
            strSubject = _temp.strSubject;
            strFrom = _temp.strFrom;
            strTo = _temp.strTo;
            dtReceived = _temp.dtReceived;
            strEmlPath = _temp.strEmlPath;
        }
    }
}
