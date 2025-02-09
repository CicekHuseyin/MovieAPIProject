using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Mvc;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.Model.Dtos.Categories;
using MovieProject.Model.Entities;
using MovieProject.Service.Abstracts;
using MovieProject.Service.Concretes;

namespace MovieProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    //Constructor arg injection

    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    //property Injection
    //public ICategoryService CategoryService { get; set; }


    [HttpPost("Add")]
    public IActionResult Add(CategoryAddRequestDto dto)
    {
        try
        {
            _categoryService.Add(dto);
            return Ok("Kategori Başarıyla Eklendi");
        }
        catch (BusinessException ex)
        {

            return BadRequest(ex.Message);
        }

    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var response = _categoryService.GetAll();
        return Ok(response);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(int id)
    {
        try
        {
            var response = _categoryService.GetById(id);
            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }


    }

    [HttpPut("Update")]
    public IActionResult Update(CategoryUpdateRequestDto dto)
    {
        try
        {
            _categoryService.Update(dto);
            return Ok("Kategori Başarıyla Güncellendi");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

    }

    [HttpDelete("Delete")]
    public IActionResult Delete(int id)
    {
        try
        {
            _categoryService.Delete(id);
            return Ok("Kategori Başarıyla Silindi");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

    }

}
