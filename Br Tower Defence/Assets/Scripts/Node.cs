using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

	public Color hoverColor;
	public Color failColor;
	public Vector3 positionOffset;

	private GameObject turret;

	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;


	private void Start()
	{
		//OriginalColor = GetComponent<Renderer>().material.color;

		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

	private void OnMouseDown()
	{
		if(EventSystem.current.IsPointerOverGameObject())
			return;

		if (buildManager.GetTurretToBuild() == null)
			return;

		if(turret != null)
		{
			rend.material.color = failColor ;
			return;
		}

		GameObject turretToBuild = buildManager.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
	}

	private void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (buildManager.GetTurretToBuild() == null)
			return;

		rend.material.color = hoverColor;
	}

	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
