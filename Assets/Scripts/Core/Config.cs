using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Config
    {
        private string Path = "";
        public int ActiveSpeedNeed = 1000;

        private Config()
        {

        }

        public static Config ConfigSingleton()
        {
            var config = new Config();
            return config;
        }
    }
}