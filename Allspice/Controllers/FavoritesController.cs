using System;
using System.Threading.Tasks;
using Allspice.Models;
using Allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FavoriteController : ControllerBase
  {
    private readonly FavoritesService _fs;

    public FavoriteController(FavoritesService fs)
    {
      _fs = fs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> Create([FromBody] Favorite favoriteData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        favoriteData.AccountId = userInfo.Id;
        Favorite newFavorite = _fs.Create(favoriteData);
        return Ok(newFavorite);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Favorite>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _fs.Delete(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Favorite> Get(int id)
    {
      try
      {
        Favorite favorite = _fs.GetById(id);
        return Ok(favorite);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}