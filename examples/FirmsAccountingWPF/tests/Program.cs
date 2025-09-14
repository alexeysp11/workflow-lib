using System;

namespace VelocipedeUtils.Examples.FirmsAccounting.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new FirmsAccountingExample();
            
            // All fields are filled. 
            example.PrintAllFilled();
            
            // Only one field is empty. 
            example.PrintFirmEmpty();
            example.PrintFirmNull();
            example.PrintPostCityEmpty();
            example.PrintPostCityNull();
            example.PrintJurCityEmpty();
            example.PrintJurCityNull();

            // Two fields are empty. 
            //example.PrintFirmAndPostCityEmpty();
            //example.PrintFirmAndJurCityEmpty();
            //example.PrintPostCityAndJurCityEmpty();

            // All fields are empty.
            //example.PrintAllEmpty();
        }
    }
}
