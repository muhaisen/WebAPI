using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EllevioCore.Ellevio.Entities
{
    [DataContract]
    public class CookieNoticeBE
    {
        [DataMember]
        public string CookiesActiveHeading { get; set; }

        [DataMember]
        public string CookiesActiveMessage { get; set; }

        [DataMember]
        public string CookiesDisabledHeading { get; set; }

        [DataMember]
        public string CookiesDisabledMessage { get; set; }

        [DataMember]
        public string ReadMoreText { get; set; }

        [DataMember]
        public string ReadMoreURL { get; set; }
    }
}
