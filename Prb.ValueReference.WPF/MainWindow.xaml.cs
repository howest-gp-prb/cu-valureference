using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Prb.ValueReference.CORE;

namespace Prb.ValueReference.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCopyValueType_Click(object sender, RoutedEventArgs e)
        {
            int i = 42;
            int j = i;
            i++;
            Debug.WriteLine($"i = {i}\nj = {j}");
        }

        private void btnCopyValueTypeEnum_Click(object sender, RoutedEventArgs e)
        {
            CarType type1 = CarType.Crossover;
            CarType type2 = type1;
            type1 = CarType.HatchBack;
            Debug.WriteLine($"Type1 = {type1}, Type2 = {type2}");

        }

        private void btnCopyValueTypeStruct_Click(object sender, RoutedEventArgs e)
        {
            Vector3d vector1 = new Vector3d(2, 3, 4);
            Vector3d vector2 = vector1;
            vector1.X++;
            vector1.Y++;
            vector1.Z++;
            Debug.WriteLine($"Vector1: X = {vector1.X}, Y = {vector1.Y}, Z = {vector1.Z}");
            Debug.WriteLine($"Vector2: X = {vector1.X}, Y = {vector1.Y}, Z = {vector1.Z}");
        }

        private void btnCopyReferenceType_Click(object sender, RoutedEventArgs e)
        {
            Car car1 = new Car("Honda", CarType.HatchBack, 100M);
            Car car2 = car1;
            car1.Speed += 10;
            Debug.WriteLine($"car 1 speed = {car1.Speed}, car 2 speed = {car2.Speed}");
        }

        private void btnCopyReferenceTypeString_Click(object sender, RoutedEventArgs e)
        {
            string string1 = "hello";
            string string2 = string1;
            string1 = string1.ToUpper(); //string1 krijgt een nieuwe waarde
            Debug.WriteLine($"string1 = {string1}, string2 = {string2}");
        }

        private int IncrementNumber(int number)
        {
            number++;
            return number;
        }

        private void btnPassValueType_Click(object sender, RoutedEventArgs e)
        {
            int getal1 = 5;
            int getal2 = IncrementNumber(getal1);
            Debug.WriteLine($"getal1: { getal1}\ngetal2: { getal2}");
        }

        private void IncrementNumberRef(ref int number)
        {
            number++;
        }

        private void btnPassValueTypeByRef_Click(object sender, RoutedEventArgs e)
        {
            int getal1 = 5;
            IncrementNumberRef(ref getal1);
            int getal2 = getal1;
            Debug.WriteLine($"getal1: {getal1}\ngetal2: {getal2}");
        }

        private bool InitializeMe(out int numberToInitialize)
        {
            //the value of numberToInitialize is always discarded when passing as out
            numberToInitialize = 42;
            return true;
        }

        private void btnOutputParameter_Click(object sender, RoutedEventArgs e)
        {
            int numberComingOut = 66;
            bool ok = InitializeMe(out numberComingOut);
            Debug.WriteLine($"numberComingOut has value: {numberComingOut}");
        }

        private void PrintObjectAsString(object someObject)
        {
            //toon het type van het aangeleverde object, gevolgd door de waarde van de the ToString() method
            Debug.WriteLine($"Object is a {someObject.GetType().ToString()}, ToString: {someObject.ToString()}");
        }

        private void btnBoxing_Click(object sender, RoutedEventArgs e)
        {
            int number = 42;
            object boxedNumber = number; //boxing happens implicitly

            number++; //this variable is still on the stack

            Car myCar = new Car("Ford", CarType.Sedan, 90);
            object abstractCar = myCar;  //no boxing, myCar is already on the heap

            PrintObjectAsString(boxedNumber);
            PrintObjectAsString(number);
            PrintObjectAsString(abstractCar);
        }

        private void btnUnboxing_Click(object sender, RoutedEventArgs e)
        {
            int number = 42;
            object boxedNumber = number; //boxing
            int unboxed = (int)boxedNumber;
        }

        private void btnSafeCasting_Click(object sender, RoutedEventArgs e)
        {
            int? myNumber = 42;
            object boxedNumber = myNumber;
            int? myNumberAgain = boxedNumber as int?; //safe typecast

            if (myNumberAgain != null)
                Debug.WriteLine($"myNumberAgain: {myNumberAgain.ToString()}");
            else
                Debug.WriteLine("myNumberAgain was casted to wrong type");


            Car myCar = new Car("Toyota", CarType.SUV, 65);
            object boxedCar = myCar;
            Window myCarAgain = boxedCar as Window; //safe cast fails due to type mismatch, myCarAgain is null!

            if (myCarAgain != null)
                Debug.WriteLine($"myCarAgain: { myCarAgain.ToString()}");
            else
                Debug.WriteLine("myCarAgain was casted to wrong type");
        }
    }
}
