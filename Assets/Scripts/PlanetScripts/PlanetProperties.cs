using UnityEngine;
using System.Collections;

public class PlanetProperties : MonoBehaviour {
   public float  mass;
   public float  massPowerTen;
   private float realMass;
   public float  radius;
   //public float  distanceToSun;



   // Use this for initialization
   void Start()
   {
      realMass = mass * Mathf.Pow(10, massPowerTen);
   }

   // Update is called once per frame
   void Update()
   {
   }

   public float GetMass()
   {
      return(realMass);
   }

   public float GetRadius()
   {
      return(radius);
   }
}
