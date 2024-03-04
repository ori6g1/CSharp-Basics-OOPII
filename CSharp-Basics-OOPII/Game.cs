// ---- C# I (Dor Ben Dor) ----
// Ori Shacham-Barr
// ----------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C - Units, Combat, and the Beauty of RPGs
enum Upgrades
{
    shield,
    evasion,
    damage,
    hitChance,
}

enum PlayerActions
{
    attack,
    heal,
}

internal class Game
{
    private Unit _player;
    private Unit _enemy;

    public Game ()
    {
        _player = new Unit(10, 0, 0.3f, 2, 0.7f);
        _enemy = new Unit(10, 0, 0.2f, 1, 0.5f);
    }
    
    public void StartGame()
    {
        while (_player.CurrentHP > 0)
        {
            if (_enemy.CurrentHP <= 0)
            {
                GenerateUpgradedEnemy();
                UpgradePlayer();
            }

            PrintStats();
            DoPlayerAction();
            EnemyAttack();
        }
        PrintGameOver();
    }

    private void EnemyAttack()
    {
        if (_enemy.TryAttack(_player))
        {
            _player.ReceiveAttack(_enemy.MainWeapon);
            Console.WriteLine("The enemy's attack hit you.");
        }
        else
            Console.WriteLine("The enemy's attack missed you.");
        Console.WriteLine("\r\n");
    }

    private void DoPlayerAction()
    {
        Console.WriteLine("Choose an action:\r\n\t1. Attempt an attack\r\n\t2. Heal 2");

        string input = Console.ReadLine();
        Console.WriteLine("\r\n");
        switch (input)
        {
            case "1":
                if (_player.TryAttack(_enemy))
                {
                    _enemy.ReceiveAttack(_player.MainWeapon);
                    Console.WriteLine("Your attack hit the enemy.");
                }
                else
                    Console.WriteLine("Your attack missed the enemy");
                break;
            case "2":
                _player.Heal(2);
                Console.WriteLine("You healed 2 HP.");
                break;
            default:
                Console.WriteLine("You have chosen no action.");
                break;
        }
    }

    private void PrintStats()
    {
        Console.WriteLine($"\tPlayer Stats:\r\n\tHP: {_player.CurrentHP}\r\n\tDamage: {_player.MainWeapon.Damage}" +
            $"\r\n\tShield: {_player.Armor.Shield}\r\n");
        Console.WriteLine($"\tEnemy Stats:\r\n\tHP: {_enemy.CurrentHP}\r\n\tDamage: {_enemy.MainWeapon.Damage}" +
            $"\r\n\tShield: {_enemy.Armor.Shield}\r\n");
        Console.WriteLine("\r\n");
    }

    private void UpgradePlayer()
    {
        Console.WriteLine("You have defeated an enemy. Choose an upgrade:\r\n\t1. Upgrade weapon\r\n\t2. Upgrade shield");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                _player.UpgradeDamage();
                Console.WriteLine("Your weapon's damage has upgraded by 1.");
                break;
            case "2":
                _player.UpgradeShield();
                Console.WriteLine("Your weapon's shield has upgraded by 1.");
                break;
            default:
                Console.WriteLine("You have chosen no upgrade.");
                break;
        }
    }

    private void GenerateUpgradedEnemy()
    {
        _enemy.Heal();
        int randomStatUpgrade = Random.Shared.Next(0, 3);
        switch (randomStatUpgrade)
        {
            case (int)Upgrades.shield:
                _enemy.UpgradeShield();
                break;
            case (int)Upgrades.evasion:
                _enemy.UpgradeEvasion(0.02f);
                break;
            case (int)Upgrades.damage:
                _enemy.UpgradeDamage();
                break;
            case (int)Upgrades.hitChance:
                _enemy.UpgradeEvasion(0.05f);
                break;
        }
    }

    private void PrintGameOver()
    {
        Console.WriteLine("You have lost!");
    }
}
