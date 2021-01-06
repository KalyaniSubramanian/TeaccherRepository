using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Channels;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            doApp();
        }

        public static void doApp()
        {
            string dir = Directory.GetCurrentDirectory();
            string filename = dir + "Teacher.txt";

            if (File.Exists(filename))
                Console.WriteLine(filename + " exists");
            else
                Console.WriteLine(filename + " does not exist");

            using (StreamWriter wrt = File.CreateText(filename))
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Enter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Name:  ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Class and Section:  ");
                    string cs = Console.ReadLine();
                    wrt.WriteLine(id + "," + name + "," + cs);
                }
            }
            Console.WriteLine(filename + " created");

            string[] lines = File.ReadAllLines(filename);
            foreach (string s in lines)
            {
                Console.WriteLine(s);
            }
            Console.Write("\n\n Append some text to an existing file  :\n");
            using (StreamWriter file = new StreamWriter(filename, true))
            {
                Console.WriteLine("No of inputs to be added:");
                int n = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Enter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Name:  ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Class and Section:  ");
                    string cs = Console.ReadLine();
                    file.WriteLine(id + "," + name + "," + cs);
                }
            }
            Console.WriteLine(" Here is the content of the file after appending the text : ");
            string[] line = File.ReadAllLines(filename);
            foreach (string s in line)
            {
                Console.WriteLine(s);
            }
        }
    }
}

