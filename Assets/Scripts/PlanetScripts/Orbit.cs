using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orbit : MonoBehaviour
{
   private PlanetProperties properties;
   private Rigidbody        rb;
   public float             initialForce;
   public bool ignoreSun;

   // Use this for initialization
   void Start()
   {
      properties = GetComponent <PlanetProperties>();
      rb         = GetComponent <Rigidbody>();

      rb.AddForce(transform.up * initialForce);
      //planets = Detector.ReturnOtherPlanets(gameObject);
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
          //print(planet);
          //print("i am" + planet);

          PlanetProperties props = planet.GetComponent <PlanetProperties>();
          Vector3          pull  = planet.transform.position - transform.position;
          pull.Normalize();
          if(Input.GetButtonDown("Debug")){
             print(props.GetMass());
             }

          float pullStrength = (SpaceConstants.Gravity() * props.GetMass()) / Mathf.Pow(GetDistance(planet), 2);

          rb.AddForce((pull * pullStrength) / 1000000, ForceMode.Acceleration);
          }
   }

   float GetDistance(GameObject other)
   {
      return(Vector3.Distance(transform.position, other.transform.position) * 100);
   }
}
