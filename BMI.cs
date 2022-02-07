using System;
using System.IO;

namespace Calculating_BMI
{
    class Program
    {

        class BMI
        {
            public string fullname;
            public double height;
            public double weight;

            private double bmi;
            private string result;

            // private variables for bmi and result to stop direct access

            public double ReturnBMI()
            {
                return bmi;
            }

            public void SetBMI(double getBMI)
            {
                bmi = getBMI;
            }

            public string ReturnResult()
            {
                return result;
            }

            public void SetResult(string getresult)
            {
                result = getresult;
            }

            // public methods to change and access bmi and result variables.

        }

        static void ParseData(BMI[] array)
        {
            string[] data = File.ReadAllLines("testdata.txt");
            // reads all data in an array at each line.

            for (int x = 0; x < data.Length; x++)
            {
                string[] result = data[x].Split(",");
                // sets the rows to be spilt at each comma "," in the text file.

                array[x] = new BMI();
                array[x].fullname = result[0];
                array[x].height = Convert.ToDouble(result[1]);
                array[x].weight = Convert.ToDouble(result[2]);

                // sets each property of the array to the data from the text file.


                double bmi = Math.Round(array[x].weight / Math.Pow(array[x].height, 2), 1);
                array[x].SetBMI(bmi);
                // calculates and assigns each persons BMI.
            }
        }

        static void Calculate_Result(BMI[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].ReturnBMI() < 18)
                {
                    array[i].SetResult("underweight");
                } else if (array[i].ReturnBMI() > 25)
                {
                    array[i].SetResult("overweight");
                } else
                {
                    array[i].SetResult("an ideal weight");
                }
            }

            // uses the BMI to give a result of general weight.
        }

        static void Print(BMI[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Hello {0}! You are {1} with a BMI of {2}.", array[i].fullname, array[i].ReturnResult(), array[i].ReturnBMI());
            }
        }

        static void Write(BMI[] array)
        {
            string[] writeToFile = new string[array.Length];
            // creates an array to write to file.

            for (int i = 0; i < array.Length; i++)
            {
                string text = "Hello ";
                text += Convert.ToString(array[i].fullname);
                text += "! You are ";
                text += Convert.ToString(array[i].ReturnResult());
                text += " with a BMI of ";
                text += Convert.ToString(array[i].ReturnBMI()); 
                text += ". \n";
                writeToFile[i] = text;
                // formats the text into lines

            }
            File.WriteAllLines("bmi_results_csharp.txt", writeToFile);
            // write each line of the array to the file
        }

        static void Main(string[] args)
        {
            var People = new BMI[5];
            // creates a new array with BMI class with a length of five.

            ParseData(People);
            Calculate_Result(People);
            Print(People);
            Write(People);
                  
        }
    }
}