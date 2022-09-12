using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRainParks.Domain.Interfaces
{
    public interface IConfig
    {
        string GetConnectionString(string connectionStringName);
    }
}
