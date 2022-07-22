using System.Collections.Generic;
using System.Data;
using System.Linq;
using Allspice.Models;
using Dapper;

namespace Allspice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Ingredient Create(Ingredient ingredientData)
    {
      string sql = @"
      INSERT INTO ingredients
      (name, quantity)
      VALUES
      (@Name, @Quantity);
      SELECT LAST_INSERT_ID();";

      int id = _db.ExecuteScalar<int>(sql, ingredientData);
      ingredientData.Id = id;
      return ingredientData;
    }

    internal List<Ingredient> GetByRecipeId(int recipeId)
    {
      string sql = "SELECT * FROM ingredients WHERE recipeId = @recipeId";
      return _db.Query<Ingredient>(sql, new { recipeId }).ToList();
    }

    // internal void Delete(int id)
    // {
    //   string sql = "DELETE FROM ingredients WHERE id = @id LIMIT 1";
    //   _db.Execute(sql, new { id });
    // }
  }
}