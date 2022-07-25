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

    internal Favorite Create(Favorite favoriteData)
    {
      Favorite found = this.GetFavorite(favoriteData);
      if (found != null)
      {
        int id = found.Id;
        this.Delete(id);
        return found;
      }
      _repo.Create(favoriteData);
      return (favoriteData);
    }

    internal Favorite GetFavorite(Favorite favoriteData)
    {
      Favorite found = _repo.GetFavorite(favoriteData);
      return found;
    }

    internal Favorite Delete(int id)
    {
      Favorite original = new Favorite();
      original.Id = id;
      _repo.Delete(original);
      throw new Exception("Un-Favorited.");
    }
  }
}