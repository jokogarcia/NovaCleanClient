using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Models
{
    public class VisitEvent:dbItemBase
    {
        public bool repeats {get;set;}
        public DateTime starting_date {get;set;}
        public TimeSpan starts_at {get;set;}
        public TimeSpan duration {get;set;}
        public DateTime date {get;set;}
        public List<CleaningTask> cleaningTasks {get;set;}
        public List<User> asignedEmployees {get;set;}
        public bool monday {get;set;}
        public bool tuesday {get;set;}
        public bool wednesday {get;set;}
        public bool thursday {get;set;}
        public bool friday {get;set;}
        public bool saturday {get;set;}
        public bool sunday {get;set;}
        public String DisplayDate
        {
            get
            {
                String retval = "";
                if (!repeats)
                {
                    return this.date.ToString("dd-MMM-yy");
                }
                if (monday &&
                        tuesday &&
                        wednesday &&
                        thursday &&
                        friday &&
                        saturday &&
                        sunday)
                    retval = "Lunes a Domingo";
                else if (monday &&
                        tuesday &&
                        wednesday &&
                        thursday &&
                        friday &&
                        saturday)
                {
                    retval = "Lunes a Sábado";
                }
                else if (monday &&
                        tuesday &&
                        wednesday &&
                        thursday &&
                        friday)
                {
                    retval = "Lunes a Viernes";
                }
                else if (
                        tuesday &&
                        wednesday &&
                        thursday &&
                        friday &&
                        saturday &&
                        sunday)
                {
                    retval = "Martes a Domingo";
                }
                else if (tuesday &&
                        wednesday &&
                        thursday &&
                        friday &&
                        saturday)
                {
                    retval = "Martes a Sábado";
                }
                else
                {
                    List<String> sArray = new List<String>();
                    if (monday)
                        sArray.Add("Lunes");
                    if (tuesday)
                        sArray.Add("Martes");
                    if (wednesday)
                        sArray.Add("Miércoles");
                    if (thursday)
                        sArray.Add("Jueves");
                    if (friday)
                        sArray.Add("Viernes");
                    if (saturday)
                        sArray.Add("Sábado");
                    if (sunday)
                        sArray.Add("Domingo");
                    if (sArray.Count == 0)
                    {
                        return "";
                    }
                    StringBuilder builder = new StringBuilder();
                    int i;
                    for (i = 0; i < sArray.Count - 2; i++)
                    {
                        if (i != 0)
                            builder.Append(", ");
                        builder.Append(sArray[i]);

                    }
                    builder.Append(" y ");
                    builder.Append(sArray[i]);
                    retval = builder.ToString();

                }
                return retval;
            }
        }
    }
}
