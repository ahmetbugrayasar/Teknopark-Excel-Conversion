using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Excel_Convert
{
    public class Employee
    {
        public string NationalID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Program
    {
        public static void Main()
        {
            string filePath = "Firma Personel Listesi.csv"; // Update with the actual file path

            var employees = ReadEmployeesFromCSV(filePath);

            foreach (var employee in employees)
            {
                Console.WriteLine("T.C. Kimlik No: " + employee.NationalID);
                Console.WriteLine("Ad: " + employee.Name);
                Console.WriteLine("Soyad: " + employee.Surname);
                Console.WriteLine("--------------------------------");
            }
            Console.ReadLine();
        }

        public static List<Employee> ReadEmployeesFromCSV(string filePath)
        {
            var employees = new List<Employee>();

            using (var reader = new StreamReader(filePath))
            {
                // Skip the header line if it exists
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var employee = new Employee
                    {
                        NationalID = values[0],
                        Name = values[1],
                        Surname = values[2]
                    };

                    employees.Add(employee);
                }
            }

            return employees;
        }
    }
}
