// ---- C# I (Dor Ben Dor) ----
// Ori Shacham-Barr
// ----------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C - Units, Combat, and the Beauty of RPGs

internal class Unit
{
    private int _maxHP;
    private int _currentHP;

    public int MaxHP 
    { 
        get 
        { 
            return _maxHP; 
        }
        private set 
        { 
            if (value > 0)
                _maxHP = value;
        }
    }
    public int CurrentHP
    {
        get
        {
            return _currentHP;
        }
        private set
        {
            if (value >= 0 && value <= MaxHP)
                _currentHP = value;
        }
    }
    public ArmorRating Armor { get; private set; }
    public Weapon MainWeapon { get; private set; }

    public Unit (int maxHP, int shield, float evasion, int damage, float hitChance)
    {
        MaxHP = maxHP;
        CurrentHP = MaxHP;
        Armor = new ArmorRating(shield, evasion);
        MainWeapon = new Weapon(damage, hitChance);
    }

    public bool TryAttack(Unit opponent)
    {
        if ((float)Random.Shared.NextDouble() > MainWeapon.HitChance)
            return false;

        if ((float)Random.Shared.NextDouble() < opponent.Armor.Evasion)
            return false;

        return true;
    }

    public void ReceiveAttack(Weapon weapon)
    {
        if (Armor.Shield < weapon.Damage)
            CurrentHP -= (weapon.Damage - Armor.Shield);
    }

    public void Heal(int health)
    {
        if (CurrentHP + health >= MaxHP)
            CurrentHP = MaxHP;
        else
            CurrentHP += health;
    }

    public void Heal()
    {
        CurrentHP = MaxHP;
    }

    public bool IsDead()
    {
        if (CurrentHP <= 0)
            return true;
        return false;
    }

    public void UpgradeShield()
    {
        Armor.UpgradeShield();
    }

    public void UpgradeEvasion(float upgradeValue)
    {
        Armor.UpgradeEvasion(upgradeValue);
    }

    public void UpgradeDamage()
    {
        MainWeapon.UpgradeDamage();
    }

    public void UpgradeHitChance(float upgradeValue)
    {
        MainWeapon.UpgradeHitChance(upgradeValue);
    }
}