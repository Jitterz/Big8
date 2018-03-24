using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big8_MAIN
{
    [Serializable]
    class SavedPublicVariables
    {
        // this is the default week
        public string GetDefaultWeek { get; set; }

        // this is the default season
        public string GetDefaultSeason { get; set; }
    }
}
