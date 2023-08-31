﻿using ToDoList.Entities;

namespace ToDoList
{
    public class Task : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaskStatus Status { get; set; }

        public int ToDoListId { get; set; }
        public ToDoList? ToDoList { get; set; }
    }
}

