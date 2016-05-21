using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Detector : MonoBehaviour
{
  /*
  * Contains A list of all planets in the scene, and contains methods in order to utilize those planets for other classes
  */
   public static List <GameObject> planets = new List <GameObject>();// list of all planets
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
      /*
      *   Resets planets list
      */
      planets = new List <GameObject>();
   }

   public void ResetPlanetMasses()
    {
      /*
      * Resets the mass of each planet to its value at the beggining of the game
      */
      foreach(GameObject planet in planets){
          planet.GetComponent <PlanetProperties>().SetStartValues();
          PlanetProperties props = planet.GetComponent <PlanetProperties>();
          props.SetStartValues();
          }

      camera.GetComponent <PlanetSelector>().ResetAll();

   }

   void OnTriggerEnter(Collider other)
    {
      /*
      * all planets detected to planets list
      */
      if(other.tag == "Planet"){
         planets.Add(other.gameObject);
         }
   }

   //returns the closest planet to other
   public static GameObject ClosestPlanet(GameObject other)
    {
      /*
      * returns the closest planet to other
      */
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
      /*
      * returns all planets in planets that are not self
      */
      List <GameObject> otherPlanets = new List <GameObject>(planets);
      otherPlanets.Remove(self);

      return(otherPlanets);
   }

   public static void UpdatePlanet(GameObject planet, float value, int values = 0)
    {
      /*
      * updates planet in planets with new mass or mass power value
      */
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
