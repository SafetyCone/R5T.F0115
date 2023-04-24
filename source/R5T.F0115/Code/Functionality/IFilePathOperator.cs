using System;

using R5T.T0132;
using R5T.T0172;
using R5T.T0172.Extensions;


namespace R5T.F0115
{
    [FunctionalityMarker]
    public partial interface IFilePathOperator : IFunctionalityMarker,
        F0112.IFilePathOperator
    {
        /// <summary>
        /// Gets the documentation file path of file in the <see cref="Z0012.IDirectoryNames.Release"/> directory.
        /// </summary>
        public IDocumentationXmlFilePath Get_DocumentationFilePath_PublishDirectory(
            IProjectFilePath projectFilePath)
        {
            var projectDirectoryPath = Instances.ProjectPathsOperator.GetProjectDirectoryPath(projectFilePath.Value);

            var releaseDirectoryPath = Instances.PathOperator.GetDirectoryPath(
                projectDirectoryPath,
                Instances.DirectoryNames.bin,
                Instances.DirectoryNames.Publish);

            var documentationFileName = Instances.ProjectPathsOperator.GetDocumentationFileName_FromProjectFilePath(projectFilePath.Value);

            var documentationFilePath = Instances.PathOperator.GetFilePath(
                releaseDirectoryPath,
                documentationFileName)
                .ToDocumentationXmlFilePath();

            return documentationFilePath;
        }

        /// <summary>
        /// Gets the documentation file path of file in the <see cref="Z0012.IDirectoryNames.Release"/> directory.
        /// </summary>
        public IDocumentationXmlFilePath Get_DocumentationFilePath_ReleaseDirectory(
            IProjectFilePath projectFilePath)
        {
            var projectDirectoryPath = F0052.ProjectPathsOperator.Instance.GetProjectDirectoryPath(projectFilePath.Value);

            var releaseDirectoryPath = F0002.PathOperator.Instance.GetDirectoryPath(
                projectDirectoryPath,
                Instances.DirectoryNames.bin,
                Instances.DirectoryNames.Release);

            var documentationFileName = Instances.ProjectPathsOperator.GetDocumentationFileName_FromProjectFilePath(projectFilePath.Value);

            var documentationFilePath = Instances.PathOperator.GetFilePath(
                releaseDirectoryPath,
                documentationFileName)
                .ToDocumentationXmlFilePath();

            return documentationFilePath;
        }
    }
}
