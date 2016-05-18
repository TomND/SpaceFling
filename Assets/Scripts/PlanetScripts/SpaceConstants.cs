using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceConstants : MonoBehaviour
{
   private static float gravity = 6.673f * Mathf.Pow(10, -11);
   public float         time;
   public Text          timeVisualizer;
   public GameObject    spawnPoint;

   // Use this for initialization
   void Start()
   {
      timeVisualizer.text = "X " + time.ToString();
   }

   // Update is called once per frame
   void Update()
   {
      Time.timeScale = time;
   }

   public static float Gravity()
   {
      return(gravity);
   }

   public void IncreaseTime()
   {
      time += 1;
      if(time > 100){
         time = 100;
         }
      timeVisualizer.text = "X " + time.ToString();
   }

   public void IncreaseTimeFast()
   {
      time += 5;
      if(time > 100){
         time = 100;
         }
      timeVisualizer.text = "X " + time.ToString();
   }

   public void DecreaseTimeFast()
   {
      time -= 5;
      if(time < 0){
         time = 0;
         }
      timeVisualizer.text = "X " + time.ToString();
   }

   public void DecreaseTime()
   {
      time -= 1;
      if(time < 0){
         time = 0;
         }
      timeVisualizer.text = "X " + time.ToString();
   }

   public void SpawnMoon()
   {
      Instantiate(Resources.Load("Moon"), spawnPoint.transform.position, Quaternion.identity);
   }
}
