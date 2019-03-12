using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentSheet.Models
{
    public enum UnitType
    {
        [Description("District 1")] District1,
        [Description("District 2")] District2,
        [Description("Distirct 3")] District3,
        [Description("District 4")] District4,
        [Description("District 5")] District5,
        [Description("District 6")] District6,
        [Description("Homicde")] Homicide,
        [Description("Traffic Safety")] Traffic,
        [Description("SWAT/Mobile Reserve")] SWAT,
        [Description("Sex Crimes")] SexCrimes,
        [Description("Child Abuse")] ChildAbuse,
        [Description("Cyber Crimes")] CyberCrimes,
        [Description("Juvenile")] Juvenile,
        [Description("Bomb and Arson")] BombandArson,
        [Description("Intellgence")] Intellgence,
        [Description("Domestic Abuse Unit")] DART,
        [Description("Housing Unit")] Housing,
        [Description("Narcotics Unit")] Narcotics,
        [Description("AntiCrime")] AntiCrime,
        [Description("Out of Jurisdition")] County


    }
}
