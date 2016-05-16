using UnityEngine;
using System.Collections;

public class SpaceConstants : MonoBehaviour
{
   private static float gravity = 6.673f * Mathf.Pow(10, -11);
   public float         time;

   // Use this for initialization
   void Start()
   {
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
}
