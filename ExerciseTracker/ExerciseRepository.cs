using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker
{
    internal class ExerciseRepository : IExerciseRepository
    {
        private readonly ExerciseDbContext _dbContext;

        public ExerciseRepository(ExerciseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // function to get an exercise by id from the database
        public Exercise GetById(int id)
        {
            return _dbContext.Exercises.Find(id);
        }

        // function to add an exercise to the database
        public void Add(Exercise exercise)
        {
            _dbContext.Exercises.Add(exercise);
            _dbContext.SaveChanges();
        }

        // function to update an exercise in the database
        public void Update(Exercise exercise)
        {
            _dbContext.Exercises.Update(exercise);
            _dbContext.SaveChanges();
        }

        // function to delete an exercise from the database
        public void Delete(int id)
        {
            var exercise = GetById(id);
            if (exercise != null)
            {
                _dbContext.Exercises.Remove(exercise);
                _dbContext.SaveChanges();
            }
        }

        // function to get all exercises from the database
        public IEnumerable<Exercise> GetAll()
        {
            return _dbContext.Exercises.ToList();
        }
    }
}
