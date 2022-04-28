using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_OOP
{
    abstract class Trans
    {
        public string _mark;
        public string _number;
        public double _speed;
        public int _carrying;

        public Trans(string mark, string number, double speed)
        {
            _mark = mark;
            _number = number;
            _speed = speed;
        }

        public abstract void PrintInfo();
        public abstract void CarryingCalculation(int carrying);
    }
    class MotoCycle : Trans
    {
        public bool _carriage;
        public MotoCycle(string mark, double speed, string number, bool carriage) : base(mark, number, speed)
        {
            _carriage = carriage;
        }

        public override void CarryingCalculation(int carrying)
        {
            if (_carriage == false)
                _carrying = 0;
            else
                _carrying = carrying;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Марка: {_mark}\nСкорость: {_speed}\nНомер: {_number}\nГрузоподъемность: {_carrying}\nНаличие коляски: {_carriage}");
            Console.WriteLine();
        }
    }

    class PassengerCar : Trans
    {
        public PassengerCar(string mark, double speed, string number) : base(mark, number, speed)
        {

        }

        public override void CarryingCalculation(int carrying)
        {
            _carrying = carrying;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Марка: {_mark}\nСкорость: {_speed}\nНомер: {_number}\nГрузоподъемность: {_carrying}");
            Console.WriteLine();
        }
    }

    class Truck : Trans
    {
        public bool _trailer;
        public Truck(string mark, double speed, string number, bool trailer) : base(mark, number, speed)
        {
            _trailer = trailer;
        }

        public override void CarryingCalculation(int carrying)
        {
            if (_trailer == true)
                _carrying = carrying * 2;
            else
                _carrying = carrying;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Марка: {_mark}\nСкорость: {_speed}\nНомер: {_number}\nГрузоподъемность: {_carrying}\nНаличие прицепа: {_trailer}");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool RunMenu = true;
            int Checker = 0;
            Random random = new Random();   
            void BackOrNot()
            {
                Console.WriteLine("1-Вернуться 0-Выйти");
                int FuncChecker = System.Convert.ToInt32(Console.ReadLine());
                if (FuncChecker == 0)
                {
                    RunMenu = false;
                }
            }
            Trans[] transport = {new  MotoCycle("Suzuki", 220, "123A", false),
                           new MotoCycle("Honda", 160, "345B", true),
                           new PassengerCar("Audi", 140, "789C"),
                           new PassengerCar("Kia", 160, "456D"),
                           new Truck("MAN", 220, "852E", true),
                           new Truck("IVECO", 330, "951F", false)};
            for (int i = 0; i < transport.Length; i++)
            {
                int Carrying=random.Next(50,101);
                transport[i].CarryingCalculation(Carrying);
            }
            while (RunMenu==true)
            {
                Console.Clear();
                Console.WriteLine("1. Вывести на экран\n2. Найти по грузоподъемности\n ");
                Checker = System.Convert.ToInt32(Console.ReadLine()); 
                switch (Checker)
                {
                    case 1:
                        Console.Clear();
                        for (int i = 0; i < transport.Length; i++)
                        {
                            transport[i].PrintInfo();
                        }
                        BackOrNot();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите грузоподъемность\n ");
                        int Carrying = System.Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < transport.Length; i++)
                        {
                            if (transport[i]._carrying==Carrying)
                            {
                                transport[i].PrintInfo();
                            }
                        }
                        BackOrNot();
                        break;

                }
                   
            }
        }
    }
}
