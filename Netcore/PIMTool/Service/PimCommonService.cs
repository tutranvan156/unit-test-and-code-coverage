using TW.TestTool.Dom;
using TW.TestTool.Exceptions;
namespace TW.TestTool.Service.Impl {
    public class PimCommonService {
        public bool IsFundCorrelated(Fund A, Fund B) {
            // This service is not implemented
            return true;
        }

        public TriangleType ClassifyTriangle(double a, double b, double c) {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a) {
                throw new InvalidTriangleEdgeException(a, b, c);
            }

            if (a == b && a == c && c == b) {
                return TriangleType.EQUILATERAL;
            }

            bool isoscelles = (a == b || b == c || a == c);
            bool rightAngle = (a * a + b * b == c * c)
                                    || (a * a + c * c == b * b)
                                    || (b * b + c * c == a * a);
            if (isoscelles && rightAngle) {
                return TriangleType.ISOSCELES_RIGHT_ANGLED;
            }

            if (isoscelles) {
                return TriangleType.ISOSCELES;
            }

            if (rightAngle) {
                return TriangleType.RIGHT_ANGLED;
            }

            return TriangleType.SCALENE;
        }
    }
}

