using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blitz.Models;

namespace Blitz.DataAccess
{
    public interface IProjectDAO
    {
        IEnumerable<Project> GetProjects();

        IEnumerable<Project> GetProjectById(int id);

        int AddProject(Project p);

        int UpdateProject(Project p);
        int DeleteProject(int id);

           
    }
}
