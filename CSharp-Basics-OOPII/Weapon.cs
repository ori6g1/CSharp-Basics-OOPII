// ---- C# I (Dor Ben Dor) ----
// Ori Shacham-Barr
// ----------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C - Units, Combat, and the Beauty of RPGs

internal class Weapon
{
    private int _damage;
    private float _hitChance;
    
    public int Damage
    {
        get
        {
            return _damage;
        }
        private set
        {
            if (value >= 0)
                _damage = value;
        }
    }
    public float HitChance
    {
        get
        {
            return _hitChance;
        }
        private set
        {
            if (value >= 0 && value <= 1)
                _hitChance = value;
        }
    }

    public Weapon (int damage, float hitChance)
    {
        Damage = damage;
        HitChance = hitChance;
    }

    public void UpgradeDamage()
    {
        Damage++;
    }

    public void UpgradeHitChance(float hitChanceUpgrade)
    {
        if (HitChance + hitChanceUpgrade >= 0.9f)
            HitChance = 0.9f;
        else
            HitChance += hitChanceUpgrade;
    }
}