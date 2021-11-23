using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog_Box : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] Comments;
    private int index;
    public float typingspeed;
    public GameObject continueButton;
    public GameObject Break;

    // Start is called before the first frame update
    void Start()
    {
	
     	StartCoroutine(Type());
        
    }

    // Update is called once per frame
    void Update()
    {
	if(textDisplay.text == Comments[index]){
		continueButton.SetActive(true);

		  
	} 
	
	
	
    }

    IEnumerator Type(){
    	foreach(char letter in Comments[index].ToCharArray()){
		textDisplay.text += letter;
		yield return new WaitForSeconds(typingspeed);
        }
	if(index == Comments.Length - 1){
		index++;
		textDisplay.text = null;
		//StartCoroutine(Type());
	} 
    }



    public void Nextsentence(){
	continueButton.SetActive(false);
	if(index < Comments.Length - 1){
		index++;
		textDisplay.text = "";
		StartCoroutine(Type());
	} 
	if(index == Comments.Length - 1){
		//index++;
		textDisplay.text = null;
		//StartCoroutine(Type());
	} 
    }
   

    
}
