using System;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
  public class FavoritesService
  {
    private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
      _repo = repo;
    }

    internal Favorite GetById(int id)
    {
      Favorite found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Favorite Create(Favorite favoriteData)
    {
      Favorite found = _repo.foundFavorite(favoriteData);
      if (found != null)
      {
        return found;
      }
      return _repo.Create(favoriteData);
    }

    internal void Delete(int id, string userId)
    {
      Favorite toDelete = GetById(id);
      if (toDelete.AccountId != userId)
      {
        throw new Exception("Invalid Action");
      }
      _repo.Delete(id);
    }
  }
}