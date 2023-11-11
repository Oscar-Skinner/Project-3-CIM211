using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VisionSystem : MonoBehaviour
{
    #region Variables

	public float sightRefreshTime = 2f;
	
	private List<ChangingObjects> allInSight = new List<ChangingObjects>();

	private List<ChangingObjects> objectsInSight = new List<ChangingObjects>();
	
	#endregion

	void Start()
	{
		allInSight  = new List<ChangingObjects>();
		objectsInSight = new List<ChangingObjects>();

		StartCoroutine(CheckStillVisible());
	}

	#region OnTriggerEnter

	private void OnTriggerEnter(Collider other)
	{
		//everything vision for anyone's use :D
		if (other != null)
		{
			if (other.GetComponentInParent<ChangingObjects>() != null)
			{
				ChangingObjects dynamicObj = other.GetComponentInParent<ChangingObjects>();
				
				if (!allInSight.Contains(dynamicObj))
				{
					allInSight.Add(dynamicObj);
				}
			}
		}
	}

	#endregion

	#region OnTriggerStay

	private IEnumerator CheckStillVisible()
	{
		while (true)
		{			
			// CLEAR ALL OTHERS
			objectsInSight.Clear();

			foreach (ChangingObjects changeObj in allInSight)
			{
				//everything vision for anyone's use :D
				if (changeObj != null)
				{
					//LINECAST HERE. If false, continue (next in list)
					// Perform linecast
					bool hit = Physics.Linecast(transform.position, changeObj.transform.position);

					if (hit)
					{
						//are they a Bee, use this:
						if (!objectsInSight.Contains(changeObj))
						{
							//Add to list here
							objectsInSight.Add(changeObj);
						}
					}
				}
			}

			yield return new WaitForSeconds(sightRefreshTime);
		}
	}
	
	#endregion
	

	#region OnTriggerExit

	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponentInParent<ChangingObjects>() != null)
		{
			ChangingObjects changeObj = other.GetComponentInParent<ChangingObjects>();

			changeObj.Disappear();
			
			allInSight.Remove(changeObj);
			
			// print(dynamicObj.description);
			
		}
	}

	#endregion
}