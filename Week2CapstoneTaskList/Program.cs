using System;
using System.Collections.Generic;

namespace Week2CapstoneTaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> menu = new List<string> { "List tasks", "Add task","Edit Task", "Delete task", "Mark task complete", "Quit" };

            List<MyTask> listOfTasks = new List<MyTask>
            {
                new MyTask("Arya", "Go to Bravos", DateTime.Parse("7/1/1324")),
                new MyTask("Arya", "Kill Serci", DateTime.Parse("5/30/1324")),
                new MyTask("John", "Save the North", DateTime.Parse("7/5/1324")),
                new MyTask("Bran", "Find the three-eyed-raven", DateTime.Parse("6/13/1324")),
                new MyTask("John", "Take back Winterfell", DateTime.Parse("6/5/1324")),
            };

            bool continueLoop = true;
            do
            {
                //Prints menu and asks for input. Displays selection based on int input. Quit breaks the loop.
                PrintList(menu);
                int input = InputIsInt(menu, GetUserInput("\nSelect an option: "));
                if (input == 0) { ListTasks(listOfTasks); }
                else if (input == 1) { AddTask(listOfTasks); }
                else if (input == 2) { EditTask(listOfTasks); }
                else if (input == 3) { DeleteTask(listOfTasks); }
                else if (input == 4) { MarkTaskComplete(listOfTasks); }
                else if (input == 5) { continueLoop = false; }

            }
            while (continueLoop == true);
        }

        public static int InputIsInt(List<MyTask> list, string pick) //takes in a number and catches if it's invalid (for MyTask lists)
        {
            try
            {
                int intPick = int.Parse(pick) - 1;
                string tryExceptionT = list[intPick].TeamMemberName;
                return intPick;
            }
            catch
            {
                return InputIsInt(list, GetUserInput($"Invalid selection, enter a number between 1 - {list.Count}: "));
            }
        }
        public static int InputIsInt(List<string> list, string pick) //takes in a number and catches if it's invalid (for string lists)
        {
            try
            {
                int intPick = int.Parse(pick) - 1;
                string tryExceptionT = list[intPick];
                return intPick;
            }
            catch
            {
                return InputIsInt(list, GetUserInput($"Invalid selection, enter a number between 1 - {list.Count}: "));
            }
        }
        public static bool Option1or2(string message, string option1, string option2) //displays message and validates answer
        {
            string userContinue = "";
            while (userContinue != option1 && userContinue != option2)
            {
                Console.Write(message);
                userContinue = Console.ReadLine();

                if (userContinue == option2)
                {
                    Console.WriteLine("Okay!!");
                    return false;
                }
            }
            return true;
        }
        public static string GetUserInput(string message) //takes in input and displays message
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return input;
        }

        public static void PrintList(List<string> listToPrint) //loops through the list and prints menu list (<string>)
        {
            Console.WriteLine();
            for (int i = 0; i < listToPrint.Count; i++)
            {
                Console.WriteLine($"  {i + 1}: {listToPrint[i]}");
            }
        }
        public static void ListTasks(List<MyTask> listToPrint) //loops through task list and prints the details out
        {
            Console.WriteLine();
            for (int i = 0; i < listToPrint.Count; i++)
            {
                Console.WriteLine($"  Task {i + 1}: {listToPrint[i].TeamMemberName} \tDue Date: {listToPrint[i].DueDate.ToShortDateString()}  \tCompleted: {listToPrint[i].Completed} \tDescription: {listToPrint[i].Description}");
            }
            Console.WriteLine();
        }
        public static void AddTask(List<MyTask> listToAddTo) //adds new task to listOfTasks to bottom of list
        {
            string name = GetUserInput("\nTeam Member Name: ");
            string description = GetUserInput("Task Description: ");

            DateTime dueDate = DateTime.Parse("1/1/11");
            bool validDate = false;
            while (validDate == false)
            {
                try
                {
                    dueDate = DateTime.Parse(GetUserInput("Due Date (mm/dd/yy): "));
                    validDate = true;
                }
                catch
                {
                    Console.WriteLine("Invalid date");
                    validDate = false;
                }
            }
            Console.WriteLine();
            listToAddTo.Add(new MyTask ( name, description, dueDate ));
        }
        public static void DeleteTask(List<MyTask> listToDeleteFrom) //deletes task at point of selection
        {
            ListTasks(listToDeleteFrom);
            int num = InputIsInt(listToDeleteFrom, GetUserInput("Select a task to delete: "));
            Console.WriteLine($"\n  Task {num + 1}: {listToDeleteFrom[num].TeamMemberName} \tDue Date: {listToDeleteFrom[num].DueDate.ToShortDateString()}  \tCompleted: {listToDeleteFrom[num].Completed} \tDescription: {listToDeleteFrom[num].Description}\n");
            bool areYouSure = Option1or2("Are you sure? Y/N: ", "Y", "N");
            if (areYouSure == true)
            {
                listToDeleteFrom.RemoveAt(num);
            }
        }
        public static void MarkTaskComplete(List<MyTask> listToMarkComplete) //marks completion as true at point of selection
        {
            ListTasks(listToMarkComplete);
            int num = InputIsInt(listToMarkComplete, GetUserInput("\nSelect a task to mark as complete: "));
            Console.WriteLine($"\n  Task {num + 1}: {listToMarkComplete[num].TeamMemberName} \tDue Date: {listToMarkComplete[num].DueDate.ToShortDateString()}  \tCompleted: {listToMarkComplete[num].Completed} \tDescription: {listToMarkComplete[num].Description}\n");
            bool areYouSure = Option1or2("Are you sure? Y/N: ", "Y", "N");
            if (areYouSure == true)
            {
                listToMarkComplete[num].Completed = true;
            }
        }
        public static void EditTask(List<MyTask> listToEdit) //select task to edit and asks what you want to edit. then edits it
        {

            ListTasks(listToEdit);
            int taskNum = InputIsInt(listToEdit, GetUserInput("\nSelect a task to edit: "));
            Console.WriteLine($"\n  Task {taskNum + 1}: {listToEdit[taskNum].TeamMemberName} \tDue Date: {listToEdit[taskNum].DueDate.ToShortDateString()}  \tCompleted: {listToEdit[taskNum].Completed} \tDescription: {listToEdit[taskNum].Description}\n");

            int fieldToEdit = InputIsInt(listToEdit, GetUserInput("1: Team Member\n2: Due Date\n3: Description\n\nWhat field would you like to edit?: "));

            if (fieldToEdit == 0)
            {
                Console.WriteLine($"Current Team Member Name: {listToEdit[taskNum].TeamMemberName}\n");
                listToEdit[taskNum].TeamMemberName = GetUserInput("Enter new name: ");
            }
            else if (fieldToEdit == 1)
            {
                Console.WriteLine($"Current Due Date: {listToEdit[taskNum].DueDate.ToShortDateString()}\n");
                bool validDate = false;
                while (validDate == false)
                {
                    try
                    {
                        listToEdit[taskNum].DueDate = DateTime.Parse(GetUserInput("Enter new due date (mm/dd/yy): "));
                        validDate = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid date");
                        validDate = false;
                    }
                }
            }
            else if (fieldToEdit == 2)
            {
                Console.WriteLine($"Current Description: {listToEdit[taskNum].Description}\n");
                listToEdit[taskNum].Description = GetUserInput("Enter new description: ");
            }
        }
    }
}
