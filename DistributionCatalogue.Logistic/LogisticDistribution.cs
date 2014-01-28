using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributionCatalogue.Logistic
{
    class LogisticDistribution
    {
        public double getPDF(double X, double u, double s)
        {
            double ex = Math.Exp(-(X-u)/s);

            return ex / (Math.Pow((1 + ex),2) * s);
        }
        public double getCDF(double X, double u, double s)
        {
            double ex = Math.Exp(-(X - u) / s);

            return 1 / (1 + ex);
        }
    }
}
