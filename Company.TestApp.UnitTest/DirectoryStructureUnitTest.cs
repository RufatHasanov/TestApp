#region System Usings
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion System Usings

#region Custom Usings
using Company.TestApp.Business;
#endregion Custom Usings

namespace Company.TestApp.UnitTest
{
    /// <summary>
    /// Test DirectoryStructure class
    /// </summary>
    [TestClass]
    public class DirectoryStructureUnitTest
    {

        #region TestMethods
        //Try create intance DirectoryStructure with correct directory path
        [TestMethod]
        public void TestDirectoryStructureWithCorrectPath()
        {
            //Get App lcation
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            CreateDirectoryStructure(path, path);
            Assert.IsTrue(true);
        }
        /// <summary>
        /// Try create intance DirectoryStructure without first directory path
        /// </summary>
        [TestMethod]
        public void TestDirectoryStructureWithoutFirstPath()
        {

            try
            {
                CreateDirectoryStructure("", "C:\\");
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Try create intance DirectoryStructure without second directory path
        /// </summary>
        [TestMethod]
        public void TestDirectoryStructureWithoutSecondPath()
        {

            try
            {
                CreateDirectoryStructure("C:\\", "");
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Try create intance DirectoryStructure without both directory path
        /// </summary>
        [TestMethod]
        public void TestDirectoryStructureWithoutBothPath()
        {

            try
            {
                CreateDirectoryStructure("", "");
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Try create intance DirectoryStructure wrong first directory path
        /// </summary>
        [TestMethod]
        public void TestDirectoryStructureFirstPathIsWrong()
        {

            try
            {
                CreateDirectoryStructure("\\Test\\", "C:\\");

            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Try create intance DirectoryStructure wrong second directory path
        /// </summary>
        [TestMethod]
        public void TestDirectoryStructureSecondPathIsWrong()
        {

            try
            {
                CreateDirectoryStructure("C:\\", "\\Test\\");
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Try create intance DirectoryStructure wrong both directory path
        /// </summary>
        [TestMethod]
        public void TestDirectoryStructureBothPathIsWrong()
        {

            try
            {
                CreateDirectoryStructure("\\Test1\\", "\\Test2\\");
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        #endregion TestMethods

        #region Helper
        /// <summary>
        /// Create DirectoryStructure class example
        /// </summary>
        /// <param name="firstDirectoryPath"></param>
        /// <param name="secondDirectoryPath"></param>
        private void CreateDirectoryStructure(string firstDirectoryPath, string secondDirectoryPath)
        {
            new DirectoryStructure(firstDirectoryPath, secondDirectoryPath);
        }

        
        #endregion Helper

    }
}
