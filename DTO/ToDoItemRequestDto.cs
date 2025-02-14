using System.ComponentModel;

namespace ToDoList.DTO
{
    public class ToDoItemRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [DefaultValue(false)] 
        public bool IsCompleted { get; set; }
    }
}
