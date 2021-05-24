using System;
using System.Collections.Generic;
using System.Data;
using burgershack.Interfaces;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
  public class SidesRepository : IRepo<Side>
  {
    private readonly IDbConnection _db;

    public SidesRepository(IDbConnection db)
    {
      _db = db;

    }

    internal Side Create(Side newSide)
    {
      string sql = @"
        INSERT INTO sides
            (name, cost, quantity, modifications, itemType)
            VALUES
            (@Name, @Cost, @Quantity, @Modifications, @ItemType)
            SELECT LAST_INSERT_ID()";
      newSide.Id = _db.ExecuteScalar<int>(sql, newSide);
      return newSide;
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM sides WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

    public IEnumerable<Side> GetAll()
    {
      string sql = "SELECT * FROM sides";
      return _db.Query<Side>(sql);
    }

    public Side GetById(int id)
    {
      throw new System.NotImplementedException();
    }


    bool IRepo<Side>.Update(Side data)
    {
      throw new System.NotImplementedException();
    }
  }

}