namespace Interfaces
{
    /// <summary>
    /// Defines a contract that all damageable objects must adhere to.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// Health property for setting and getting the current health.
        /// Probably should have a private setter. 
        /// </summary>
        public int CurrentHealth { get; set; }
        
        /// <summary>
        /// Responsible for executing any code necessary when an
        /// object is damaged.  
        /// </summary>
        public void TakeDamage(int amount);
    }

    
}