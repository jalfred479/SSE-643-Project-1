using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float rollSpeed;
	public float jumpPower;
	public Text countText;
	public Text winText;
	public GameObject boundPanel;
	public Text boundText;
	public GameObject winPanel;
	public int totalCollectibles;

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
		Vector3 targetDirection = new Vector3(moveHorizontal, 0f, moveVertical);
		targetDirection = Camera.main.transform.TransformDirection(targetDirection);
		targetDirection.y = jump;
		if(Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
			movement = targetDirection;
		else
			movement = new Vector3 (targetDirection.x, 0.0f, targetDirection.z);

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

		if (other.gameObject.CompareTag ("Boundary")) 
		{
			boundPanel.SetActive(true);
			boundText.text = "You fell off...";
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString() + " of " + totalCollectibles.ToString();
		if (count >= totalCollectibles) 
		{
			winPanel.SetActive(true);
			winText.text = "You Win!";
		}
	}

}