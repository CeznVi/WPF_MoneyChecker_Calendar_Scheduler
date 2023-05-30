using MoneyChecker.Entities;
using MoneyChecker.Models;

namespace MoneyChecker.ViewsModels
{

    public class MainWindowViewModel
    {
        private SQLiteDbContext _sQLiteDbContext;
        public CategoryViewModel CategoryViewModel;
        public DataEventModel DataEventModel;

        public MainWindowViewModel(SQLiteDbContext qLiteDbContext)
        {
            _sQLiteDbContext = qLiteDbContext;
            CategoryViewModel = new CategoryViewModel(_sQLiteDbContext);
            DataEventModel = new DataEventModel(_sQLiteDbContext);
        }
    }

}
