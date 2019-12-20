using System.ComponentModel;

namespace TestSamples.LanguageChanging
{

    /// <summary>
    /// tag should exist in ResourceFile (LanguagePack.resx)
    /// </summary>
    public enum LanguageTypes
    {
        [Description("")]
        defaultLang,

        [Description("zh-TW")]
        zhTW
    }
}
