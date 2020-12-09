using System;
using System.Collections.Generic;
using System.Text;

namespace CTGP_GUI.Classes
{
    public enum NintendoConsole { Wii, WiiU, NoSelection}
    public enum Channel { CTGPR, Homebrew, Riivolution, None, NoSelection }
    public enum Exploit { BannerbombOld, Bannerbomb, Letterbomb, Wuphax, SmashStack, ReturnOfTheJodi, Bathaxx, IndianaPwns, NoSelection }

    public class Questionnaire
    {
        // FIELDS
        public bool LicenseAccepted { get; set; }
        public NintendoConsole Console { get; set; }
        public Channel Channel { get; set; }
        public Exploit Exploit { get; set; }
        public string Drive { get; set; }

    }
}
