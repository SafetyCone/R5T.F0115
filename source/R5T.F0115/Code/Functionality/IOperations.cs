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
            IList<IProjectFilePath> projectFilePaths,
            ITextOutput textOutput)
        {
            var projectFileTuples = projectFilePaths
                .Select(projectFilePath => this.CreateProjectFilesTuple(projectFilePath, textOutput))
                .Now();

            return projectFileTuples;
        }

        public ProjectFileTuple CreateProjectFilesTuple(
            IProjectFilePath projectFilePath,
            ITextOutput textOutput)
        {
            textOutput.WriteInformation("Creating project file tuple...\n\t{projectFilePath}", projectFilePath);

            var sdk = Instances.ProjectFileOperator.GetSdk(projectFilePath.Value);

            var assemblyFilePath = sdk switch
            {
                IProjectSdkStrings.BlazorWebAssembly_Constant => Instances.FilePathOperator.Get_PublishWwwRootFrameworkDirectoryOutputAssemblyFilePath(projectFilePath.Value),
                // Else
                _ => Instances.FilePathOperator.Get_PublishDirectoryOutputAssemblyFilePath(projectFilePath.Value),
            };

            var documentationFilePath = sdk switch
            {
                IProjectSdkStrings.BlazorWebAssembly_Constant => Instances.FilePathOperator.Get_DocumentationFilePath_ReleaseDirectory(projectFilePath).Value,
                _ => Instances.ProjectPathsOperator.GetDocumentationFilePath_ForAssemblyFilePath(assemblyFilePath),
            };

            var projectFilesTuple = new ProjectFileTuple
            {
                ProjectFilePath = projectFilePath,
                AssemblyFilePath = assemblyFilePath.ToAssemblyFilePath(),
                DocumentationFilePath = documentationFilePath.ToDocumentationXmlFilePath(),
            };

            return projectFilesTuple;
        }
    }
}
