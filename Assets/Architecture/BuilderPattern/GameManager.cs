// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using Architecture.BuilderPattern.EnemyModule;
using UnityEngine;

namespace Architecture.BuilderPattern
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            Enemy enemy = new Enemy.Builder()
                .WithName("EnemyA")
                .WithHealth(100)
                .WithDamage(10)
                .WithSpeed(1.0f)
                .Build();

            Instantiate(enemy);
            // or put in object pool, etc.
        }
    }
}