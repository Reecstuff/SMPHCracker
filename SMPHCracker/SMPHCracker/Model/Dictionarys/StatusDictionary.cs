﻿using SMPHCracker.Model.Enums;
using System;
using System.Collections.Generic;

namespace SMPHCracker.Model.Dictionarys
{
    class StatusDictionary
    {
        private Dictionary<String, Status> dictionary = new Dictionary<string, Status>();

        public StatusDictionary()
        {
            Add("unauthorized", Status.Unauthorized);
            Add("device", Status.ADB);
            Add("recovery", Status.Recovery);
            Add("sideload", Status.Sideload);
            Add("nodevice", Status.NoDevice);
        }

        private void Add(String s, Status st)
        {
            dictionary.Add(s, st);
        }

        public Dictionary<String, Status> GetStatusDictionary()
        {
            return dictionary;
        }
    }
}
