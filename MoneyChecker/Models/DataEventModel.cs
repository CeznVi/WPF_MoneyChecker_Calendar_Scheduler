using MoneyChecker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.Models
{
    public class DataEventModel
    {
        private SQLiteDbContext _dbContext;

        public DataEventModel(SQLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DateEvent> GetAllDataEvent()
        {
            return _dbContext.DateEvent.OrderBy(d => d.Id).ToList();
        }

        public List<DateEvent> GetDataEventByDate(DateTime date)
        {
            return _dbContext.DateEvent.Where(d => d.Date.Date == date.Date).ToList();
        }


        public DateEvent GetDateEventById(int Id)
        {
            return _dbContext.DateEvent.FirstOrDefault(c => c.Id == Id);
        }

        public bool AddNewDateEvent(DateEvent dateEvent)
        {
            _dbContext.DateEvent.Add(dateEvent);
            return _dbContext.SaveChanges() == 1 ? true : false;                   //синхронизация - сохранение в файл
        }

        public bool DeleteDateEvent(DateEvent dateEvent)
        {

            _dbContext.DateEvent.Remove(dateEvent);
            return _dbContext.SaveChanges() == 1 ? true : false;                   //синхронизация - сохранение в файл

        }

        public bool EditDateEvent(DateEvent dateEvent)
        {
            _dbContext.DateEvent.Update(dateEvent);
            return _dbContext.SaveChanges() == 1 ? true : false;                   //синхронизация - сохранение в файл

        }

    }
}
