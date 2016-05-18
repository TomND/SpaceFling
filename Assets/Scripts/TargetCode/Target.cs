using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
   public GameObject winStuff;

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
         other.gameObject.SetActive(false);
         EnableWinStuff();
         }
   }

   void EnableWinStuff()
    {
      winStuff.SetActive(true);
   }
}
