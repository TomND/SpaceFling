using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orbit : MonoBehaviour
{
  /*
  * This class handles the calculations of the force from other planets and applies that force
  */
   private PlanetProperties properties;   // reference to PlanetProperties script
   private Rigidbody        rb;           // the Rigidbody
   public float             initialForce; // initialforce to apply to the plabnet
   public bool ignoreSun;                 // if true, ignores gravity pull from Sun

   // Use this for initialization
   void Start()
   {
      properties = GetComponent <PlanetProperties>();
      rb         = GetComponent <Rigidbody>();

      rb.AddForce(transform.up * initialForce);
   }

   // Update is called once per frame
   void FixedUpdate()
   {
      CalculatePulls();
      if(Input.GetButtonDown("Debug")){
         print(Detector.ReturnOtherPlanets(gameObject));
         }
   }

   void ManageGravityPulls()
   {
   }

   void CalculatePulls()
   {
      /*
       * Calculated the gravitational Pull affecting the planet, and applies the force the planet
       * force is currently divided by a factor of 1000000 for the current scenario scenes.
       */
      if(Detector.planets.Count == 0){ // planets don't get discovered for a few frames. temporary fix
         return;
         }
      foreach(GameObject planet in Detector.planets){
          if(planet == gameObject){
             continue;
             }
          if(ignoreSun){
             if(planet.layer == 8){
                continue;
                }
             }

          PlanetProperties props = planet.GetComponent <PlanetProperties>();
          Vector3          pull  = planet.transform.position - transform.position;
          pull.Normalize();
          if(Input.GetButtonDown("Debug")){
             print(props.GetMass());
             }

          float pullStrength = (SpaceConstants.Gravity() * props.GetMass()) / Mathf.Pow(GetDistance(planet), 2);

          try{
             rb.AddForce((pull * pullStrength) / 1000000, ForceMode.Acceleration);
          }
          catch{
          }
          }
   }

   float GetDistance(GameObject other)
   {
      /*
       * Returns the distance to another object, multiplied by 100 to get simulated values
       */
      return(Vector3.Distance(transform.position, other.transform.position) * 100);
   }
}
