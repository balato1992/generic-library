using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace TestSamples.LanguageChanging
{
    public class LanguageHelper
    {
        /// <summary>
        /// for singleton instance
        /// </summary>
        public static LanguageHelper Instance { get; } = new LanguageHelper(true);

        private LanguageHelper(bool checkTags)
        {
            if (checkTags)
            {
                List<string> innormalTags = this.CheckTags();

                if (innormalTags.Count > 0)
                {
                    string tags = string.Join(", ", innormalTags);

                    throw new Exception("These tag may have some problem: " + tags + ".");
                }
            }
        }


        private LanguageTypes m_LanguageType = LanguageTypes.defaultLang;

        public List<string> CheckTags()
        {
            List<string> innormalTags = new List<string>();

            foreach (MessageTags name in Enum.GetValues(typeof(MessageTags)))
            {
                string messageTag = name.ToString();
                string messageString = this._GetString(messageTag);

                // if the two string is equal, it sholud be innormal state
                if (messageTag.Equals(messageString))
                {
                    innormalTags.Add(messageTag);
                }
            }

            return innormalTags;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">tag: zh-TW, en...</param>
        public void SetLanguage(LanguageTypes language)
        {
            this.m_LanguageType = language;
        }

        public string GetLanguageName()
        {
            return ReflectionHelper.GetDescription(this.m_LanguageType);
        }

        /// <summary>
        /// get string from current ResourceManager and culture
        /// </summary>
        /// <param name="sourceString">target string</param>
        /// <returns>A string from input info, if string is null or empty, it will return 'sourceString'</returns>
        private string _GetString(string sourceString)
        {
            ResourceManager rm = new ResourceManager("TestSamples.LanguageChanging.ResourcesOfLanguage.LanguagePack", Assembly.GetExecutingAssembly());
            string cultureName = this.GetLanguageName();
            CultureInfo culture = new CultureInfo(cultureName);

            string stringInLanguage = this._GetStringFromResourceManager(rm, sourceString, culture);

            return stringInLanguage;
        }


        /// <summary>
        /// Get string from ResourceManager (LanguagePack.resx)
        /// </summary>
        /// <param name="rm">ResourceManager</param>
        /// <param name="sourceString">target string</param>
        /// <param name="culture">CultureInfo</param>
        /// <returns>A string from input info, if string is null or empty, it will return 'sourceString'</returns>
        private string _GetStringFromResourceManager(ResourceManager rm, string sourceString, CultureInfo culture)
        {
            string stringInLanguage = rm.GetString(sourceString, culture);

            // If string do not exist
            if (string.IsNullOrEmpty(stringInLanguage))
            {
                // then return original string
                stringInLanguage = sourceString;
            }

            return stringInLanguage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string GetMessage(MessageTags tag)
        {
            return this._GetString(tag.ToString());
        }
    }
}
