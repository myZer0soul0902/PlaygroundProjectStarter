using UnityEngine;

[AddComponentMenu("Playground/Attributes/Collectable")]
[RequireComponent(typeof(Collider2D))]
public class CollectableAttribute : MonoBehaviour
{
	private UIScript _userInterface;


	// Start is called at the beginning
	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		_userInterface = GameObject.FindObjectOfType<UIScript>();
	}



	// This function gets called everytime this object collides with another
	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		string playerTag = otherCollider.gameObject.tag;

		// is the other object a player?
		if(playerTag == "Player" || playerTag == "Player2")
		{
			if(_userInterface != null)
			{
				// add one point
				int playerId = (playerTag == "Player") ? 0 : 1;
				_userInterface.AddOnePoint(playerId);
			}

			// then destroy this object
			Destroy(gameObject);
		}
	}
}
