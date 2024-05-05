// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

namespace Architecture.BuilderPattern.TrashModule
{
    public class TrashGenerator : MonoBehaviour
    {
        public void GenerateTrash()
        {
            var trash = new Trash.Builder().Build();
            Instantiate(trash);
        }
    }
}