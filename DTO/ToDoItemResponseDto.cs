﻿namespace ToDoList.DTO
{
    public class ToDoItemResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
