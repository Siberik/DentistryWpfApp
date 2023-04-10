using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistryWpfApp.Model.Controllers
{
    public class ClientsController
    {
        private static  Core db = new Core();
        public  bool AddClient(string clientName, string clientLastname, int personalId,string clientSurname = null, string clientPhone = null)
        {
            
            try

            {
                
               
                Clients clientsConnect = new Clients()
                {
                   
                    Clients_Name = clientName,
                    Clients_Surname = clientSurname,
                    Clients_Lastname = clientLastname,
                    Clients_Phone = clientPhone,
                    Personal_Id_FK = personalId
                };

                db.context.Clients.Add(clientsConnect);
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
        public Clients EditClient(Clients currentClient,string newPassword)
        {

            try

            {
                currentClient.Clients_Name

            }
}
