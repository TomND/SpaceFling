using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Detector : MonoBehaviour {
   private static List <GameObject> planets = new List <GameObject>();

   // Use this for initialization
   void Start()
   {
   }

   // Update is called once per frame
   void Update()
   {
   }

   void OnTriggerEnter(Collider other)
   {
      if(other.tag == "Planet"){
         //print(other.gameObject);
         planets.Add(other.gameObject);
         }
   }

   //returns the closest planet to other
   public static GameObject ClosestPlanet(GameObject other)
   {
      GameObject closest = planets[0];

      for(int i = 0; i < planets.Count; i++){
          if(Vector3.Distance(planets[i].transform.position, other.transform.position) < Vector3.Distance(closest.transform.position, other.transform.position)){
             closest = planets[i];
             }
          }
      return(closest);
   }

   // returns all planets from planets except self
   public static List <GameObject> ReturnOtherPlanets(GameObject self)
   {
      //print(planets);
      List <GameObject> otherPlanets = planets;
      otherPlanets.Remove(self);
      //print(planets);
      return(otherPlanets);
   }
}
