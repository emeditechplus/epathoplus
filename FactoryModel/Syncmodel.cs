using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;


namespace FactoryModel
{
  public  class Syncmodel
    {
    }
    public class Syncdata
    {

        public string TBL_NAME { get; set; }
        public string INV_NO { get; set; }
        public string INVOICEDATE { get; set; }
        public string MODULENAME { get; set; }
        public string MODULE { get; set; }
        public string Modify_DT { get; set; }

    }
}
