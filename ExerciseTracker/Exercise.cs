using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker
{
    internal class Exercise
    {
        
        //this variable is used to store the id of the exercise
        public int Id { get; set; }
      
        //this variable stores the start date of the exercise
        public DateTime DateStart { get; set; }

        //this variable stores the end date of the exercise
        public DateTime DateEnd { get; set; }

        //this variable stores the duration of the exercise
        public TimeSpan Duration { get; set; }

        //this variable stores the type of the exercise
        public string Comments { get; set; }
    }
}
