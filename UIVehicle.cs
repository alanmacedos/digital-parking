using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace digitalparking
{
    public class UIVehicle
    {
        public Vehicle CreateVehicle()
        {
            Console.WriteLine("\nQual seu nome?");
            string owner = Console.ReadLine()!;

            Console.WriteLine("\nQual a placa do seu veículo?");
            string plate = Console.ReadLine()!;

            Console.WriteLine("\nQual o modelo do veículo?");
            string model = Console.ReadLine()!;

            Console.WriteLine()

        return new Vehicle(owner, plate, model);
        }
    }
}