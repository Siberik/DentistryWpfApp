using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistryWpfApp.Model.Controllers
{
    public class ClientsController
    {
        private static Core db = new Core();
        public static bool AddClient(string clientName, string clientLastname, int personalId,string clientSurname = null, string clientPhone = null)
        {

            try

            {
                Clients appomentsConnect = new Clients()
                {
                    Clients_Name = clientName,
                    Clients_Surname = clientSurname,
                    Clients_Lastname = clientLastname,
                    Clients_Phone = clientPhone,
                    Personal_Id_FK = personalId,
                };

                db.context.Clients.Add(appomentsConnect);
                if (db.context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }




            }
            catch
            {
                return false;
            }
        }
        
    }
}
