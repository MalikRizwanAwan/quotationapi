using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using MODELS.Model;
using System.Web.Http.Cors;
using BAL.IManager;
using BAL.Manager;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Data.OracleClient;
using System.Web.Mvc;
using System.Net.Mail;

namespace CustomerOrder.Controllers
{
  
    [System.Web.Http.RoutePrefix("api/CustomerOrder")]
   
    public class CustomerOrderController : ApiController
    {
        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected readonly ICustomerOrder _customerOrder;
        public string GetConnectionString()
        {

            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        
        //test start

        //string connectionstring= ConfigurationManager.ConnectionStrings["DATA SOURCE=localhost:1521/XE;USER ID=SYSTEM;password:nml;Integrated Security=True"].ConnectionString;


        //test end
        public CustomerOrderController()
        {
            _customerOrder = new CustomerOrderManager();

        }
        [EnableCors("*", "*", "*")]
        //[Route("CustomerOrder")]
        //[HttpPost]
        public String CustomerOrder(List<OrderInfo> orderInfo)
        {

           

            string result = _customerOrder.GetCustomerOrder(orderInfo);
                if (result !=null)
                {
                return result; ;
                }
                else


                {
                return null; ;
                }

           
        }


        //email

        [EnableCors("*", "*", "*")]
        //[Route("CustomerOrder")]
        //[HttpPost]
        public IHttpActionResult email(getemail email)
        {
            //for(int i=0;i<= 10; i++) { 
            //      int id = i;
           
            int id = email.email;
            

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress("rizwan.345awan@gmail.com", "Rizwan");
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            message.From = fromAddress;
            //message.To.Add(txtEmail.Text);
            message.Subject = "Please Check Detail By opening the Link. Thank You .... ";
            var mail = "malikrizwanawan77@gmail.com";
            message.Bcc.Add(mail);
            //message.Bcc.Add("mrasheed@Nishatmills.com");

            message.IsBodyHtml = false;
            message.Body = "http://localhost:4200/landingPage/" + id + "";
            smtpClient.Credentials = new System.Net.NetworkCredential("rizwan.345awan@gmail.com", "rizwan478");
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);


            //}

            return NotFound();
          


        }








        [EnableCors("*", "*", "*")]
        //[Route("GetEmployeeProfile")]
        //[HttpGet]
        public IHttpActionResult GetEmployeeProfile(getCustomerDetail gorder)
        {






            // OracleConnection _connection = new Oracle.DataAccess.Client.OracleConnection("DATA SOURCE = localhost:1521 / XE; User ID = SYSTEM; Password = nml; Persist Security Info = True");
            // _connection.Open();
            // try
            // {
            //     //var result = 0;

            //     var sql = "Select pressureseal, jackseal, scaanerflatbed Into P_pressureseal, P_jackseal, P_scaanerflatbed from CORDERTABLE where brakecylander =124";




            //     //String sql = "Select * from CUSTOMERORDER.CORDERTABLE";
            //     OracleCommand command = new OracleCommand(sql, _connection);

            // }
            //catch (Exception ex)
            // {
            //     Log.Error("Method in context SaveCustomer(): " + ex.Message);
            // }
            // _connection.Close();

            // //var abc = 124;
            // //string result = _customerOrder.GetEmployeeProfile(abc);
            // //if (result != null)
            // //{
            // //    return Ok(result);
            // //}
            // //else
            // //{
            return NotFound();
            // //}
            // return null;
        }
        Oracle.DataAccess.Client.OracleConnection con = new Oracle.DataAccess.Client.OracleConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
       public DataSet GetRecord(string cmdText, CommandType cmdType, List<Oracle.DataAccess.Client.OracleParameter> parameters = null)
        {
            
            Oracle.DataAccess.Client.OracleCommand com = new Oracle.DataAccess.Client.OracleCommand("CUSTOMERORDER.CgetorderProcedure", con);
            com.CommandType = CommandType.StoredProcedure;           
            var  da = new Oracle.DataAccess.Client.OracleDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public JsonResult getrecordtest()
        {

            var sParameter = new List<Oracle.DataAccess.Client.OracleParameter>();
            sParameter.Add(new Oracle.DataAccess.Client.OracleParameter { ParameterName = "@brakecylander", Value = 124 });
            sParameter.Add(new Oracle.DataAccess.Client.OracleParameter { ParameterName = "@pressureseal", Value = -1 });
            sParameter.Add(new Oracle.DataAccess.Client.OracleParameter { ParameterName = "@jackseal", Value = -1 });
            sParameter.Add(new Oracle.DataAccess.Client.OracleParameter { ParameterName = "@scaanerflatbed", Value = -1 });
            DataSet ds = this.GetRecord("CUSTOMERORDER.CorderProcedure", CommandType.StoredProcedure, sParameter);
            List<getCustomerDetail> lstrng = new List<getCustomerDetail>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstrng.Add(new getCustomerDetail
                {
                    //brakecylander = Convert.ToInt32(dr["brakecylander"]),
                    //pressureseal = Convert.ToInt32(dr["pressureseal"]),
                    //jackseal = Convert.ToInt32(dr["jackseal"]),
                    //scaanerflatbed = Convert.ToInt32(dr["scaanerflatbed"])
                });
            }
            //return Json(lstrng, JsonRequestBehavior.AllowGet);
            return null;
        }


    }
}
