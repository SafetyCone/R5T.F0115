using System;


namespace R5T.F0115
{
    public class ProjectPathOperator : IProjectPathOperator
    {
        #region Infrastructure

        public static IProjectPathOperator Instance { get; } = new ProjectPathOperator();


        private ProjectPathOperator()
        {
        }

        #endregion
    }
}
