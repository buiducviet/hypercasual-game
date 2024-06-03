using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using TMPro;

namespace Platformer.Mechanics
{
public class Message : MonoBehaviour
{
    public TextMeshProUGUI textMess;
    public float typingSpeed = 0.05f;
    public string message = "Hey human, I see your dire prospects at the gates of heaven if you continue to be greedy.";
    
    // Function called when player enter mess zone
    private void OnTriggerEnter2D(Collider2D collider){
    	var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
              textMess.gameObject.SetActive(true);
              StartCoroutine(TypeText());
              
            }
    }
    private void OnTriggerExit2D(Collider2D collider){
    	var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
            	 
            	 StopCoroutine(TypeText());
            	 textMess.text = "";
             	 textMess.gameObject.SetActive(false);
              
              
            }
    }
    private IEnumerator TypeText() {
    	textMess.text = "";
    	foreach (char letter in message.ToCharArray()){
    		textMess.text += letter;
    		yield return new WaitForSeconds(typingSpeed);
    	}
    }
    
}
}
