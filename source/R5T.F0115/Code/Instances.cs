using System;


namespace R5T.F0115
{
    public static class Instances
    {
        public static Z0012.IDirectoryNames DirectoryNames => Z0012.DirectoryNames.Instance;
        public static IFilePathOperator FilePathOperator => F0115.FilePathOperator.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static F0020.IProjectFileOperator ProjectFileOperator => F0020.ProjectFileOperator.Instance;
        public static IProjectPathsOperator ProjectPathsOperator => F0115.ProjectPathsOperator.Instance;
    }
}