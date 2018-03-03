using SMPHCracker.Model.Enums;
using System;
using System.Collections.Generic;

namespace SMPHCracker.Model.Dictionarys
{
    class StatusDictionary
    {
        private Dictionary<String, StatusEnum> dictionary = new Dictionary<string, StatusEnum>();

        public StatusDictionary()
        {
            Add("unauthorized", StatusEnum.Unauthorized);
            Add("device", StatusEnum.ADB);
            Add("recovery", StatusEnum.Recovery);
            Add("sideload", StatusEnum.Sideload);
            Add("nodevice", StatusEnum.NoDevice);
        }

        private void Add(String s, StatusEnum st)
        {
            dictionary.Add(s, st);
        }

        public Dictionary<String, StatusEnum> GetStatusDictionary()
        {
            return dictionary;
        }
    }
}
