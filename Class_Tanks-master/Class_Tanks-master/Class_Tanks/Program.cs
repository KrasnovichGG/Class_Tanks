using System;

namespace Class_Tanks
{
    public delegate void Message(string message);
    public delegate void Death(Tank tank);

    class Program
    {
        static void Main(string[] args)
        {
            Tank tank = new Tank();
            Tank tank2 = new Tank();
            tank.armor = new GomogenArmor();
            tank.calibr = new M43();
            tank.Shoot(tank2, 99);
            tank.Shoot(tank2, 1004);
        }
    }

    public class Tank
    {
        private int hp = 100;
        private const double R = 2.3;
        string nametank { get; set; }
        public int Hp { get => hp; }
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
        private double Masstank { get; set; }
        double ScatteringTank { get; set; }
        private double Damage { get; set; }
        int Deadtank { get; set; }
        public IArmor armor { get; set; }
        public ICalibrTank calibr { get; set; }
        Message mess = Console.WriteLine;
        public event Death death;

        public Tank(string _nametank, string _nationtank, int _year, string _armor, string _calibr, string _cannon, string _fuel, int _ammo, int _speed, string _nameengine, string _carriage, double _mass, double _scater, double _damage)
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

        public Tank()
        {

        }

        public void PenitrationTank()
        {
            mess("Есть пробитие!");
            hp = hp - (int)Damage;
            death?.Invoke(this);
        }

        public void DamageTank()
        {
            mess("Ваш урон:" + Damage);
        }

        public void DamageTank(Tank tank, int damage)
        {
            const int g = 15;
            mess("Ваш урон:" + damage);
            tank.Damage = (damage / 100 * g) + damage;
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
            DeadTank("Вас ёбнули");
        }

        public void DeadTank(int count)
        {
            Deadtank += count;
        }

        public void DeadTank(string message)
        {
            mess(message);
        }
    }

    abstract class Armortank : IArmor
    {
        public string Name { get; set; }
        public string Properties { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    class GomogenArmor : Armortank
    {
        public GomogenArmor()
        {
            Name = "Гомогенная броня";
            Properties = "Броня от гомогеев";
        }
    }

    class GomogenCatanArmor : Armortank
    {
        public GomogenCatanArmor()
        {
            Name = "ГомогеннаяКатаная броня";
            Properties = "Броня от геев,которые катаются на дуле";
        }
    }

    abstract class CalibrTank : ICalibrTank
    {
        public string CalibrCannon { get; set; }
        public string NameCannon { get; set; }

        public override string ToString()
        {
            return $"{NameCannon} {CalibrCannon}";
        }
    }

    class M43 : CalibrTank
    {
        public M43()
        {
            CalibrCannon = "120-мм";
            NameCannon = "М-43";
        }
    }

    static class Extension
    {
        public static void Shoot(this Tank tank1, Tank tank2, int damage)
        {
            tank2.death += CheckDeath;
            tank1.DamageTank(tank2, damage);
            tank2.PenitrationTank();
        }

        public static void CheckDeath(Tank tank)
        {
            if (tank.Hp <= 0)
            {
                tank.DeadTank();
            }
        }
    }

    

    
}