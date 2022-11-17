using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blitz.DataAccess;
using System.Data;
using Blitz.Models;
using System;
using System.Data.SqlClient;



namespace Blitz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectDAO pdao= new ProjectDAO();

        [HttpGet]
        [Route("api/getbyid/{id}")]
        public IEnumerable<Project> GetById(int id)
        {
            return pdao.GetProjectById(id);
        }

        [HttpGet]
        [Route("api/get")]
        public IEnumerable<Project> Get()
        {
            return pdao.GetProjects();
        }
        [HttpPost]
        [Route("api")]
        public int Create(Project p)
        {
           return pdao.AddProject(p);
        }

        [HttpDelete]
        [Route("api/delete/{id}")]
        public int Delete(int id)
        {
           return pdao.DeleteProject(id);
        }

        [HttpPut]
        [Route("api")]
        public int Update(Project p)
        {
           return pdao.UpdateProject(p);
        }
    }
}
