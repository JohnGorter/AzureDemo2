using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    //public static class TrainingDatabase
    //{
    //    private static List<Training> _trainings = new List<Training>();
    //    private static List<Registration> _registrations = new List<Registration>();

    //    public static List<Training> Trainings { get { return _trainings; } private set { } }
    //    public static List<Registration> Registrations { get { return _registrations; } private set { } }

    //    static TrainingDatabase() {
    //        _trainings = new List<Training>() {
    //            new Training { id=0, name="c# 1", description="Programming c sharp", location="Veenendaal", startDate=DateTime.Now},
    //            new Training { id=1, name="Objective C", description="Programming c sharp", location="Veenendaal", startDate=DateTime.Now},
    //            new Training { id=2, name="JavaScript", description="Programming c sharp", location="Veenendaal", startDate=DateTime.Now},
    //            new Training { id=3, name="c# 4", description="Programming c sharp", location="Veenendaal", startDate=DateTime.Now},
    //            new Training { id=4, name="c# 5", description="Programming c sharp", location="Veenendaal", startDate=DateTime.Now},
    //            new Training { id=5, name= "c# 6", description = "Programming c sharp", location = "Veenendaal", startDate = DateTime.Now}
    //        };
    //    }

    //    public static IEnumerable<Training> getTrainings() { return Trainings; }
    //    public static IEnumerable<Registration> getRegistrations() {  return Registrations; }

    //    public static void RegisterStudent(Training t, String StudentName) {
    //        t.registrations.Add(new Registration { StudentName = StudentName, training = t });
    //    }
    //}

  
}