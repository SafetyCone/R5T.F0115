using System;

using R5T.T0142;
using R5T.T0172;


namespace R5T.F0115
{
    /// <summary>
    /// A tuple containing a project file path, built assembly file path for that project, and the generated documentation file path for that project.
    /// </summary>
    [DataTypeMarker]
    public class ProjectFileTuple
    {
        public IProjectFilePath ProjectFilePath { get; set; }
        public IAssemblyFilePath AssemblyFilePath { get; set; }
        public IDocumentationXmlFilePath DocumentationFilePath { get; set; }
    }
}
