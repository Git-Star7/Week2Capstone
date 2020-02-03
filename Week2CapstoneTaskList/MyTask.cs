using System;
using System.Collections.Generic;
using System.Text;

namespace Week2CapstoneTaskList
{
    class MyTask
    {
        #region Fields
        private string teamMemberName;
        private string description;
        private DateTime dueDate;
        private bool completed;
        #endregion

        #region Properties
        public string TeamMemberName
        {
            get { return teamMemberName; }
            set { teamMemberName = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }
        #endregion

        #region Constructors
        public MyTask()
        {

        }
        public MyTask(string _teamMemberName, string _description, DateTime _dueDate)
        {
            teamMemberName = _teamMemberName;
            description = _description;
            dueDate = _dueDate;
        }
        #endregion

        #region Methods
        // didn't know what methods to put in here
        #endregion
    }
}
