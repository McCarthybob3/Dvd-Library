﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DVDLibraryApplication.Models
{
    public class Settings
    {
        private static string _repositoryType;

        public static string GetRepositoryType()
        {
            if (string.IsNullOrEmpty(_repositoryType))
                _repositoryType = ConfigurationManager.AppSettings["Mode"].ToString();

            return _repositoryType;
        }
    }
}