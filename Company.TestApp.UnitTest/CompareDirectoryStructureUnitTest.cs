#region System Usings
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
#endregion  System Usings

#region Customs Usings
using Company.TestApp.Model;
using Company.TestApp.Enums;
using Company.TestApp.Business;
#endregion Customs Usings

namespace Company.TestApp.UnitTest
{
    /// <summary>
    /// Test CompareDirectoryStructure class
    /// </summary>
    [TestClass]
    public class CompareDirectoryStructureUnitTest
    {
         
        /// <summary>
        /// Compare list with equals values
        /// </summary>
        [TestMethod]
        public void TestCompareListWithEqualsValues()
        {
            IDirectoryStructure directoryStructure  = new ListWithEqualValues();
            using (var compareDirectoryStructure = new CompareDirectoryStructure(directoryStructure))
            {
                Assert.IsTrue(compareDirectoryStructure.ActionList.Count == 0);
            }
        }

        /// <summary>
        /// Compare list with different values
        /// </summary>
        [TestMethod]
        public void CompareListWithDiffValues()
        {
                var lstDirectoryStructure = new ListWithDiffValues();
                using (var compareDirectoryStructure = new CompareDirectoryStructure(lstDirectoryStructure))
                {
                    Assert.IsTrue(compareDirectoryStructure.ActionList.Count == 2);
                    var items = lstDirectoryStructure.GetDirectoriesContent();
                    Assert.IsTrue(compareDirectoryStructure.CompareResult.Join(items, row1 => row1.ComparableValue, row2 => row2.ComparableValue,
                              (row1, row2) => new { row1.ComparableValue }).ToList().Count() == 2);
                 
            }
        }

        /// <summary>
        /// Test the result with right result
        /// </summary>
        [TestMethod]
        public void CompareResultRightActionList()
        {
            var lstDirectoryStructure = new ListWithDiffValues();
            using (var compareDirectoryStructure = new CompareDirectoryStructure(lstDirectoryStructure))
            {
                var items = lstDirectoryStructure.GetFakeClassRightActionList();
                Assert.IsTrue(compareDirectoryStructure.ActionList.Join(items, row1 => row1.DirectoryItemValue.Name, row2 => row2.DirectoryItemValue.Name,
                          (row1, row2) => new { row1.DirectoryItemValue }).ToList().Count() == 2);

            }
        }
        /// <summary>
        /// Test the result with wrong result
        /// </summary>
        [TestMethod]
        public void CompareResultWrongActionList()
        {
            var lstDirectoryStructure = new ListWithDiffValues();
            using (var compareDirectoryStructure = new CompareDirectoryStructure(lstDirectoryStructure))
            {
                var items = lstDirectoryStructure.GetFakeClassWrongActionList();
                Assert.IsFalse(compareDirectoryStructure.ActionList.Join(items, row1 => row1.DirectoryItemValue.Name, row2 => row2.DirectoryItemValue.Name,
                          (row1, row2) => new { row1.DirectoryItemValue }).ToList().Count() == 2);

            }
        }

    }
}
