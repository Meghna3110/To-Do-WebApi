using Azure;
using ToDoList.DTO;
using ToDoList.Model;
using ToDoList.Repository;

namespace ToDoList.Service
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoItemService(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task<ApiResponse<List<ToDoItemResponseDto>>> GetAllToDoItemsAsync()
        {
            try
            {
                var toDoItems = await _toDoItemRepository.GetAllAsync();
                var toDoResponses = toDoItems.Select(item => new ToDoItemResponseDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    IsCompleted = item.IsCompleted,
                    CreateDate = item.CreateDate
                }).ToList();

                return new ApiResponse<List<ToDoItemResponseDto>>()
                {
                    Success = true,
                    Data = toDoResponses,
                    Message = "To-Do items retrieved successfully",
                    ErrorMessage = null
                };
            }
            catch (Exception ex) {
                return new ApiResponse<List<ToDoItemResponseDto>>()
                {
                    Success = false,
                    Data = null,
                    Message = "To-Do items retrieve un-successfull",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<ApiResponse<ToDoItemResponseDto>> GetToDoByIdAsync(int id)
        {
            try
            {
                var toDoItem = await _toDoItemRepository.GetByIdAsync(id);
                if (toDoItem == null)
                {
                    return new ApiResponse<ToDoItemResponseDto>()
                    {
                        Success = false,
                        Data = null,
                        Message = $"To-Do item with ID {id} not found",
                        ErrorMessage = null
                    };
                }

                var response = new ToDoItemResponseDto
                {
                    Id = toDoItem.Id,
                    Title = toDoItem.Title,
                    Description = toDoItem.Description,
                    IsCompleted = toDoItem.IsCompleted,
                    CreateDate = toDoItem.CreateDate
                };

                return new ApiResponse<ToDoItemResponseDto>()
                {
                    Success = true,
                    Data = response,
                    Message = "To-Do item retrieved successfully",
                    ErrorMessage = null
                };
            }
            catch(Exception ex)
            {
                return new ApiResponse<ToDoItemResponseDto>()
                {
                    Success = false,
                    Data = null,
                    Message = "To-Do item retrieve un-successfull",
                    ErrorMessage = null
                };

            }
        }

        public async Task<ApiResponse<ToDoItem>> AddToDoItemAsync(ToDoItemRequestDto toDoRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(toDoRequest.Title))
                {
                    toDoRequest.Title = "Default Title";  // Example default title
                }

                if (string.IsNullOrEmpty(toDoRequest.Description))
                {
                    toDoRequest.Description = "No description provided.";
                }

                var toDoItem = new ToDoItem
                {
                    Title = toDoRequest.Title,
                    Description = toDoRequest.Description,
                    IsCompleted = toDoRequest.IsCompleted,
                    CreateDate = DateTime.UtcNow  // Set CreateDate when adding a new item
                };

                await _toDoItemRepository.AddAsync(toDoItem);
                return new ApiResponse<ToDoItem>()
                {
                    Success = true,
                    Data = toDoItem,
                    Message = "To-Do item added successfully",
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ToDoItem>()
                {
                    Success = false,
                    Data = null,
                    Message = "To-Do item add un-successfull",
                    ErrorMessage = null
                };
            }
        }

        public async Task<ApiResponse<ToDoItem>> UpdateToDoItemAsync(int id, ToDoItemRequestDto toDoRequest)
        {
            try
            {
                var existingToDoItem = await _toDoItemRepository.GetByIdAsync(id);
                if (existingToDoItem == null)
                {
                    return new ApiResponse<ToDoItem>()
                    {
                        Success = false,
                        Message = $"To-Do item with ID {id} not found",
                        Data = null,
                        ErrorMessage = null,
                    };
                }

                // Update properties
                existingToDoItem.Title = string.IsNullOrEmpty(toDoRequest.Title) ? "Default Title" : toDoRequest.Title;
                existingToDoItem.Description = string.IsNullOrEmpty(toDoRequest.Description) ? "No description provided." : toDoRequest.Description;
                existingToDoItem.IsCompleted = toDoRequest.IsCompleted;

                await _toDoItemRepository.UpdateAsync(existingToDoItem);

                return new ApiResponse<ToDoItem>()
                {
                    Success = true,
                    Data = existingToDoItem,  // Return the updated item here
                    Message = "To-Do item updated successfully",
                    ErrorMessage = null,
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ToDoItem>()
                {
                    Success = true,
                    Data = null,  // Return the updated item here
                    Message = "To-Do item update un-successfull",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<ApiResponse<string>> DeleteToDoItemAsync(int id)
        {
            try
            {
                var existingToDoItem = await _toDoItemRepository.GetByIdAsync(id);
                if (existingToDoItem == null)
                {
                    return new ApiResponse<string>()
                    {
                        Success = false,
                        Message = $"To-Do item with ID {id} not found",
                        Data = null,
                        ErrorMessage = null,
                    };
                }

                await _toDoItemRepository.DeleteAsync(id);
                return new ApiResponse<string>()
                {
                    Success = true,
                    Message = "To-Do item deleted successfully",
                    Data = null,
                    ErrorMessage = null,
                };
            }
            catch (Exception ex) {
                return new ApiResponse<string>()
                {
                    Success = false,
                    Data = null,
                    Message = "To-Do item delete un-successfull",
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
