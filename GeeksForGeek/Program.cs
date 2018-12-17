using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek
{
    class Program
    {
        static void Main1(string[] args)
        {
            var item = new Item();
            item.IsImported = false;

        }
    }
    public interface IItem
    {
        decimal Price { get; set; }
        string Name { get; set; }
        bool IsImported { get; set; }
        bool IsExempted { get; set; }
        decimal CalculateTax();
    }
    public class Item: IItem
    {
        private decimal _Price;
        private string _Name;
        private bool _IsImported;
        private bool _IsExempted;

        public bool IsExempted
        {
            get { return _IsExempted; }
            set { _IsExempted = value; }
        }

        public bool IsImported
        {
            get { return _IsImported; }
            set { _IsImported = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        public decimal CalculateTax()
        {
            var taxCalculator = new TaxCalculator();
            if (!IsExempted)
            {
                taxCalculator.Taxes.Add(new SaleTax());
            }
            if (IsImported)
            {
                taxCalculator.Taxes.Add(new ImportTax());
            }
            return taxCalculator.Calculate(this);
        }
    }
    public interface ITax
    {
        int Tax { get; set; }
    }
    public interface ITaxCalculator
    {
        List<ITax> Taxes { get; set; }
        decimal Calculate(IItem item);
    }
    public class TaxCalculator : ITaxCalculator
    {
        private List<ITax> _Taxes;

        public List<ITax> Taxes
        {
            get { return _Taxes; }
            set { _Taxes = value; }
        }
        public decimal Calculate(IItem item)
        {
            decimal totalTax = 0.0m;
            foreach (ITax tax in Taxes)
            {
                totalTax += (item.Price * tax.Tax) / 100;
            }
            return totalTax;
        }

    }

    public class ImportTax : ITax
    {
        private int _TaxPercentage;
        public ImportTax()
        {
            _TaxPercentage = 5;
        }
        public int Tax
        {
            get
            {
                return _TaxPercentage;
            }

            set
            {
                _TaxPercentage = value;
            }
        }
    }
    public class SaleTax : ITax
    {
        private int _TaxPercentage;
        public SaleTax()
        {
            _TaxPercentage = 10;
        }
        public int Tax
        {
            get
            {
                return _TaxPercentage;
            }

            set
            {
                _TaxPercentage = value;
            }
        }
    }
}
