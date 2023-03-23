using System;


namespace R5T.F0115
{
    public class FilePathOperator : IFilePathOperator
    {
        #region Infrastructure

        public static IFilePathOperator Instance { get; } = new FilePathOperator();


        private FilePathOperator()
        {
        }

        #endregion
    }
}
