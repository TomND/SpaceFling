using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Detector : MonoBehaviour {
   public static List <GameObject> planets = new List <GameObject>();
   private static GameObject       camera;

   // Use this for initialization
   void Start()
   {
      camera = Camera.main.gameObject;
   }

   // Update is called once per frame
   void Update()
   {
   }

   public static void ResetPlanets()
   {
      planets = new List <GameObject>();
   }

   public void ResetPlanetMasses()
   {
      foreach(GameObject planet in planets){
          planet.GetComponent <PlanetProperties>().SetStartValues();
          PlanetProperties props = planet.GetComponent <PlanetProperties>();
          props.SetStartValues();
          }

      camera.GetComponent <PlanetSelector>().ResetAll();

   }

   void OnTriggerEnter(Collider other)
   {
      if(other.tag == "Planet"){
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
      List <GameObject> otherPlanets = new List <GameObject>(planets);
      otherPlanets.Remove(self);

      return(otherPlanets);
   }

   public static void UpdatePlanet(GameObject planet, float value, int values = 0)
   {
      int index = planets.IndexOf(planet);

      //planets[index].GetComponent <PlanetProperties>().SetMass(2);


      PlanetProperties props = planets[index].GetComponent <PlanetProperties>();


      if(values == 1){
         props.SetMass(value);
         }
      else if(values == 2){
              props.SetMassPower(value);
              }
   }
}
