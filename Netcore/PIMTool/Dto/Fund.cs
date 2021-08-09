namespace TW.TestTool.Dom
{
    public class Fund
    {
        private double[] m_x;
        public Fund(double x1, double x2, double x3, double x4)
        {
            this.m_x = new double[] { x1, x2, x3, x4 };
        }

        public double[] GetX()
        {
            return m_x;
        }
    }
}
