using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Model
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateDate {  get; set; }

    }
}
