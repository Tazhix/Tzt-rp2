using UnityEngine;

public class Node : MonoBehaviour
{

	public Color hoverColor;
	public Color failColor;
	public Vector3 positionOffset;

	private GameObject turret;

	private Renderer rend;
	private Color startColor;
	

	private void Start()
	{
		//OriginalColor = GetComponent<Renderer>().material.color;

		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	private void OnMouseDown()
	{
		if(turret != null)
		{
			rend.material.color = failColor ;
			return;
		}

		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
	}

	private void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
