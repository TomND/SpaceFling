using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orbit : MonoBehaviour
{
   private PlanetProperties  properties;
   private Rigidbody         rb;
   private List <GameObject> planets = new List <GameObject>();
   public float initialForce;
   public bool         ignoreSun;

   // Use this for initialization
   void Start()
   {
      properties = GetComponent <PlanetProperties>();
      rb         = GetComponent <Rigidbody>();

      rb.AddForce(transform.up * initialForce);//100000
      planets = Detector.ReturnOtherPlanets(gameObject);
   }

   // Update is called once per frame
   void FixedUpdate()
   {
      CalculatePulls();
   }

   void ManageGravityPulls()
   {
   }

   void CalculatePulls()
   {
      foreach(GameObject planet in planets){
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
          //print((pull * pullStrength) / 1000000);
          //print(pull * pullStrength);
          rb.AddForce((pull * pullStrength) / 1000000, ForceMode.Acceleration);
          }
   }

   float GetDistance(GameObject other)
   {
      return(Vector3.Distance(transform.position, other.transform.position) * 100);
   }
}
