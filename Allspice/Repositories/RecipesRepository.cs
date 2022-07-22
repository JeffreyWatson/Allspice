using System.Collections.Generic;
using System.Data;
using System.Linq;
using Allspice.Models;
using Dapper;

namespace Allspice.Repositories
{
  public class RecipesRepository
  {

    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Recipe> Get()
    {
      string sql = @"
      SELECT
      r.*,
      a.*
      FROM recipes r
      JOIN accounts a ON r.creatorId = a.id;";
      return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
      {
        recipe.Creator = profile;
        return recipe;
      }).ToList();
    }

    internal Recipe GetById(int recipeId)
    {
      string sql = @"
      SELECT
      r.*,
      a.*
      FROM recipes r
      JOIN accounts a ON r.creatorId = a.id
      WHERE r.id = @recipeId";
      return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
      {
        recipe.Creator = profile;
        return recipe;
      }, new { recipeId }).FirstOrDefault();
    }

    internal Recipe Create(Recipe recipeData)
    {
      string sql = @"
      INSERT INTO recipes
      (picture, title, subtitle, category, creatorId)
      VALUES
      (@Picture, @Title, @Subtitle, @Category, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, recipeData);
      recipeData.Id = id;
      return recipeData;
    }

    internal void Edit(Recipe original)
    {
      string sql = @"
      UPDATE recipes
      SET
        picture = @Picture,
        title = @Title,
        subtitle = @Subtitle,
        category = @Category
        WHERE id = @id
      ";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM recipes WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}