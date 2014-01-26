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
        private String pdfOut = "PDF: ";
        private String cdfOut = "CDF: ";


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

        public void Calculate()
        {
            PDFOutput = "PDF: "+calculatePDF(valueX, paramU, paramS).ToString();
            CDFOutput = "CDF: "+calculateCDF(valueX, paramU, paramS).ToString();
        }

        public double calculatePDF(double X, double u, double s){
            return 5.0;
        }
        public double calculateCDF(double X, double u, double s)
        {
            return 1.0;
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
