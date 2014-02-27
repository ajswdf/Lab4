using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Lab4SOAP
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string queryTable(string id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            conn.Open();

            string firstName = "";
            string lastName = "";
            SqlCommand cmd = new SqlCommand("Select * from table where id=" + id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                firstName = firstName + ";" + reader["firstname"];
                lastName = lastName + ";" + reader["lastname"];
            }
            reader.Close();
            conn.Close();
            return "info: " + firstName + ", " + lastName;
        }
    }
}