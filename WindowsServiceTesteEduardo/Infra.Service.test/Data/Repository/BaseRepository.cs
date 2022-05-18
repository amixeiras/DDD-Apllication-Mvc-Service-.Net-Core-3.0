using Domain.Service.Test.Interface;
using System.Configuration;

namespace Infra.Service.test.Data.Repository
{

    public class BaseRepository
    {
        public ILogArquivo _log;
        public string ConnectionString { get => Domain.Service.Test.Helper.ConnectionHelper.ConnectionString; }
    }
}
