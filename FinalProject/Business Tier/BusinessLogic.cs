namespace FinalProject;
using System.Data;
using MySql.Data.MySqlClient;
class BusinessLogic
{
   
    static void Main(string[] args)
    {
        bool _continue = true;
        User user;
        GuiTier appGUI = new GuiTier();
        DataTier database = new DataTier();

        // start GUI
        user = appGUI.Login();

       
        if (database.LoginCheck(user)){

            while(_continue){
                int option  = appGUI.Dashboard(user);
                switch(option)
                {
                    // check enrollment
                    case 1:
                        DataTable tableResidents = database.CheckResident(user);
                        if(tableResidents != null)
                            appGUI.DisplayResidents(tableResidents);
                        break;
                    // Add A Package to Pending
                    case 2:
                        Console.WriteLine("Please input a name");
                        string inputfull_name = Console.ReadLine();
                        Console.WriteLine("Please enter the unit number");
                        int inputunit_number = Convert.ToInt16(Console.ReadLine());
                        database.AddPackage(inputfull_name, inputunit_number);
                        break;
                    // Add package to unknown
                    case 3:
                       // Console.WriteLine("Please input a name");
                       // string inputfull_name = Console.ReadLine();
                       // Console.WriteLine("Please enter the carrier");
                       // string inputcarrier = Console.ReadLine();
                        //database.AddUnknown(inputfull_name, inputcarrier);
                       // break;
                    // Log Out
                    case 4:
                        _continue = false;
                        Console.WriteLine("Log out, Goodbye.");
                        break;
                    // default: wrong input
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }

            }
        }
        else{
                Console.WriteLine("Login Failed, Goodbye.");
        }        
    }    
}
