//using TW.TestTool.Service;
//using TW.TestTool.DAO;
//using Rhino.Mocks;
//using System.Collections.Generic;
//using NUnit.Framework;
//using TW.TestTool.Dom;
//using System;
//using System.Linq;

using NUnit.Framework;

namespace NUnitTest.Service {
    [TestFixture]
    public class ProjectCacheTest {

        //[Test]
        //public void TestProjectCacheRefresh() {
        //    // 1. Arrange
        //    var projectDaoMock = MockRepository.GenerateStrictMock<ProjectDao>();

        //    var expectedProjectList = new List<Project>();
        //    expectedProjectList.Add(new Project { 
        //        Customer = "OFS", ProjectName = "KS", ProjectNumber = 466, StartDate = new DateTime(2009, 01, 01), 
        //        EndDate = new DateTime(2009, 04, 01), Status = "FIN"});
        //    projectDaoMock.Expect(dao => dao.GetAll()).Return(expectedProjectList).Repeat.Times(2);

        //    // 2. Act
        //    ProjectCache cache = ProjectCache.Instance;
        //    cache.SetProjectDAO(projectDaoMock);
        //    cache.Refresh();
            
        //    // First call
        //    var actualProjectList = cache.GetAllProjects();

        //    // 3. Assert
        //    // Verify cached data.
        //    CompareProjectList(expectedProjectList, actualProjectList);

        //    cache.Refresh();

        //    // Try to get all projects many times.
        //    for (int i = 0; i < 10000; i++) {
        //        // We expect the ProjectDao is only called in the first loop.
        //        actualProjectList = cache.GetAllProjects();

        //        // Verify cached data.
        //        CompareProjectList(expectedProjectList, actualProjectList);
        //    }

        //    projectDaoMock.VerifyAllExpectations();
        //}

        //private static void CompareProjectList(List<Project> expectedProjectList, IList<Project> actualProjectList) {
        //    Assert.AreEqual(expectedProjectList.Count, actualProjectList.Count, "Wrong number of project loaded.");

        //    for (int i = 0; i < expectedProjectList.Count; i++) {
        //        var expectedProject = expectedProjectList[i];
        //        var actualProject = actualProjectList[i];

        //        Assert.AreEqual(expectedProject.ProjectNumber, actualProject.ProjectNumber, "Wrong project number");
        //        Assert.AreEqual(expectedProject.ProjectName, actualProject.ProjectName, "Wrong project name");
        //    }
        //}
    }
}