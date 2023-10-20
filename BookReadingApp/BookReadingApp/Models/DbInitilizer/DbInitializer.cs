using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingApp.Models.DbInitilizer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly DataContext _db;
        public DbInitializer(DataContext db)
        {
            _db = db;
        }
        public void Initialize()
        {
            //migration
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
