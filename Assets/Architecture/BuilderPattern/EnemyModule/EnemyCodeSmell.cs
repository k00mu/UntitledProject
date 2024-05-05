// ==================================================
//
//   Created by Atqa Munzir
//
// ==================================================

using UnityEngine;

namespace Architecture.BuilderPattern.EnemyModule
{
    // why this code smell?
    // - constructor hell (too many constructor parameters)
    // - telescoping constructors
    public class EnemyCodeSmell : MonoBehaviour
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public float Speed { get; private set; }
        public int Damage { get; private set; }

        public EnemyCodeSmell(string name)
        {
            Name = name;
        }

        public EnemyCodeSmell(string name, int health) : this(name)
        {
            Health = health;
        }
        
        public EnemyCodeSmell(string name, int health, float speed) : this(name, health)
        {
            Speed = speed;
        }

        public EnemyCodeSmell(string name, int health, float speed, int damage) : this(name, health, speed)
        {
            Damage = damage;
        }
    }
}