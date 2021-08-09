/**
 * Contains project's information such as: project name, project number, project version,
 * start date, end date, ect..
 */
using System;
namespace TW.TestTool.Dom
{
    public class Project
    {
        public Project()
        {
        }

        public Project(long id, int number, String name, String customer, DateTime startDate, String status) {
            m_id = id;
            m_projectNumber = number;
            m_projectName = name;
            m_customer = customer;
            m_status = status;
            m_startDate = startDate;
        }

        public const String TABLE = "PROJECT";

        private long m_id;
        public virtual long Id
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
            }
        }

        private int m_projectNumber;
        public virtual int ProjectNumber
        {
            set
            {
                this.m_projectNumber = value;
            }
            get
            {
                return m_projectNumber;
            }
        }

        private String m_projectName;
        public virtual String ProjectName
        {
            get
            {
                return m_projectName;
            }
            set
            {
                m_projectName = value;
            }
        }
        private String m_customer;
        public virtual String Customer
        {
            set
            {
                this.m_customer = value;
            }
            get
            {
                return m_customer;
            }
        }
        private String m_status;
        public virtual String Status
        {
            set
            {
                this.m_status = value;
            }
            get
            {
                return m_status;
            }
        }

        private DateTime m_startDate;
        public virtual DateTime StartDate
        {
            set
            {
                this.m_startDate = value;
            }
            get
            {
                return m_startDate;
            }
        }


        private DateTime m_endDate;
        public virtual DateTime EndDate
        {
            set
            {
                this.m_endDate = value;
            }
            get
            {
                return m_endDate;
            }
        }

        public bool SameProject(Object p)
        {
            if (p == null || !(p is Project))
            {
                return false;
            }
            Project project = (Project)p;

            return (m_projectNumber == project.m_projectNumber
                    && Equals(m_projectName, project.m_projectName)
                    && Equals(m_customer, project.m_customer)
                    && Equals(m_status, project.m_status));
        }

        private bool Equals(Object obj1, Object obj2)
        {
            return ((obj1 == obj2 && obj2 == null)
                    || (obj1 != null && obj2 != null && obj1.Equals(obj2)));
        }

    }
}