// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections.Generic;
using UnityEngine;

namespace Architecture.BuilderPattern.TrashModule
{
    public class Dumpster : MonoBehaviour
    {
        [SerializeField] private HouseholdGarbageClassification classification;
        private List<Trash> trashList;

        private void Start()
        {
            trashList = new List<Trash>();
        }
        
        public void AddTrash(Trash trash)
        {
            trashList.Add(trash);
        }
        
        public void RemoveTrash(Trash trash)
        {
            trashList.Remove(trash);
        }

        public List<Trash> GetAllTrashFilteredByClassification()
        {
            return trashList.FindAll(x => x.Classification == classification);
        }
    }
}