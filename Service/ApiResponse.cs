using ToDoList.Model;

namespace ToDoList.Service
{
    internal class ApiResponse
    {
        public bool Success { get; set; }
        public ToDoItem Data { get; set; }
        public string Message { get; set; }
        public object ErrorMessage { get; set; }
    }
}