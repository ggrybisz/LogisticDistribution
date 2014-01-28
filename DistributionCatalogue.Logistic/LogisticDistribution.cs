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

        public double quantileLeftSide(double cdf, double u, double s)
        {
            return quantileFunction(cdf, u, s);
        }

        public double quantileRightSide(double cdf, double u, double s)
        {
            return quantileFunction(1-cdf, u, s);
        }

        public double quantileCenterL(double cdf, double u, double s)
        {
            return quantileFunction(cdf/2, u, s);
        }

        public double quantileCenterR(double cdf, double u, double s)
        {
            return quantileFunction(1 - (cdf/2), u, s);
        }

        private double quantileFunction(double cdf, double u, double s)
        {
            return u + s* Math.Log(cdf/(1-cdf));
        }
    }
}
