using System.Configuration;

namespace AAITschool {
    public static class Str {

     static string GetConnectionStr() {
        //Go to web.config gets connection string  
        string strCon = ConfigurationManager.ConnectionStrings["SQL_Connection"].ConnectionString;
        return strCon;
    }

    }
}