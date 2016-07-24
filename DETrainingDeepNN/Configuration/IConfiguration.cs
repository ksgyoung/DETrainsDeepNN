using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.ConfigurationSettings
{
    public interface IConfiguration
    {
        string GetValue(String key);
    }
}
