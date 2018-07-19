using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.Web.DAL.Interfaces
{
    public interface IParkDAL
    {
        List<Park> GetAllParks();
        Park GetParkByCode(string parkCode);
        IList<SelectListItem> GetParksForMenu();
    }
}