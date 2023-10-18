using System;
using System.Collections.Generic;

using R5T.T0132;
using R5T.T0159;
using R5T.T0172;


namespace R5T.F0115
{
    [FunctionalityMarker]
    public partial interface IProjectPathOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="IOperations.CreateProjectFilesTuples(IEnumerable{IProjectFilePath}, ITextOutput)"/>
        public ProjectFileTuple[] CreateProjectFilesTuples(
            IEnumerable<IProjectFilePath> projectFilePaths,
            ITextOutput textOutput)
        {
            var output = Instances.Operations.CreateProjectFilesTuples(
                projectFilePaths,
                textOutput);

            return output;
        }

        /// <inheritdoc cref="IOperations.CreateProjectFilesTuple(IProjectFilePath, ITextOutput)"/>
        public ProjectFileTuple CreateProjectFilesTuple(
            IProjectFilePath projectFilePath,
            ITextOutput textOutput)
        {
            var output = Instances.Operations.CreateProjectFilesTuple(
                projectFilePath,
                textOutput);

            return output;
        }
    }
}
