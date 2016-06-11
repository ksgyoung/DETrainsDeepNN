using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Selection.Interfaces
{
    public interface ISelectionStrategy
    {
        Individual Select(List<Individual> individuals);
    }
}
