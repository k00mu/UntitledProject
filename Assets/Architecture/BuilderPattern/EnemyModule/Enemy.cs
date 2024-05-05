// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

namespace Architecture.BuilderPattern.EnemyModule
{
    public class Enemy : MonoBehaviour
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public float Speed { get; private set; }
        public int Damage { get; private set; }

        public class Builder
        {
            // it's a good practice if it has default value
            private string name = "Enemy"; 
            private int health = 100;
            private float speed = 1.0f;
            private int damage = 10;

            public Builder WithName(string _name)
            {
                this.name = _name;
                return this;
            }

            public Builder WithHealth(int _health)
            {
                this.health = _health;
                return this;
            }

            public Builder WithSpeed(float _speed)
            {
                this.speed = _speed;
                return this;
            }

            public Builder WithDamage(int _damage)
            {
                this.damage = _damage;
                return this;
            }

            public Enemy Build()
            {
                var enemy = new GameObject($"Enemy_{name}").AddComponent<Enemy>();
                enemy.Name = name;
                enemy.Health = health;
                enemy.Speed = speed;
                enemy.Damage = damage;

                return enemy;
            }
        }
    }
}