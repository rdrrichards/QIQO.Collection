using QIQO.Core.Contracts;
using QIQO.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

namespace QIQO.Data
{
    public class MainDBContext : DBContextBase, IMainDBContext
    {
        public MainDBContext()
        {
            conString = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
            con = new SqlConnection(conString);
        }
    }
}
