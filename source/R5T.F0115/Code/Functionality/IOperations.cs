using System;
using System.Collections.Generic;
using System.Linq;

using R5T.F0020;
using R5T.T0132;
using R5T.T0159;
using R5T.T0172;
using R5T.T0172.Extensions;


namespace R5T.F0115
{
    [FunctionalityMarker]
    public partial interface IOperations : IFunctionalityMarker
    {
        public ProjectFileTuple[] CreateProjectFilesTuples(
            IEnumerable<IProjectFilePath> projectFilePaths,
            ITextOutput textOutput)
        {
            var projectFileTuples = projectFilePaths
                .Select(projectFilePath => this.CreateProjectFilesTuple(projectFilePath, textOutput))
                .Now();

            return projectFileTuples;
        }

        public string Get_AssemblyFilePath(
            string projectFilePath,
            string projectSdkName)
        {
            var assemblyFilePath = projectSdkName switch
            {
                IProjectSdkStrings.BlazorWebAssembly_Constant => Instances.FilePathOperator.Get_PublishWwwRootFrameworkDirectoryOutputAssemblyFilePath(projectFilePath),
                // Else
                _ => Instances.FilePathOperator.Get_PublishDirectoryOutputAssemblyFilePath(projectFilePath),
            };

            return assemblyFilePath;
        }

        public string Get_DocumentationFilePath(
            IProjectFilePath projectFilePath,
            string projectSdkName,
            string assemblyFilePath)
        {
            var documentationFilePath = projectSdkName switch
            {
                IProjectSdkStrings.BlazorWebAssembly_Constant => Instances.FilePathOperator.Get_DocumentationFilePath_ReleaseDirectory(projectFilePath).Value,
                _ => Instances.ProjectPathsOperator.GetDocumentationFilePath_ForAssemblyFilePath(assemblyFilePath),
            };

            return documentationFilePath;
        }

        public ProjectFileTuple CreateProjectFilesTuple(
            IProjectFilePath projectFilePath,
            ITextOutput textOutput)
        {
            textOutput.WriteInformation("Creating project file tuple...\n\t{projectFilePath}", projectFilePath);

            try
            {
                var sdk = Instances.ProjectFileOperator.GetSdk(projectFilePath.Value);

                var assemblyFilePath = this.Get_AssemblyFilePath(
                    projectFilePath.Value,
                    sdk);

                var documentationFilePath = this.Get_DocumentationFilePath(
                    projectFilePath,
                    sdk,
                    assemblyFilePath);

                var output = new ProjectFileTuple
                {
                    ProjectFilePath = projectFilePath,
                    AssemblyFilePath = assemblyFilePath.ToAssemblyFilePath(),
                    DocumentationFilePath = documentationFilePath.ToDocumentationXmlFilePath(),
                };

                return output;
            }
            catch(Exception)
            {
                var output = new ProjectFileTuple
                {
                    ProjectFilePath = projectFilePath,
                };

                return output;
            }
        }
    }
}
