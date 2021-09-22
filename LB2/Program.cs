using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1студент
            Student student = new Student("Даши", "Санжиев", "11.11.2000", "Мужской", 17, "ИСИТ", 3, 3000, false, 4);
            student.Write();
            student.Year();
            student.improveAvgRating();
            //Iclonable 2 студент
            Console.WriteLine("**************** Iclonable***************************");
            Student student2 = (Student)student.Clone();
            student2.Name = "Андрей";
            student2.Write();
            student2.Year();
            student2.improveAvgRating();
            Console.WriteLine("*******************************************");
            Sensei sensei = new Sensei("Иван", "Иванов", "11.11.2000", "Мужской", 56, 35, "Физика", 30000);
            sensei.Write();
            sensei.Year();
            sensei.improveSalary();
            Console.WriteLine("****************IAccount***************************");
            HeadDepartment headDepartment = new HeadDepartment("Андрей", "Иванов", "11.11.2000", "Мужской", 56, 35, "Физика", 30000, "ИСИТ", 3000,50000);
            headDepartment.Write();
            headDepartment.Year();  
            headDepartment.Hi();
            Console.WriteLine("****************Наследованные методы от интерфейса***************************");
            Console.WriteLine("Текущий счет: "+headDepartment.CurrentSum+"\n");
            headDepartment.Put(500);
            Console.WriteLine("Текущий счет (+500): " + headDepartment.CurrentSum + "\n");
            headDepartment.Withdraw(100);
            Console.WriteLine("Текущий счет (-100): " + headDepartment.CurrentSum + "\n");
            Console.ReadKey();
                    
        }
    }
    
    public class Person
    {
        public Person(string n, string s, string b, string sex,int y)
        {
            Name = n;
            Surname = s;
            Birth = b;
            Sex = s;
            Years = y;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birth { get; set; }
        public string Sex { get; set; }
        public int age;
        public int Years {
            set
            {
                if (value < 18)
                {
                    Console.WriteLine("Возраст должен быть больше 17");
                }
                else
                {
                    age = value;
                }
            }
            get { return age; }
        }
            
        public virtual void Write ()
        {
            Console.WriteLine("Имя: " + Name + "\nSurname: " + Surname + "\nДата Рождения: " + Birth + "\nПол: " + Sex);

        }
        public void Year()
        {
            Console.WriteLine("Год рождения: "+Convert.ToString(DateTime.Now.Year-Years));
        }
      

    }
    public class Student : Person,ICloneable
    {
        public Student(string n, string s, string b, string sex, int y, string d, int c, int scholar, bool debt, int av) : base(n, s, b, sex,y)
        {
            Direction = d;
            Course = c;
            Scholarships = scholar;
            Debt = debt;
            AverageRating = av;

        }

        public string Direction { get; set; }
        public int Course { get; set; }
        public int Scholarships { get; set; }
        public bool Debt { get; set; }

        public int AverageRating { get; set; }
        public void improveAvgRating ()
        {
            AverageRating++;
            Console.WriteLine("Рейтинг улучшен.");

        }
        public override void Write()
        {
            base.Write();
            Console.WriteLine("Направление: "+Direction+"\nКурс: "+Course+"\nСтипендия: "+Scholarships+"\nНаличие долга: "+ Debt+"\nСредний рейтинг: "+ AverageRating);

        }
        //Реализация интерфейса
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class Sensei : Person
    {
        public Sensei(string n, string s, string b, string sex, int y, int E, string Sub, int salary) : base(n, s, b, sex,y)
        {
            Experience = E;
            Subject = Sub;
            Salary = salary;
        }
        public int Experience { get; set; }
        public string Subject { get; set; }
        public int Salary { get; set; }

        public void improveSalary()
        {
            Salary = Salary + 20000;
            Console.WriteLine("Зарплата увеличена. Теперь: "+Salary);
        }
        public override void Write()
        {
            base.Write();
            Console.WriteLine("Стаж: " + Experience + "\nПредмет: " + Subject + "\nЗарплата: " + Salary);

        }
    }
    interface IAccount
    {
        int CurrentSum { get; }  // Текущая сумма на счету
        void Put(int sum);      // Положить деньги на счет
        void Withdraw(int sum); // Взять со счета
    }

    public class HeadDepartment : Sensei, IAccount
    {
        public HeadDepartment(string n, string s, string b, string sex, int y, int E, string Sub, int salary,string Dep,int Subor, int Acco) : base(n, s, b,  sex, y, E,Sub,salary)
        {
            Department = Dep;
            Subordinates = Subor;
            Accountsum = Acco;
        }
        public string Department  { get; set; }
        public int Subordinates { get; set; }

        public int Accountsum { get; set; }


        public int CurrentSum { get { return Accountsum; } }
        public void Put(int sum) { Accountsum += sum; }
        public void Withdraw(int sum)
        {
            if (Accountsum >= sum)
            {
                Accountsum -= sum;
            }
        }
        public void Hi()
        {
            Console.WriteLine("Привет! ");
        }
        public override void Write()
        {
            base.Write();
            Console.WriteLine("Подразделение: " + Department + "\nПодчиненные: "+Subordinates);

        }

    }
}
