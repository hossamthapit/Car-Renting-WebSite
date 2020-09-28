using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage1.Models {

    public enum kind {
        package,
        car
    }

    public class LogFile  {
        public int ID { get; set; }
        public List< Log > MSGs { get; set; }

        public void newReservation(object o , string s , int period , long nationalID) {
            Log newMessage = new Log();
            newMessage.MSG = s;
            newMessage.date = DateTime.Today;
            newMessage.nationalID = nationalID;
            if (o is Package) {
                Package p = (Package)(o);
                newMessage.carID = p.ID;
                newMessage.kind = kind.package;
            }
            else {
                Car c = (Car)(o);
                newMessage.carID = c.ID;
                newMessage.kind = kind.car;
            }
            newMessage.period = period;
            if (MSGs == null) MSGs = new List<Log>();

            context data = new context();
            if (data.LogFile.FirstOrDefault() == null) {
                data.LogFile.Add(new LogFile());
                data.SaveChanges();
            }
            if (data.LogFile.FirstOrDefault().MSGs == null)
                data.LogFile.FirstOrDefault().MSGs = new List<Log>();

            data.LogFile.FirstOrDefault().MSGs.Add(newMessage);
            data.SaveChanges();
        }
        
    }
}