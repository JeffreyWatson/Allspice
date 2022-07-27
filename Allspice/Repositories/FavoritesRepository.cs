using System.Data;
using Allspice.Models;
using Dapper;

namespace Allspice.Repositories
{
  public class FavoritesRepository
  {
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Favorite foundFavorite(Favorite favoriteData)
    {
      string sql = "SELECT * FROM favorites WHERE recipeId = @RecipeId AND accountId = @AccountId";
      return _db.QueryFirstOrDefault<Favorite>(sql, favoriteData);
    }

    internal Favorite GetById(int id)
    {
      string sql = @"
      SELECT *
      FROM favorites
      WHERE id = @id
      ";
      return _db.QueryFirstOrDefault<Favorite>(sql, new { id });
    }

    internal Favorite Create(Favorite favoriteData)
    {
      string sql = @"
      INSERT INTO favorites
      (accountId, recipeId)
      VALUES
      (@AccountId, @RecipeId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, favoriteData);
      favoriteData.Id = id;
      return favoriteData;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM favorites WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}