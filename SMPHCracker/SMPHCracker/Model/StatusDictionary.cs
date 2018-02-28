﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Model
{
    class StatusDictionary
    {
        private Dictionary<String, Status> dictionary;

        public StatusDictionary()
        {
            Add("unauthorized", Status.Unauthorized);
            Add("device", Status.Root);
            Add("recovery", Status.Recovery);
            Add("sideload", Status.Sideload);
      
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