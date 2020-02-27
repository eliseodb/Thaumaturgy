using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Thaumaturgy.Clases
{
    public enum ShotGraphics
    {
        DS_BALL_SS_RED,
        DS_BALL_SS_ORANGE,
        DS_BALL_SS_YELLOW,
        DS_BALL_SS_GREEN,
        DS_BALL_SS_SKY,
        DS_BALL_SS_BLUE,
        DS_BALL_SS_PURPLE,
        DS_BALL_SS_WHITE,
        DS_BALL_S_RED,
        DS_BALL_S_ORANGE,
        DS_BALL_S_YELLOW,
        DS_BALL_S_GREEN,
        DS_BALL_S_SKY,
        DS_BALL_S_BLUE,
        DS_BALL_S_PURPLE,
        DS_BALL_S_WHITE,
        DS_BALL_S_A_RED,
        DS_BALL_S_A_ORANGE,
        DS_BALL_S_A_YELLOW,
        DS_BALL_S_A_GREEN,
        DS_BALL_S_A_SKY,
        DS_BALL_S_A_BLUE,
        DS_BALL_S_A_PURPLE,
        DS_BALL_S_A_WHITE,
        DS_BALL_BS_RED,
        DS_BALL_BS_ORANGE,
        DS_BALL_BS_YELLOW,
        DS_BALL_BS_GREEN,
        DS_BALL_BS_SKY,
        DS_BALL_BS_BLUE,
        DS_BALL_BS_PURPLE,
        DS_BALL_BS_WHITE,
        DS_BALL_M_RED,
        DS_BALL_M_ORANGE,
        DS_BALL_M_YELLOW,
        DS_BALL_M_GREEN,
        DS_BALL_M_SKY,
        DS_BALL_M_BLUE,
        DS_BALL_M_PURPLE,
        DS_BALL_M_WHITE,
        DS_BALL_M_A_RED,
        DS_BALL_M_A_ORANGE,
        DS_BALL_M_A_YELLOW,
        DS_BALL_M_A_GREEN,
        DS_BALL_M_A_SKY,
        DS_BALL_M_A_BLUE,
        DS_BALL_M_A_PURPLE,
        DS_BALL_M_A_WHITE,
        DS_NEEDLE_RED,
        DS_NEEDLE_ORANGE,
        DS_NEEDLE_YELLOW,
        DS_NEEDLE_GREEN,
        DS_NEEDLE_SKY,
        DS_NEEDLE_BLUE,
        DS_NEEDLE_PURPLE,
        DS_NEEDLE_WHITE,
        DS_RICE_S_RED,
        DS_RICE_S_ORANGE,
        DS_RICE_S_YELLOW,
        DS_RICE_S_GREEN,
        DS_RICE_S_SKY,
        DS_RICE_S_BLUE,
        DS_RICE_S_PURPLE,
        DS_RICE_S_WHITE,
        DS_ICE_RED,
        DS_ICE_ORANGE,
        DS_ICE_YELLOW,
        DS_ICE_GREEN,
        DS_ICE_SKY,
        DS_ICE_BLUE,
        DS_ICE_PURPLE,
        DS_ICE_WHITE,
        DS_MISSILE_RED,
        DS_MISSILE_ORANGE,
        DS_MISSILE_YELLOW,
        DS_MISSILE_GREEN,
        DS_MISSILE_SKY,
        DS_MISSILE_BLUE,
        DS_MISSILE_PURPLE,
        DS_MISSILE_WHITE,
        DS_RICE_M_RED,
        DS_RICE_M_ORANGE,
        DS_RICE_M_YELLOW,
        DS_RICE_M_GREEN,
        DS_RICE_M_SKY,
        DS_RICE_M_BLUE,
        DS_RICE_M_PURPLE,
        DS_RICE_M_WHITE,
        DS_KUNAI_RED,
        DS_KUNAI_ORANGE,
        DS_KUNAI_YELLOW,
        DS_KUNAI_GREEN,
        DS_KUNAI_SKY,
        DS_KUNAI_BLUE,
        DS_KUNAI_PURPLE,
        DS_KUNAI_WHITE,
        DS_SCALE_RED,
        DS_SCALE_ORANGE,
        DS_SCALE_YELLOW,
        DS_SCALE_GREEN,
        DS_SCALE_SKY,
        DS_SCALE_BLUE,
        DS_SCALE_PURPLE,
        DS_SCALE_WHITE,
        DS_SCALE_A_RED,
        DS_SCALE_A_ORANGE,
        DS_SCALE_A_YELLOW,
        DS_SCALE_A_GREEN,
        DS_SCALE_A_SKY,
        DS_SCALE_A_BLUE,
        DS_SCALE_A_PURPLE,
        DS_SCALE_A_WHITE,
        DS_BILL_RED,
        DS_BILL_ORANGE,
        DS_BILL_YELLOW,
        DS_BILL_GREEN,
        DS_BILL_SKY,
        DS_BILL_BLUE,
        DS_BILL_PURPLE,
        DS_BILL_WHITE,
        DS_COIN_RED,
        DS_COIN_ORANGE,
        DS_COIN_YELLOW,
        DS_COIN_GREEN,
        DS_COIN_SKY,
        DS_COIN_BLUE,
        DS_COIN_PURPLE,
        DS_COIN_WHITE,
        DS_BUTTERFLY_RED,
        DS_BUTTERFLY_ORANGE,
        DS_BUTTERFLY_YELLOW,
        DS_BUTTERFLY_GREEN,
        DS_BUTTERFLY_SKY,
        DS_BUTTERFLY_BLUE,
        DS_BUTTERFLY_PURPLE,
        DS_BUTTERFLY_WHITE,
        DS_LIGHT_RED,
        DS_LIGHT_ORANGE,
        DS_LIGHT_YELLOW,
        DS_LIGHT_GREEN,
        DS_LIGHT_SKY,
        DS_LIGHT_BLUE,
        DS_LIGHT_PURPLE,
        DS_LIGHT_WHITE,
        DS_STAR_S_RED,
        DS_STAR_S_ORANGE,
        DS_STAR_S_YELLOW,
        DS_STAR_S_GREEN,
        DS_STAR_S_SKY,
        DS_STAR_S_BLUE,
        DS_STAR_S_PURPLE,
        DS_STAR_S_WHITE,
        DS_STAR_M_RED,
        DS_STAR_M_ORANGE,
        DS_STAR_M_YELLOW,
        DS_STAR_M_GREEN,
        DS_STAR_M_SKY,
        DS_STAR_M_BLUE,
        DS_STAR_M_PURPLE,
        DS_STAR_M_WHITE,
        DS_KNIFE_YOUMU_RED,
        DS_KNIFE_YOUMU_ORANGE,
        DS_KNIFE_YOUMU_YELLOW,
        DS_KNIFE_YOUMU_GREEN,
        DS_KNIFE_YOUMU_SKY,
        DS_KNIFE_YOUMU_BLUE,
        DS_KNIFE_YOUMU_PURPLE,
        DS_KNIFE_YOUMU_WHITE,
        DS_KNIFE_KOUMA_RED,
        DS_KNIFE_KOUMA_ORANGE,
        DS_KNIFE_KOUMA_YELLOW,
        DS_KNIFE_KOUMA_GREEN,
        DS_KNIFE_KOUMA_SKY,
        DS_KNIFE_KOUMA_BLUE,
        DS_KNIFE_KOUMA_PURPLE,
        DS_KNIFE_KOUMA_WHITE,
        DS_BEAM_RED,
        DS_BEAM_ORANGE,
        DS_BEAM_YELLOW,
        DS_BEAM_GREEN,
        DS_BEAM_SKY,
        DS_BEAM_BLUE,
        DS_BEAM_PURPLE,
        DS_BEAM_WHITE,
        DS_BEAM_RAINBOW,
        DS_FIRE_RED,
        DS_FIRE_BLUE,
        DS_TABLET,
        DS_BALL_L_RED,
        DS_BALL_L_ORANGE,
        DS_BALL_L_YELLOW,
        DS_BALL_L_GREEN,
        DS_BALL_L_SKY,
        DS_BALL_L_BLUE,
        DS_BALL_L_PURPLE,
        DS_BALL_L_WHITE,
        DS_BALL_S_R_WHITE,
        DS_BALL_S_R_RED,
        DS_BALL_S_R_PURPLE,
        DS_BALL_S_R_BLUE,
        DS_BALL_BS_R_WHITE,
        DS_BALL_BS_R_RED,
        DS_BALL_BS_R_PURPLE,
        DS_BALL_BS_R_BLUE,
        DS_BALL_M_R_WHITE,
        DS_BALL_M_R_RED,
        DS_BALL_M_R_PURPLE,
        DS_BALL_M_R_BLUE,
        DS_NEEDLE_R_WHITE,
        DS_NEEDLE_R_RED,
        DS_NEEDLE_R_PURPLE,
        DS_NEEDLE_R_BLUE,
        DS_RICE_S_R_WHITE,
        DS_RICE_S_R_RED,
        DS_RICE_S_R_PURPLE,
        DS_RICE_S_R_BLUE,
        DS_ICE_R_WHITE,
        DS_ICE_R_RED,
        DS_ICE_R_PURPLE,
        DS_ICE_R_BLUE,
        DS_MISSILE_R_WHITE,
        DS_MISSILE_R_RED,
        DS_MISSILE_R_PURPLE,
        DS_MISSILE_R_BLUE,
        DS_RICE_M_R_WHITE,
        DS_RICE_M_R_RED,
        DS_RICE_M_R_PURPLE,
        DS_RICE_M_R_BLUE,
        DS_BUTTERFLY_R_WHITE,
        DS_BUTTERFLY_R_RED,
        DS_BUTTERFLY_R_PURPLE,
        DS_BUTTERFLY_R_BLUE,
        DS_LIGHT_R_WHITE,
        DS_LIGHT_R_RED,
        DS_LIGHT_R_PURPLE,
        DS_LIGHT_R_BLUE,
        DS_STAR_S_R_WHITE,
        DS_STAR_S_R_RED,
        DS_STAR_S_R_PURPLE,
        DS_STAR_S_R_BLUE,
        DS_STAR_M_R_WHITE,
        DS_STAR_M_R_RED,
        DS_STAR_M_R_PURPLE,
        DS_STAR_M_R_BLUE,
        DS_BEAM_R_WHITE,
        DS_BEAM_R_RED,
        DS_BEAM_R_PURPLE,
        DS_BEAM_R_BLUE,
        DS_TENGU,
        DS_JUDGMENT
    }

    public class ShotGraphicsConverter : EnumConverter
    {
        private Type _enumType;
        /// <summary />Initializing instance</summary />
        /// <param name=""type"" />type Enum</param />
        /// this is only one function, that you must
        /// change. All another functions for enums
        /// you can use by Ctrl+C/Ctrl+V
        public ShotGraphicsConverter(Type type)
            : base(type)
        {
            _enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context,
            Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture,
            object value, Type destType)
        {
            FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, value));
            DescriptionAttribute dna =
                (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

            if (dna != null)
                return dna.Description;
            else
                return value.ToString();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context,
            Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture,
            object value)
        {
            foreach (FieldInfo fi in _enumType.GetFields())
            {
                DescriptionAttribute dna =
                (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(_enumType, fi.Name);
            }
            return Enum.Parse(_enumType, (string)value);
        }
    }
}
