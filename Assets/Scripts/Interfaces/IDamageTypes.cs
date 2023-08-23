
using System;

namespace Interfaces
{
    /// IMPORTANT: If adding new damage types, must set value to a power of 2 like below.
    /// This is for the bitwise operation so that if the value is checked i can be used in
    /// boolean operations (can check if the attack type of the light blasts are one of the
    /// values in the list of weaknesses if an enemy has multiple weakness for instance.
    
    public interface IDamageType
    {
        [Flags]
        public enum DamageType { FIRE = 1, ICE = 2, POISON = 4}
    }
}
