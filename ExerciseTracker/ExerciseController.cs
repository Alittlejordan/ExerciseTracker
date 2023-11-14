using Microsoft.IdentityModel.Protocols;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace ExerciseTracker
{
    internal class ExerciseController
    {
        private readonly ExerciseService _exerciseService;

       //this is the constructor for the ExerciseController class
        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        //this function wull run the program
        public void Run()
        {
            //this is the menu that will be displayed to the user
            Userinput userinput = new Userinput(_exerciseService);
            userinput.CreateMenu();

         
        }
    }
  

    }

