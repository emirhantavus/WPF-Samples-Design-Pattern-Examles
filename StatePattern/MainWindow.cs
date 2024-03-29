﻿// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Converter
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowVars();
        }
        public interface IKomutlar //state design pattern
        {
            void dönüsümYap();
            void dönüsümYaz();
            void sonucGöster(string a, string b, string c, string d); //mainwindow dan erişmek lazım
        }

        public class Mmatrix : MainWindow, IKomutlar
        {
            public void dönüsümYap()
            {
                var mConverter = new MatrixConverter();
                var string2 = "10,20,30,40,50,60";
                var matrixResult = (Matrix)mConverter.ConvertFromString(string2);
                // matrixResult is equal to (10, 20, 30, 40, 50, 60)
            }
            public void dönüsümYaz()
            {
                var mConverter = new MatrixConverter();
                var string2 = "10,20,30,40,50,60";
                var matrixResult = (Matrix)mConverter.ConvertFromString(string2);
                // matrixResult is equal to (10, 20, 30, 40, 50, 60)

            }
            public void sonucGöster(string resultValue, string syntax, string resultType, string opString)
            {
                txtResultValue.Text = resultValue;
                txtSyntax.Text = syntax;
                txtResultType.Text = resultType;
                txtOperation.Text = opString;
            }
        }

        public class Vvektor : MainWindow, IKomutlar
        {
            private string syntaxString, resultType, operationString, pointResult;

            public void dönüsümYap()
            {
                var vConverter = new VectorConverter();
                var string1 = "10,20";
                var vectorResult = (Vector)vConverter.ConvertFromString(string1);
                // vectorResult is equal to (10, 20)
            }
            public void dönüsümYaz()
            {
                syntaxString = "vectorResult = (Vector)vConverter.ConvertFromString(string1);";
                resultType = "Vector";
                operationString = "Converting a String into a Vector";
                //(pointResult.ToString(), syntaxString, resultType, operationString);
                //Normalde bu sekilde yaptık erişim sıkıntısı olmadıgından hata veriyor.
            }
            public void sonucGöster(string resultValue, string syntax, string resultType, string opString)
            {
                txtResultValue.Text = resultValue;
                txtSyntax.Text = syntax;
                txtResultType.Text = resultType;
                txtOperation.Text = opString;
            }
        }

        public class Islemler : MainWindow
        {
            private IKomutlar komut;
            public Islemler()
            {
                MessageBox.Show("İslemler Yapılıyor..");
            }
            public void Tanımlama()
            {
                komut.dönüsümYaz();
            }
            public void Coz()
            {
                komut.dönüsümYap();
            }
            public void göster(string resultValue, string syntax, string resultType, string opString)
            {
                komut.sonucGöster(resultValue, syntax, resultType, opString);
            }
            public void vektörGecis()
            {
                MessageBox.Show("Vektör cözme işlemine gecildi..");
                komut = new Vvektor();
            }
            public void matrixGecis()
            {
                MessageBox.Show("Matrix cözme islemine gecildi..");
                komut = new Mmatrix();
            }
        }
        // This method performs the Point operations
        public void PerformOperation(object sender, RoutedEventArgs e)
        {
            var li = (sender as RadioButton);

            // Strings used to display the results
            string syntaxString, resultType, operationString;

            // The local variables point1, point2, vector2, etc are defined in each
            // case block for readability reasons. Each variable is contained within
            // the scope of each case statement.
            // 

            Islemler islem = new Islemler(); //Burada sınıfı cagırıyorum ki switch case oncesi erişim icin


            switch (li.Name)
            {
                //begin switch


                case "rb1":
                    {
                        // Converts a String to a Point using a PointConverter
                        // Returns a Point.

                        var pConverter = new PointConverter();
                        var string1 = "10,20";

                        var pointResult = (Point)pConverter.ConvertFromString(string1);
                        // pointResult is equal to (10, 20)

                        // Displaying Results
                        syntaxString = "pointResult = (Point)pConverter1.ConvertFromString(string1);";
                        resultType = "Point";
                        operationString = "Converting a String to a Point";
                        ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb2":
                    {

                        islem.vektörGecis(); // Burada state(durum olarak vektör sectik)
                        islem.Tanımlama(); //komutlar calısır..
                        islem.Coz();
                        islem.göster("10", "20", "30", "40"); // değerleri salladık cunku kütüphaneden alıyor
                        //diger verileri ve ulasım sıkıntısı var.


                        break;
                    }

                case "rb3":
                    {
                        islem.matrixGecis(); // Ve burada State olarak matrix secildi ve gecis yaptırdık.
                        islem.Tanımlama(); //yine komutlar calıstırdık..
                        islem.Coz();
                        islem.göster("10", "20", "30", "40");

                        break;
                    }

                case "rb4":
                    {
                        // Converts a String to a Point3D using a Point3DConverter
                        // Returns a Point3D.

                        var p3DConverter = new Point3DConverter();
                        var string3 = "10,20,30";

                        var point3DResult = (Point3D)p3DConverter.ConvertFromString(string3);
                        // point3DResult is equal to (10, 20, 30)

                        // Displaying Results
                        syntaxString = "point3DResult = (Point3D)p3DConverter.ConvertFromString(string3);";
                        resultType = "Point3D";
                        operationString = "Converting a String into a Point3D";
                        ShowResults(point3DResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb5":
                    {
                        // Converts a String to a Vector3D using a Vector3DConverter
                        // Returns a Vector3D.

                        var v3DConverter = new Vector3DConverter();
                        var string3 = "10,20,30";

                        var vector3DResult = (Vector3D)v3DConverter.ConvertFromString(string3);
                        // vector3DResult is equal to (10, 20, 30)

                        // Displaying Results
                        syntaxString = "vector3DResult = (Vector3D)v3DConverter.ConvertFromString(string3);";
                        resultType = "Vector3D";
                        operationString = "Converting a String into a Vector3D";
                        ShowResults(vector3DResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb6":
                    {
                        // Converts a String to a Size3D using a Size3DConverter
                        // Returns a Size3D.

                        var s3DConverter = new Size3DConverter();
                        var string3 = "10,20,30";

                        var size3DResult = (Size3D)s3DConverter.ConvertFromString(string3);
                        // size3DResult is equal to (10, 20, 30)

                        // Displaying Results
                        syntaxString = "size3DResult = (Size3D)v3DConverter.ConvertFromString(string3);";
                        resultType = "Size3D";
                        operationString = "Converting a String into a Size3D";
                        ShowResults(size3DResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb7":
                    {
                        // Converts a String to a Point4D using a Point4DConverter
                        // Returns a Point4D.

                        var p4DConverter = new Point4DConverter();
                        var string4 = "10,20,30,40";

                        var point4DResult = (Point4D)p4DConverter.ConvertFromString(string4);
                        // point4DResult is equal to (10, 20, 30)

                        // Displaying Results
                        syntaxString = "point4DResult = (Point4D)v3DConverter.ConvertFromString(string3);";
                        resultType = "Point4D";
                        operationString = "Converting a String into a Point4D";
                        ShowResults(point4DResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }
            } //end switch
        }

        // Displays the results of the operation
        private void ShowResults(string resultValue, string syntax, string resultType, string opString)
        {
            txtResultValue.Text = resultValue;
            txtSyntax.Text = syntax;
            txtResultType.Text = resultType;
            txtOperation.Text = opString;
        }

        // Displays the values of the variables
        public void ShowVars()
        {
            var s1 = "10, 20";
            var s2 = "10, 20, 30, 40, 50, 60";
            var s3 = "10, 20, 30";
            var s4 = "10, 20, 30, 40";

            // Displaying values in Text objects

            txtString1.Text = s1;
            txtString2.Text = s2;
            txtString3.Text = s3;
            txtString4.Text = s4;
        }
    }
}