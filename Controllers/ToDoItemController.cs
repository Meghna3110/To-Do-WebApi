using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DTO;
using ToDoList.Model;
using ToDoList.Service;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        // GET: api/ToDoItem
        [HttpGet("GetAllToDoItems")]
        public async Task<ActionResult<List<ToDoItemResponseDto>>> GetAllToDoItems()
        {
            //var toDoItems = await _toDoItemService.GetAllToDoItemsAsync();
            //return Ok(new ApiResponse<List<ToDoItemResponseDto>>
            //{
            //    Success = true,
            //    Data = toDoItems,
            //    Message = "To-Do items retrieved successfully"
            //});
            var result = await _toDoItemService.GetAllToDoItemsAsync();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest();
        }

        // GET: api/ToDoItem/{id}
        [HttpGet("GetToDoItemById/{id}")]
        public async Task<ActionResult<ToDoItemResponseDto>> GetToDoItemById(int id)
        {
            //var toDoItem = await _toDoItemService.GetToDoByIdAsync(id);
            //if (toDoItem == null)
            //{
            //    return NotFound(new ApiResponse<ToDoItemResponseDto>
            //    {
            //        Success = false,
            //        Message = $"To-Do item with ID {id} not found"
            //    });
            //}

            //return Ok(new ApiResponse<ToDoItemResponseDto>
            //{
            //    Success = true,
            //    Data = toDoItem,
            //    Message = "To-Do item retrieved successfully"
            //});
            var result = await _toDoItemService.GetToDoByIdAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return NotFound(result);
        }

        // POST: api/ToDoItem
        [HttpPost("AddToDoItem")]
        public async Task<IActionResult> AddToDoItem([FromBody] ToDoItemRequestDto toDoRequest)
        {
            var result = await _toDoItemService.AddToDoItemAsync(toDoRequest);
            //return Ok(new ApiResponse<string>
            //{
            //    Success = true,
            //    Message = "To-Do item added successfully"
            //});
            if (result.Success)
            return Ok(result);
            else
            return BadRequest();
        }

        // PUT: api/ToDoItem/{id}
        [HttpPut("UpdateToDoItem")]
        public async Task<IActionResult> UpdateToDoItem(int id, [FromBody] ToDoItemRequestDto toDoRequest)
        {
            //try
            //{
            //    await _toDoItemService.UpdateToDoItemAsync(id, toDoRequest);
            //    return Ok(new ApiResponse<string>
            //    {
            //        Success = true,
            //        Message = "To-Do item updated successfully"
            //    });
            //}
            //catch (KeyNotFoundException ex)
            //{
            //    return NotFound(new ApiResponse<string>
            //    {
            //        Success = false,
            //        Message = ex.Message
            //    });
            //}

            var result = await _toDoItemService.UpdateToDoItemAsync(id, toDoRequest);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE: api/ToDoItem/{id}
        [HttpDelete("DeleteToDoItem/{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            //await _toDoItemService.DeleteToDoItemAsync(id);
            //return Ok(new ApiResponse<string>
            //{
            //    Success = true,
            //    Message = "To-Do item deleted successfully"
            //});
            var result = await _toDoItemService.DeleteToDoItemAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return NotFound(result);
        }
    }
}
