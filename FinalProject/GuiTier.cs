namespace FinalProject;
using System.Data;
using MySql.Data.MySqlClient;
class GuiTier{
    User user = new User();
    DataTier database = new DataTier();

    // print login page
    public User Login(){
        Console.WriteLine("------Welcome to the Package Software------");
        Console.WriteLine("Please input staff username: ");
        user.staff_username = Console.ReadLine();
        Console.WriteLine("Please input staff password: ");
        user.staff_password = Console.ReadLine();
        return user;
    }
    // print Dashboard after user logs in successfully
    public int Dashboard(User user){
        DateTime localDate = DateTime.Now;
        Console.WriteLine("---------------Dashboard-------------------");
        Console.WriteLine($"Hello: {user.staff_username}; Date/Time: {localDate.ToString()}");
        Console.WriteLine("Please select an option to continue:");
        Console.WriteLine("1. Verify Resident");
        Console.WriteLine("2. Add a Package");
        Console.WriteLine("3. Add an Unknown Package");
        Console.WriteLine("4. Log Out");
        int option = Convert.ToInt16(Console.ReadLine());
        return option;
    }

    // show enrollment records returned from database
    public void DisplayResidents(DataTable tableResidents){
        Console.WriteLine("---------------Resident List-------------------");
        foreach(DataRow row in tableResidents.Rows){
           Console.WriteLine($"id: {row["id"]} \t full_name: {row["full_name"]} \t unit_number:{row["unit_number"]}");
        }
    }

    public void DisplayPending(DataTable tablePending){
        Console.WriteLine("---------------Pending List-------------------");
        foreach(DataRow row in tablePending.Rows){
           Console.WriteLine($"id: {row["id"]} \t full_name: {row["full_name"]} \t unit_number:{row["unit_number"]}");
        }
    }

     public void DisplayUnknown(DataTable tableUnknown){
        Console.WriteLine("---------------Pending List-------------------");
        foreach(DataRow row in tableUnknown.Rows){
           Console.WriteLine($"id: {row["id"]} \t full_name: {row["full_name"]} \t carrier:{row["carrier"]}");
        }
    }
}
