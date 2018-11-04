using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text questmastertext;
	public Text questtext;

	private Rigidbody rb;
	private int questscomplete = 0;
	private bool quest1 = false;
	private bool quest2 = false;
	private bool quest3 = false;
	private bool quest4 = false;

	void Start () {
		rb = GetComponent<Rigidbody>();
		questmastertext.text = "";
		questtext.text = "";
	}
	
	
	void FixedUpdate () {
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 ( moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("QuestMaster")) {
			if (questscomplete == 0) {

				questmastertext.text = "For your first quest, you must enter the green corner. This is where you will find the key.";
				questtext.text = "";
				quest1 = true;
				
			}
			else if (questscomplete == 1) {
				questmastertext.text = "For your second quest, you must enter the orange corner. This is where you will find the door.";
				questtext.text = "";
				quest2 = true;
			}
			else if (questscomplete == 2) {

				questmastertext.text = "For your second quest, you must enter the pink corner. This is where you will find the boss.";
				questtext.text = "";
				quest3 = true;

			}
			else if (questscomplete == 3) {

				questmastertext.text = "To finish the game, you must enter the light blue corner. This is where you will find the treasure.";
				questtext.text = "";
				quest4 = true;

			}
		}
		else if (other.gameObject.CompareTag("Quest 1") && questscomplete == 0 && quest1) {
			questmastertext.text = "";
			questtext.text = "Quest 1 complete. Congratulations! You found the key!";
			questscomplete += 1;
		}
		else if (other.gameObject.CompareTag("Quest 2") && questscomplete == 1 && quest2) {
			questmastertext.text = "";
			questtext.text = "Quest 2 complete. Congratulations! You unlocked the door!";
			questscomplete += 1;
		}
		else if (other.gameObject.CompareTag("Quest 3") && questscomplete == 2 && quest3) {
			questmastertext.text = "";
			questtext.text = "Quest 3 complete. Congratulations! You beat the boss!";
			questscomplete += 1;
		}
		else if (other.gameObject.CompareTag("Finish") && questscomplete == 3 && quest4) {
			questmastertext.text = "";
			questtext.text = "You entered the door. Congratulations! You found the treasure and won the game!";
			questscomplete += 1;
		}
	}
}
