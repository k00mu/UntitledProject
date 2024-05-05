// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

namespace Architecture.BuilderPattern.TrashModule
{
    public enum HouseholdGarbageClassification
    {
        Organic,
        Inorganic,
        Hazardous // B3
    }
    
    public class Trash : MonoBehaviour
    {
        public string Name { get; private set; }
        public HouseholdGarbageClassification Classification { get; private set; }
        public float Weight { get; private set; } // in kg
        public float Volume { get; private set; } // in m^3
        public float DecompositionTime { get; private set; } // -1 if not decomposable
        
        public class Builder
        {
            // it's a good practice if it has default value
            private string name = "Apple";
            private HouseholdGarbageClassification classification = HouseholdGarbageClassification.Organic;
            private float weight = 0.2f;
            private float volume = 0.07f;
            private float decompositionTime = 4380.0f;
            
            public Builder WithName(string _name)
            {
                this.name = _name;
                return this;
            }
            
            public Builder WithClassification(HouseholdGarbageClassification _classification)
            {
                this.classification = _classification;
                return this;
            }
            
            public Builder WithWeight(float _weight)
            {
                this.weight = _weight;
                return this;
            }
            
            public Builder WithVolume(float _volume)
            {
                this.volume = _volume;
                return this;
            }
            
            public Builder WithDecompositionTime(float _decompositionTime)
            {
                this.decompositionTime = _decompositionTime;
                return this;
            }
            
            public Trash Build()
            {
                var trash = new GameObject($"Trash_{name}").AddComponent<Trash>();
                trash.Name = name;
                trash.Classification = classification;
                trash.Weight = weight;
                trash.Volume = volume;
                trash.DecompositionTime = decompositionTime;
                
                return trash;
            }
        }
    }
}