using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace BashNY
{
    public partial class Form1 : Form
    {
        Unit hero = new Unit();
        Unit currentEnemy;
        EnemyDatabase enemyDb;
        ItemDatabase itemDb;

        int currentFloor = 1;
        Random rnd = new Random();
        List<ItemData> currentLootOptions = new List<ItemData>();

        public Form1()
        {
            InitializeComponent();
            LoadData();
            InitHero();
            SpawnEnemy();
        }

        private void LoadData()
        {
            try
            {
                string enemiesJson = File.ReadAllText(Path.Combine(Application.StartupPath, "enemies.json"), Encoding.UTF8);
                enemyDb = JsonSerializer.Deserialize<EnemyDatabase>(enemiesJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                string itemsJson = File.ReadAllText(Path.Combine(Application.StartupPath, "items.json"), Encoding.UTF8);
                itemDb = JsonSerializer.Deserialize<ItemDatabase>(itemsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void InitHero()
        {
            hero.Name = "Саша";
            hero.MaxHealth = 30;
            hero.Health = 30;
            hero.Damage = 10;
            hero.Armor = 3;
            hero.BaseArmor = 3;
            hero.AttackSpeed = 1200;
            hero.CritMultiplier = 1.1;
            hero.CritChance = 0.05;
            hero.Evasion = 0.05;

            string heroPath = Path.Combine(Application.StartupPath, "Images", "Heroes", "hero_idle.png");
            if (File.Exists(heroPath)) pbHero.Image = Image.FromFile(heroPath);
        }

        private void SpawnEnemy()
        {
            EnemyData data = null;
            if (currentFloor == 4) data = enemyDb.MidBosses[rnd.Next(enemyDb.MidBosses.Count)];
            else if (currentFloor == 8) data = enemyDb.FinalBosses[rnd.Next(enemyDb.FinalBosses.Count)];
            else if (currentFloor >= 5 && currentFloor <= 7) data = enemyDb.Unique[rnd.Next(enemyDb.Unique.Count)];
            else data = enemyDb.Regular[rnd.Next(enemyDb.Regular.Count)];

            currentEnemy = new Unit
            {
                Name = data.Name,
                MaxHealth = data.MaxHealth,
                Health = data.MaxHealth,
                Damage = data.Damage,
                AttackSpeed = data.AttackSpeed,
                SpriteName = data.SpriteName,
                Evasion = 0.05
            };

            UpdateEnvironment();

            hero.Health = hero.MaxHealth;
            hero.Armor = hero.BaseArmor;

            rtbLog.AppendText($"\n--- ЭТАЖ {currentFloor} ---\nВраг: {currentEnemy.Name}\n");
            UpdateUI();
            StartCombat();
        }

        private void UpdateEnvironment()
        {
            try
            {
                string bgFile = "bg_low_floors.png";
                if (currentFloor == 4) bgFile = "bg_mid_boss.png";
                else if (currentFloor >= 5 && currentFloor <= 7) bgFile = "bg_high_floors.png";
                else if (currentFloor == 8) bgFile = "bg_final_boss.png";

                string bgPath = Path.Combine(Application.StartupPath, "Images", "Backgrounds", bgFile);
                string enemyPath = Path.Combine(Application.StartupPath, "Images", "Enemies", $"{currentEnemy.SpriteName}.png");

                if (File.Exists(bgPath)) panel1.BackgroundImage = Image.FromFile(bgPath);
                if (File.Exists(enemyPath)) pbEnemy.Image = Image.FromFile(enemyPath);
            }
            catch (Exception ex) { rtbLog.AppendText($"\nОшибка графики: {ex.Message}"); }
        }

        private void StartCombat()
        {
            timerHero.Interval = hero.AttackSpeed;
            timerEnemy.Interval = currentEnemy.AttackSpeed;
            timerHero.Start();
            timerEnemy.Start();
        }

        private void timerHero_Tick(object sender, EventArgs e)
        {
            CombatAction(hero, currentEnemy);
            if (currentEnemy.Health <= 0) FinishBattle(true);
        }

        private void timerEnemy_Tick(object sender, EventArgs e)
        {
            CombatAction(currentEnemy, hero);
            if (hero.Health <= 0) FinishBattle(false);
        }

        private void CombatAction(Unit attacker, Unit target)
        {
            if (rnd.NextDouble() < target.Evasion)
            {
                rtbLog.AppendText($"{target.Name} уклонился!\n");
                return;
            }

            int dmg = attacker.Damage;
            if (rnd.NextDouble() < attacker.CritChance) dmg = (int)(dmg * attacker.CritMultiplier);

            if (target.Armor > 0)
            {
                if (dmg <= target.Armor) target.Armor -= dmg;
                else { int rem = dmg - target.Armor; target.Armor = 0; target.Health -= rem; }
            }
            else target.Health -= dmg;

            UpdateUI();
        }

        private void UpdateUI()
        {
            hpBarHero.Maximum = hero.MaxHealth;
            hpBarHero.Value = Math.Max(0, hero.Health);
            hpBarEnemy.Maximum = currentEnemy.MaxHealth;
            hpBarEnemy.Value = Math.Max(0, currentEnemy.Health);

            lblHeroStats.Text = $"Урон: {hero.Damage} | Броня: {hero.Armor}";
            lblEnemyStats.Text = $"Урон: {currentEnemy.Damage} | HP: {currentEnemy.Health}";
        }

        private void FinishBattle(bool won)
        {
            timerHero.Stop();
            timerEnemy.Stop();

            if (won)
            {
                rtbLog.AppendText("Победа!\n");
                if (currentFloor < 8) ShowLoot();
                else MessageBox.Show("Башня пройдена!");
            }
            else
            {
                MessageBox.Show("Поражение...");
                Application.Restart();
            }
        }

        private void ShowLoot()
        {
            currentLootOptions.Clear();
            var allItems = itemDb.Weapons.Concat(itemDb.Armor).ToList();
            for (int i = 0; i < 3; i++) currentLootOptions.Add(allItems[rnd.Next(allItems.Count)]);

            btnLoot1.Text = currentLootOptions[0].Name;
            btnLoot2.Text = currentLootOptions[1].Name;
            btnLoot3.Text = currentLootOptions[2].Name;

            btnLoot1.Visible = btnLoot2.Visible = btnLoot3.Visible = true;
        }

        private void btnLoot_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int idx = int.Parse(b.Name.Replace("btnLoot", "")) - 1;
            ApplyItem(currentLootOptions[idx]);

            btnLoot1.Visible = btnLoot2.Visible = btnLoot3.Visible = false;
            currentFloor++;
            SpawnEnemy();
        }

        private void ApplyItem(ItemData item)
        {
            string[] weapons = { "Меч", "Кинжал", "Дубина", "Эсток", "Топор" };
            if (weapons.Contains(item.Category))
            {
                hero.Damage = item.Damage;
                hero.AttackSpeed = item.AttackSpeed;
                hero.CritChance = item.CritChance;
                hero.CritMultiplier = item.CritMultiplier;
            }
            else
            {
                hero.BaseArmor += item.ArmorValue;
                hero.MaxHealth += item.HealthBonus;
            }
            rtbLog.AppendText($"Выбрано: {item.Name}\n");
        }
    }

    // Классы данных для десериализации 
    public class Unit
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Armor { get; set; }
        public int BaseArmor { get; set; }
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }
        public double CritMultiplier { get; set; }
        public double CritChance { get; set; }
        public double Evasion { get; set; }
        public string SpriteName { get; set; }
    }

    public class EnemyData
    {
        public string Name { get; set; }
        public string SpriteName { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }
    }

    public class EnemyDatabase
    {
        public List<EnemyData> Regular { get; set; }
        public List<EnemyData> Unique { get; set; }
        public List<EnemyData> MidBosses { get; set; }
        public List<EnemyData> FinalBosses { get; set; }
    }

    public class ItemData
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }
        public double CritChance { get; set; }
        public double CritMultiplier { get; set; }
        public int ArmorValue { get; set; }
        public int HealthBonus { get; set; }
    }

    public class ItemDatabase
    {
        public List<ItemData> Weapons { get; set; }
        public List<ItemData> Armor { get; set; }
    }
}