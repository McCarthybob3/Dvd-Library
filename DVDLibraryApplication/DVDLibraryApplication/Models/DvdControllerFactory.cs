using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibraryApplication.Models
{
    public class DvdControllerFactory
    {
        public static IDvdRepository GetRepo()
        {

            switch (Settings.GetRepositoryType())
            {
                case "SampleData":
                    return new DvdRepoMock();
                  case "ADO":
                       return new DvdRepoADO();
                case "EF":
                    return new DvdRepoEF();
                default:
                    throw new Exception("Not a valid Repo type");
            }

        }
    }
}