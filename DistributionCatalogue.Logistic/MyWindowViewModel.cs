using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DistributionCatalogue.Logistic
{
    class MyWindowViewModel : INotifyPropertyChanged
    {
        private double paramU = 0;
        private double paramS = 0;
        private double valueX = 0;
        private double valueCDF = 0;
        private String pdfOut = "PDF: ";
        private String cdfOut = "CDF: ";
        private String quantile1 = "Q(CDF): ";
        private String quantile2 = "Q(1-CDF): ";
        private String quantile3 = "Q(CDF/2): ";
        private String quantile4 = "Q(1-CDF/2): ";
        private LogisticDistribution logisticD;

        public MyWindowViewModel()
        {
            logisticD = new LogisticDistribution();
        }

        public double ParameterU{
            get
            {
                return paramU;
            }
            set
            {
                paramU = value;
            }
        }

        public double ParameterS
        {
            get
            {
                return paramS;
            }
            set
            {
                paramS = value;
                if (paramS <= 0)
                {
                    throw new ApplicationException("Parameter 's' must be greater than 0!");
                }
            }
        }

        public double ValueX
        {
            get
            {
                return valueX;
            }
            set
            {
                valueX = value;
            }
        }
        public String PDFOutput
        {
            get
            {
                return pdfOut;
            }
            set
            {
                pdfOut = value;
                OnPropertyChanged("PDFOutput");
            }
        }
        public String CDFOutput
        {
            get
            {
                return cdfOut;
            }
            set
            {
                cdfOut = value;
                OnPropertyChanged("CDFOutput");
            }
        }

        public double ValueCDFInput
        {
            get
            {
                return valueCDF;
            }
            set
            {
                valueCDF = value;
                if (valueCDF < 0 || valueCDF >1)
                {
                    throw new ApplicationException("CDF value must be between 0 and 1!");
                }
            }
        }
        public String Q1Output
        {
            get
            {
                return quantile1;
            }
            set
            {
                quantile1 = value;
                OnPropertyChanged("Q1Output");
            }
        }
        public String Q2Output
        {
            get
            {
                return quantile2;
            }
            set
            {
                quantile2 = value;
                OnPropertyChanged("Q2Output");
            }
        }
        public String Q3Output
        {
            get
            {
                return quantile3;
            }
            set
            {
                quantile3 = value;
                OnPropertyChanged("Q3Output");
            }
        }
        public String Q4Output
        {
            get
            {
                return quantile4;
            }
            set
            {
                quantile4 = value;
                OnPropertyChanged("Q4Output");
            }
        }


        public void CalculatePDFCDF()
        {
            PDFOutput = "PDF: "+logisticD.getPDF(valueX, paramU, paramS);
            CDFOutput = "CDF: "+logisticD.getCDF(valueX, paramU, paramS);
        }

        public void CalculateQuantiles()
        {
            Q1Output = "Q(CDF): " + logisticD.quantileLeftSide(valueCDF, paramU, paramS);
            Q2Output = "Q(1-CDF): " + logisticD.quantileRightSide(valueCDF, paramU, paramS);
            Q3Output = "Q(CDF/2): " + logisticD.quantileCenterL(valueCDF, paramU, paramS);
            Q4Output = "Q(1-CDF/2): " + logisticD.quantileCenterR(valueCDF, paramU, paramS);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
