using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker
{
    internal class TableVisualisation
    {

        //this method is used to display the table using the ConsoleTableExt package
        internal static void ShowTable<T>(List<T> tableData) where T : class
        {
            Console.WriteLine("\n\n");

            ConsoleTableBuilder
                .From(tableData)
                .WithTitle("Exercise Tracker")
                .ExportAndWriteLine();
            Console.WriteLine("\n\n");



        }
    }
}
