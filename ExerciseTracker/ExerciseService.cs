using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker
{
    internal class ExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public void AddExercise(Exercise exercise)
        {
            // Add any additional business logic/validation if needed
            _exerciseRepository.Add(exercise);
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            // You can include additional logic if needed
            return _exerciseRepository.GetAll();
        }

        public void RemoveExercise(int id)
        {
            // Add any additional business logic/validation if needed
            _exerciseRepository.Delete(id);
        }

       public void UpdateExercise(Exercise exercise)
        {
            _exerciseRepository.Update(exercise);
        }

        public Exercise GetExerciseById(int id)
        {
            return _exerciseRepository.GetById(id);
            
        }
    }
}
