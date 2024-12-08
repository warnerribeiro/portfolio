namespace Commom
{
    using Commom.Exceptions;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Enum de segmento do aluno
    /// </summary>
    public enum Segment
    {
        [Description("Fundamental")]
        fundamental,

        [Description("Infantil")]
        infantile
    }

    /// <summary>
    /// Metodos de exntensão para enuns
    /// </summary>
    public static class SegmentExtensions
    {
        /// <summary>
        /// Recupera a descrição do enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T enumValue)
             where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }

        /// <summary>
        /// Recupera a descrição do enum
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum e)
        {
            var attribute =
                e.GetType()
                    .GetTypeInfo()
                    .GetMember(e.ToString())
                    .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault()
                    as DescriptionAttribute;

            return attribute?.Description ?? e.ToString();
        }

        /// <summary>
        /// Recupera o segmento apartir de uma string
        /// </summary>
        /// <param name="enumDescription"></param>
        /// <returns></returns>
        /// <exception cref="SegmentNotSupported"></exception>
        public static Segment GetEnum(this string enumDescription)
        {
            switch (enumDescription)
            {
                case "Fundamental":
                    return Segment.fundamental;

                case "Infantil":
                    return Segment.infantile;

                default:
                    throw new SegmentNotSupported();
            }
        }
    }
}