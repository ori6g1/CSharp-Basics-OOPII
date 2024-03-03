// ---- C# I (Dor Ben Dor) ----
// Ori Shacham-Barr
// ----------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C - Units, Combat, and the Beauty of RPGs

internal class ArmorRating
{
    private int _shield;
    private float _evasion;

    public int Shield
    {
        get
        {
            return _shield;
        }
        private set
        {
            if (value >= 0)
                _shield = value;
        }
    }
    public float Evasion
    {
        get
        {
            return _evasion;
        }
        private set
        {
            if (value >= 0 && value <= 1)
                _evasion = value;
        }
    }

    public ArmorRating (int shield, float evasion)
    {
        Shield = shield;
        Evasion = evasion;
    }

    public void UpgradeShield()
    {
        Shield++;
    }

    public void UpgradeEvasion(float evasionUpgrade)
    {
        if (Evasion + evasionUpgrade >= 0.9f)
            Evasion = 0.9f;
        else
            Evasion += evasionUpgrade;
    }
}