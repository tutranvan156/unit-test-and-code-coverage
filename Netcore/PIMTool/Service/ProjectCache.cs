/**
 * The service to provide user utilities.
 */
using TW.TestTool.Dom;
using System;
using TW.TestTool.DAO;
using System.Collections.Generic;

namespace TW.TestTool.Service{
    public class ProjectCache {
        private static ProjectCache s_projectCache = new ProjectCache();
        public static ProjectCache Instance {
            get {
                return s_projectCache;
            }
        }

	    private ProjectDao m_projectDAO;
        private IList<Project> m_projectCaches = null;
    	
	    public void SetProjectDAO(ProjectDao projectDao) {
		    m_projectDAO = projectDao;
	    }
    	
	    public IList<Project> GetAllProjects() {
		    if (m_projectCaches == null) {
                m_projectCaches = m_projectDAO.GetAll();
		    }
    		
		    return m_projectCaches;
	    }
    	
	    public void Refresh() {
		    m_projectCaches = null;
	    }
    }
}