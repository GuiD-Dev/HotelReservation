using HotelReservation.Application.DTOs;
using HotelReservation.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelController(IHotelService hotelService) : ControllerBase
{
  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var hotels = await hotelService.GetAllHotelsAsync();
    return Ok(hotels);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    try
    {
      var hotel = await hotelService.GetHotelByIdAsync(id);
      return Ok(hotel);
    }
    catch (Exception ex)
    {
      return NotFound(ex.Message);
    }
  }

  [HttpPost]
  public async Task<IActionResult> Create(HotelCreateRequest request)
  {
    try
    {
      var createdHotel = await hotelService.CreateHotelAsync(request);
      return Created($"api/hotel/{createdHotel.Id}", createdHotel);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, HotelUpdateRequest request)
  {
    try
    {
      var updatedHotel = await hotelService.UpdateHotelAsync(id, request);
      return Ok(updatedHotel);
    }
    catch (Exception ex) when (ex is InvalidOperationException)
    {
      return NotFound(ex.Message);
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      await hotelService.DeleteHotelAsync(id);
      return NoContent();
    }
    catch (Exception ex) when (ex is InvalidOperationException)
    {
      return NotFound(ex.Message);
    }
  }
}
