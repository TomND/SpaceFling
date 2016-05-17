using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlanetSelector : MonoBehaviour
{
   public InputField  inputField;
   public Scrollbar   scrollBar;
   public GameObject  UI;
   public Text        multiplier;
   private GameObject currentPlanet;
   private bool       validSetup = false;

   // Use this for initialization
   void Start()
   {
   }

   // Update is called once per frame
   void Update()
   {
      Selector();
   }

   void Selector()
   {
      if(Input.GetButtonDown("Fire1")){
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         RaycastHit hit;
         if(Physics.Raycast(ray, out hit, 1000000)){
            if(hit.collider.gameObject.tag == "Planet"){
               validSetup = false;
               SetupUI(hit.collider.gameObject);
               }
            else{
                print("here");
                UI.SetActive(false);
                }
            }
         }
   }

   void SetupUI(GameObject planet)
   {
      currentPlanet = planet;
      PlanetProperties props = planet.GetComponent <PlanetProperties>();

      inputField.text = props.GetMassConstant().ToString();
      multiplier.text = props.GetMassPower().ToString();
      scrollBar.value = props.GetMassPower() / 30;

      UI.SetActive(true);
      validSetup = true;
   }

   void TextUpdate()
   {
      if(UI.activeSelf && validSetup){
         float value;
         try{
            value = float.Parse(inputField.text);
         }
         catch{
            return;
         }
         if(value > 100){
            value           = 100;
            inputField.text = 100.ToString ();
            }

         Detector.UpdatePlanet(currentPlanet, value, 1);
         }
   }

   void SliderUpdate()
   {
      if(UI.activeSelf && validSetup){
         float value;
         try{
            value = 30 * scrollBar.value;
         }
         catch{
            return;
         }

         multiplier.text = value.ToString();
         Detector.UpdatePlanet(currentPlanet, value, 2);
         }
   }

   public void SliderTextUpdate()
   {
      if(UI.activeSelf && validSetup){
         float value;
         try{
            value = 30 * scrollBar.value;
         }
         catch{
            return;
         }

         multiplier.text = value.ToString();
         }
   }

   public void UpdateAll()
   {
      SliderUpdate();
      TextUpdate();
   }
}
