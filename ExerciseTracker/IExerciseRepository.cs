using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker
{
    internal interface IExerciseRepository
    {

        Exercise GetById(int id);

        // function to add an exercise to the database
        void Add(Exercise exercise);

        // function to update an exercise in the database
        void Update(Exercise exercise);

        // function to delete an exercise from the database
        void Delete(int id);
        IEnumerable<Exercise> GetAll();
    }
}
