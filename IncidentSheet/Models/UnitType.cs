using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace IncidentSheet.Models
{
    public enum UnitType
    {
        [Display(Name ="District 1")]
        District1 = 1,
        [Display(Name ="District 2")]
        District2 = 2,
        [Display(Name ="Distirct 3")]
        District3 = 3,
        [Display(Name ="District 4")]
        District4 = 4,
        [Display(Name = "District 5")]
        District5 = 5,
        [Display(Name ="District 6")]
        District6 = 6,
        [Display(Name = "Homicde")]
        Homicide = 7,
        [Display(Name = "Traffic Safety")]
        Traffic = 8,
        [Display(Name = "SWAT/Mobile Reserve")]
        SWAT = 9,
        [Display(Name = "Sex Crimes")]
        SexCrimes = 10,
        [Display(Name = "Child Abuse")]
        ChildAbuse = 11,
        [Display(Name = "Cyber Crimes")]
        CyberCrimes = 12,
        [Display(Name = "Juvenile")]
        Juvenile = 13,
        [Display(Name = "Bomb and Arson")]
        BombandArson = 14,
        [Display(Name = "Intellgence")]
        Intellgence = 15,
        [Display(Name = "Domestic Abuse Unit")]
        DART = 16,
        [Display(Name = "Housing Unit")]
        Housing = 17,
        [Display(Name = "Narcotics Unit")]
        Narcotics = 18,
        [Display(Name = "AntiCrime")]
        AntiCrime = 19,
        [Display(Name = "Out of Jurisdition")]
        County = 20
    }
    public static class UnitTypeExtension
    {
        public static string GetDisplayName(this Enum unitname)
        {
            Type type = unitname.GetType();
            MemberInfo[] memInfo = type.GetMember(unitname.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DisplayAttribute)attrs[0]).Name;
                }
            }
            return unitname.ToString();
        }
    }
}
