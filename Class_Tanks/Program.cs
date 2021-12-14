using System;

namespace Class_Tanks
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Tank
        {
          private  const double R = 2.3;
            string nametank { get; set; }
            string nationtank { get; set; }
            int years_of_development { get; set; }
            string armortank { get; set; }
            string calibrtank { get; set; }
            string cannontank { get; set; }
            string fuel { get; set; }
            int ammunation { get; set; }
            int speedtank { get; set; }
            string nameengine { get; set; }
            string carriagetank { get; set; }
         private  double Masstank { get; set; }
            double ScatteringTank { get; set; }
          private  double Damage { get; set; }
            int Deadtank { get; set; }
            public Tank(string _nametank, string _nationtank, int _year, string _armor, string _calibr, string _cannon, string _fuel, int _ammo, int _speed, string _nameengine, string _carriage, double _mass, double _scater,double _damage)
            {
                nametank = _nametank;
                nationtank = _nationtank;
                years_of_development = _year;
                armortank = _armor;
                calibrtank = _calibr;
                cannontank = _cannon;
                fuel = _fuel;
                ammunation = _ammo;
                speedtank = _speed;
                nameengine = _nameengine;
                carriagetank = _carriage;
                Masstank = _mass;
                ScatteringTank = _scater;
                Damage = _damage;
            }
            public class Armortank
            {
                public string namearmor;
                public string properties;
            }
            public class GomogenArmor : Armortank
            {
                public GomogenArmor()
                {
                    namearmor = "Гомогенная броня";
                    properties = "Броня от гомогеев";
                }
            }
            public class GomogenCatanArmor : Armortank
            {
                public GomogenCatanArmor()
                {
                    namearmor = "ГомогеннаяКатаная броня";
                    properties = "Броня от геев,которые катаются на дуле";
                }
            }
            public class CalibrTank 
            {
                public string calibrcannon;
                public string name_cannon;
            }
            public class M43 : CalibrTank 
            { 
                public M43()
                {
                    calibrcannon = "120-мм";
                    name_cannon = "М-43";
                }
            }
            public void PenitrationTank()
            {
                Console.WriteLine("Есть пробите!");
            }
            public void DamageTank()
            {
                Console.WriteLine("Ваш урон:" + Damage);
            }
            public static double DamageTank(int damage)
            {
                const int g = 15;
                return damage = (damage / 100 * g) + damage;
            }
            public void GunScattering()
            {
                ScatteringTank = R * SpeedTank();
            }
            public double SpeedTank()
            {
                const double YmolchanieEngine = 7.5;
                return Masstank * YmolchanieEngine;

            }
            public void DeadTank()
            {
                DeadTank(2);
            }
            public void DeadTank(int count)
            {
                Deadtank += count;
            }
            public void DeadTank(string message)
            {
                message = "Вас ёбнули";
            }
        }           
     } 
}
    

    

