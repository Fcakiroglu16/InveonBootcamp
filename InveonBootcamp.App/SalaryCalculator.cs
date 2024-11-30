using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.App
{
    internal enum SalaryType
    {
        Manager,
        Tester,
        Developer
    }


    public interface ISalaryCalculate
    {
        decimal Calculate(decimal baseSalary);
    }

    internal class ManagerSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal baseSalary)
        {
            return baseSalary * 2;
        }
    }


    internal class TesterSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal baseSalary)
        {
            return baseSalary * 1.5m;
        }
    }

    internal class DeveloperSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal baseSalary)
        {
            return baseSalary * 1.8m;
        }
    }

    internal class SeniorDeveloperSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal baseSalary)
        {
            return baseSalary * 1.5m;
        }
    }


    internal class SalaryCalculator
    {
        public decimal CalculateAsDelegate(decimal baseSalary, Func<decimal, decimal> salaryFunc)
        {
            return salaryFunc(baseSalary);
        }


        public decimal Calculate(decimal baseSalary, ISalaryCalculate salaryCalculate)
        {
            return salaryCalculate.Calculate(baseSalary);
        }


        //Interface
        //Delegate
        //Abstract Class
        //Virtual Method(Poly)
        public decimal Calculate(decimal baseSalary, SalaryType salaryType)
        {
            decimal salary = 0;
            switch (salaryType)
            {
                case SalaryType.Manager:
                    salary = baseSalary * 2;
                    break;
                case SalaryType.Tester:
                    salary = baseSalary * 1.5m;
                    break;
                case SalaryType.Developer:
                    salary = baseSalary * 1.8m;
                    break;
                default:
                    break;
            }

            return salary;
        }
    }
}