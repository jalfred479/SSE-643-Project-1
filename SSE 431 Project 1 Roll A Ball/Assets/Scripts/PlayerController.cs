using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float rollSpeed;
	public float jumpPower;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	private float distToGround;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		distToGround = GetComponent<Collider>().bounds.extents.y;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal")*rollSpeed;
		float moveVertical = Input.GetAxis ("Vertical")*rollSpeed;
		float jump = Input.GetAxis ("Jump")*jumpPower;
		Vector3 movement;

		if(Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
			movement = new Vector3 (moveHorizontal, jump, moveVertical);
		else
			movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}
}