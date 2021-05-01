using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using Dapper;
using FactoryModel;


namespace FactoryDatacontext
{
    public class Synccontext
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["Factconn"].ConnectionString);
        private IDbConnection _dbcube = new SqlConnection(ConfigurationManager.ConnectionStrings["constringrpt"].ConnectionString);
        public List<Syncdata> Syncdata(string frmdate,string todate)
        {
            List<Syncdata> Syncdata = new List<Syncdata>();
            try
            {
                Syncdata = _db.Query<Syncdata>("USP_DATASYNCFOCUBE", new { P_FROMDATE = frmdate, P_TODATE = todate }, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {

            }
            return Syncdata;
        }
        public List<Syncdata> Modulelist()
        {
            List<Syncdata> Syncdata = new List<Syncdata>();
            try
            {
                Syncdata = _db.Query<Syncdata>("usp_cubemodules",  commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {

            }
            return Syncdata;
        }
        public List<MessageModel> Syncdatainsert(string frmdate, string todate,string synctype)
        {
            List<MessageModel> response = new List<MessageModel>();
            List<Syncdata> Syncdata = new List<Syncdata>();
            string spname="";
            try
            {
                if (synctype == "primary")
                {
                    spname = "USP_Primary_data_Insert_v2";
                }
                else
                    if (synctype == "Secondary")
                {
                    spname = "USP_Secondary_data_Insert_v2";
                }
                else
                    if (synctype == "TSi")
                {
                    spname = "USP_TSIORDERDUMP_INSERT_v2";
                }
                response = _dbcube.Query<MessageModel>(spname,
                    
                                                        new
                                                        {
                                                            P_FROMDATE = frmdate,
                                                            P_TODATE = todate,
                                                        },
                                                        commandType: CommandType.StoredProcedure).ToList();
               

            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
