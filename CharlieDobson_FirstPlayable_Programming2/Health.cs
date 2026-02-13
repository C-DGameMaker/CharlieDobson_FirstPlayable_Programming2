using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Health
    {
        //Making a health class to be use by both player and Enemy
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }

        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
        }

        //Will heal and never go above max health
        public void Heal(int _amount)
        {
            CurrentHealth = CurrentHealth + _amount;

            if(CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }

        //Will cause the character to take damage, will never go below 0
        public void TakeDamage(int _amount)
        {
            CurrentHealth = CurrentHealth - _amount;

            if(CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }

        //Resets Health

        public void ResetHealth()
        {
            CurrentHealth = MaxHealth;
        }
    }
}
