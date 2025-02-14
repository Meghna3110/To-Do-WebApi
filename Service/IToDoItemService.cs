using ToDoList.DTO;
using ToDoList.Model;

namespace ToDoList.Service
{
    public interface IToDoItemService
    {
        Task<ApiResponse<ToDoItem>> AddToDoItemAsync(ToDoItemRequestDto toDoRequest);
        Task<ApiResponse<ToDoItem>> UpdateToDoItemAsync(int id, ToDoItemRequestDto toDoRequest);
        Task<ApiResponse<string>> DeleteToDoItemAsync(int id);
        Task<ApiResponse<ToDoItemResponseDto>> GetToDoByIdAsync(int id);
        Task<ApiResponse<List<ToDoItemResponseDto>>> GetAllToDoItemsAsync();
    }
}
