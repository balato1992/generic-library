using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace GenericModel.Settings
{
    public sealed class GenericAppSetting : ApplicationSettingsBase
    {
        #region

        // this property is not used, but it is necessary
        // use this region to make Providers["LocalFileSettingsProvider"] exist when construct
        // find how to create Providers["LocalFileSettingsProvider"] to resolve this
        [UserScopedSetting()]
        public bool HelpProviders
        {
            get
            {
                return ((bool)this["HelpProviders"]);
            }
            set
            {
                this["HelpProviders"] = (bool)value;
            }
        }

        #endregion
        public GenericAppSetting() { }
        
        public T Get<T>(string key, T defaultValue)
        {
            if (!_IsPropExist(key))
            {
                _CreateProp(key, defaultValue);
            }

            T value = (T)this[key];

            return value;
        }

        public void Set<T>(string key, T value)
        {
            if (!_IsPropExist(key))
            {
                _CreateProp(key, value);
            }

            this[key] = value;
        }


        private bool _IsPropExist(string key)
        {
            foreach (SettingsProperty property in this.Properties)
            {
                if (property.Name == key)
                {
                    return true;
                }
            }
            return false;
        }
        private void _CreateProp<T>(string key, T defaultValue)
        {
            SettingsProperty prop = new SettingsProperty(key);
            prop.PropertyType = typeof(T);
            prop.DefaultValue = defaultValue;
            prop.Provider = this.Providers["LocalFileSettingsProvider"];
            prop.Attributes.Add(typeof(UserScopedSettingAttribute), new UserScopedSettingAttribute());
            //p.SerializeAs = SettingsSerializeAs.Xml;

            this.Properties.Add(prop);
        }
    }
}