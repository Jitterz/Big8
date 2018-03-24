using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big8_MAIN
{
    static class PublicVariables
    {
        // used to house a player to open in the ledger window
        public static PlayersDBDataSet.PlayersRow PlayerPublicLedger { get; set; }

        // house the player when moving around the player windows.
        public static PlayersDBDataSet.PlayersRow PublicPlayer { get; set; }

        // this is the default week
        public static string GetDefaultWeek { get; set; }

        // this is the default season
        public static string GetDefaultSeason { get; set; }

        // this is for the transaction details
        public static int PublicTransactionId { get; set; }

    }
}
