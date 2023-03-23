using System;


namespace R5T.F0115
{
    public class ProjectPathsOperator : IProjectPathsOperator
    {
        #region Infrastructure

        public static IProjectPathsOperator Instance { get; } = new ProjectPathsOperator();


        private ProjectPathsOperator()
        {
        }

        #endregion
    }
}
