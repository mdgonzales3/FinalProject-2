namespace FinalProject;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
class DataTier{
    public string connStr = "server=20.172.0.16;user=mdgonzales3;database=mdgonzales3;port=8080;password=mdgonzales3";

    // perform login check using Stored Procedure "LoginCount" in Database based on given user' studentID and Password
    public bool LoginCheck(User user){
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {  
            conn.Open();
            string procedure = "LoginCount";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure; // set the commandType as storedProcedure
            cmd.Parameters.AddWithValue("@inputstaff_username", user.staff_username);
            cmd.Parameters.AddWithValue("@inputstaff_password", user.staff_password);
            cmd.Parameters.Add("@userCount", MySqlDbType.Int32).Direction =  ParameterDirection.Output;
            MySqlDataReader rdr = cmd.ExecuteReader();
           
            int returnCount = (int) cmd.Parameters["@userCount"].Value;
            rdr.Close();
            conn.Close();

            if (returnCount ==1){
                return true;
            }
            else{
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return false;
        }
       
    }

    // perform resident check
    public DataTable CheckResident(User user){
        MySqlConnection conn = new MySqlConnection(connStr);
        Console.WriteLine("Please input the resident's full name");
        string resident = Console.ReadLine();
        try
        {  
            conn.Open();
            string procedure = "CheckResident";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputfull_name", resident);
            cmd.Parameters["@inputfull_name"].Direction = ParameterDirection.Input;

            MySqlDataReader rdr = cmd.ExecuteReader();

            DataTable tableResidents = new DataTable();
            tableResidents.Load(rdr);
            rdr.Close();
            conn.Close();
            return tableResidents;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }

    public void AddPackage(string full_name, int unit_number){
        MySqlConnection conn = new MySqlConnection(connStr);
       
        try
        {  
            conn.Open();
            string procedure = "AddPackage";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputfull_name", full_name);
            cmd.Parameters["@inputfull_name"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@inputunit_number", unit_number);
            cmd.Parameters["@inputunit_number"].Direction = ParameterDirection.Input;
            cmd.ExecuteNonQuery();
            
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
        }

        
}

public void AddUnknown(string full_name, string carrier){
        MySqlConnection conn = new MySqlConnection(connStr);
       
        try
        {  
            conn.Open();
            string procedure = "AddUnknown";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputfull_name", full_name);
            cmd.Parameters["@inputfull_name"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@inputcarrier", carrier);
            cmd.Parameters["@inputcarrier"].Direction = ParameterDirection.Input;
            cmd.ExecuteNonQuery();
            
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
        }

        
}

}