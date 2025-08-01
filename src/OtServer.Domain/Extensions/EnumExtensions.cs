﻿using System.Reflection;
using OtServer.Domain.Enums;

namespace OtServer.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            if (GenericEnum is null)
                return null;

            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }

            return GenericEnum.ToString();
        }

        public static string GetVocationName(this int vocationId)
        {
            if (Enum.IsDefined(typeof(VocationEnum), vocationId))
            {
                return ((VocationEnum)vocationId).GetDescription();
            }
            return "Unknown";
        }
    }
}
