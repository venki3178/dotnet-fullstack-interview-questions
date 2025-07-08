using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    public interface ILifeInsurance
    {
        void CalculatePremium();
    }

    public interface IPetInsurance
    {
        void CalculatePremium();
    }
    public class ExplicitInterface : ILifeInsurance, IPetInsurance
    {
        void ILifeInsurance.CalculatePremium()
        {
            Console.WriteLine("Calculation of LifeInsurance");
        }

        void IPetInsurance.CalculatePremium()
        {
            Console.WriteLine("Calculation of PetInsurance");
        }

        public void PrintPremiums()
        {
            ILifeInsurance policy = new ExplicitInterface();
            policy.CalculatePremium();
            IPetInsurance petPolicy = new ExplicitInterface();
            petPolicy.CalculatePremium();
        }
    }
}
