using System.Collections.Generic;
using TW.TestTool.Dom;
namespace TW.TestTool.DAO {
    public interface ProjectDao {
        IList<Project> GetAll();
    }
}


