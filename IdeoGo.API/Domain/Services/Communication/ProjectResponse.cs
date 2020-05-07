using IdeoGo.API.Domain.Models;


namespace IdeoGo.API.Domain.Services.Communication
{
    public class ProjectResponse : BaseResponse
    {
        public Project Project { get; private set; }

        public ProjectResponse(bool success, string message, Project project) : base(success, message) ///pasa la llamada a el constructor del padre
        {
            Project = project;
        }


        public ProjectResponse(Project project) : this(true, string.Empty, project)
        {
            //Escenario feliz
        }

        public ProjectResponse(string message) : this(false, message, null)
        {
            ///Escenario triste
        }







    }
}


