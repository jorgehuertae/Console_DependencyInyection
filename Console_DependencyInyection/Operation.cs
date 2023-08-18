using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_DependencyInyection
{
    public abstract class Operation : ISingleton, IScoped, ITransient
    {
        private Guid _operationId;
        private string _lifeTime;

        public Operation(string lifeTime)
        {
            _operationId = Guid.NewGuid();
            _lifeTime = lifeTime;

            Console.WriteLine($"{_lifeTime} Service Created.");
        }

        public void Info()
        {
            Console.WriteLine($"{_lifeTime}: {_operationId}");
        }
    }
}
