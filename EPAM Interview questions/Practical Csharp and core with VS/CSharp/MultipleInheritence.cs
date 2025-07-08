using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{

    public class LifeInsurence : ILifeInsurance
    {
        public void CalculatePremium()
        {
            Console.WriteLine("Calclate Life Insurance");
        }
    }

    public class PetInsurance : IPetInsurance
    {
        public void CalculatePremium()
        {
            Console.WriteLine("Calclate Pet Insurance");
        }
    }
    internal class MultipleInheritence : ILifeInsurance, IPetInsurance
    {
        LifeInsurence lifeInsurence = new LifeInsurence();
        PetInsurance petInsurance = new PetInsurance();
        void ILifeInsurance.CalculatePremium()
        {
            lifeInsurence.CalculatePremium();
        }

        void IPetInsurance.CalculatePremium()
        {
            petInsurance.CalculatePremium();
        }

        public void PrintPremium()
        {
            ILifeInsurance lifeInsurance = new MultipleInheritence();
            lifeInsurance.CalculatePremium();
            IPetInsurance petInsurance = new MultipleInheritence();
            petInsurance.CalculatePremium();
        }
    }
}
