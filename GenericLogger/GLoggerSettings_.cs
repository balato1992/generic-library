using GenericModel.Settings;
using System;
using System.Linq.Expressions;

namespace GenericLogger
{
    //public class GLoggerSettings_
    //{
    //    private GenericAppSetting _AppSetting { get; set; }

    //    public bool FileEncryption
    //    {
    //        get { return _AppSetting.Get(_GetDesignName(() => this.FileEncryption), false); }
    //        set { _AppSetting.Set(_GetDesignName(() => this.FileEncryption), value); }
    //    }

    //    public string FileEncryptionKey
    //    {
    //        get { return _AppSetting.Get(_GetDesignName(() => this.FileEncryptionKey), "12345678901234567890123456789012"); }
    //        set { _AppSetting.Set(_GetDesignName(() => this.FileEncryptionKey), value); }
    //    }

    //    public string FileEncryptionIV
    //    {
    //        get { return _AppSetting.Get(_GetDesignName(() => this.FileEncryptionIV), "1234567890abcdef"); }
    //        set { _AppSetting.Set(_GetDesignName(() => this.FileEncryptionIV), value); }
    //    }

    //    public string FolderPath
    //    {
    //        get { return _AppSetting.Get(_GetDesignName(() => this.FolderPath), AppDomain.CurrentDomain.BaseDirectory + @"App_Data\Log\"); }
    //        set { _AppSetting.Set(_GetDesignName(() => this.FolderPath), value); }
    //    }

    //    public GLoggerSettings_()
    //    {
    //        _AppSetting = new GenericAppSetting();
    //    }

    //    public void Save()
    //    {
    //        _AppSetting.Save();
    //    }

    //    private string _GetDesignName<T>(Expression<Func<T>> propertyExpression)
    //    {
    //        var propName = (propertyExpression.Body as MemberExpression).Member.Name;
    //        return propName;
    //    }

    //    //public string FolderPath
    //    //{
    //    //    get
    //    //    {
    //    //        return (string)_Settings.Get(LoggerItemNames.FolderPath.ToString());
    //    //    }

    //    //    set
    //    //    {
    //    //        _Settings.Set(LoggerItemNames.FolderPath.ToString(), value);
    //    //    }
    //    //}
    //    //public int UserLevel
    //    //{
    //    //    get
    //    //    {
    //    //        return (int)_Settings.Get(LoggerItemNames.UserLevel.ToString());
    //    //    }

    //    //    set
    //    //    {
    //    //        _Settings.Set(LoggerItemNames.UserLevel.ToString(), value);
    //    //    }
    //    //}
    //}
}