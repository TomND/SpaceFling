using UnityEngine;
using System.Collections;

public class PlanetProperties : MonoBehaviour
{
  /*
  * Contains information on a aplanet and methods to access or change those values
  */
   public float  mass;
   public float  massPowerTen;
   private float realMass;
   public float  radius;
   private float  startMass;
   private float  startMassPowerTen;
   private float  startRealMass;
   //public float  distanceToSun;



   // Use this for initialization
   void Start()
   {
      realMass          = mass * Mathf.Pow(10, massPowerTen);
      startMass         = mass;
      startMassPowerTen = massPowerTen;
      startRealMass     = realMass;
   }

   public void SetStartValues()
   {
      SetMass(startMass);
      SetMassPower(startMassPowerTen);
   }

   // Update is called once per frame
   void Update()
   {
   }

   void UpdateRealMass()
   {
      realMass = mass * Mathf.Pow(10, massPowerTen);
   }

   public float GetMassConstant()
   {
      return(mass);
   }

   public float GetMassPower()
   {
      return(massPowerTen);
   }

   public float GetMass()
   {
      return(realMass);
   }

   public float GetRadius()
   {
      return(radius);
   }

   public void SetMass(float newMass)
   {
      mass = newMass;
      UpdateRealMass();
   }

   public void SetMassPower(float newMassPower)
   {
      massPowerTen = newMassPower;
      UpdateRealMass();
   }
}
