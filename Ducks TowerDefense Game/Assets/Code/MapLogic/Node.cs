using UnityEngine;

public class Node : MonoBehaviour{

    public Color hoverColor;
    public Vector3 positionOffSet;//Set the position of turret in the GameObject(square)
    public Vector3 roatationOffSet;//set the rotation og turret in the GameObject(square)
    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

    }

    void OnMouseDown(){
        if(turret != null){
            Debug.Log("Can't build there - TODO: Display On Screen");
            return;
        }


        //build a turre
        //reference PlaceTurret
        //stores PlaceTurret.instance.BuildTurret() into turretBuilding and instantiate it
        GameObject turretBuilding = PlaceTurret.instance.BuildTurret();
        
        //Singleton Pattern you will have to cast GameObject
        turret = (GameObject)Instantiate(turretBuilding, transform.position + positionOffSet, transform.rotation * Quaternion.Euler(roatationOffSet));
    }


    // In order for this effect to work, I would need to add a Box Collider Component in the inspector of the game Object (Square)
    void OnMouseEnter(){ //OnMouseEnter - Enter the node
        rend.sharedMaterial.color = hoverColor;
    }

    void OnMouseExit(){ //OnMouseExit - Exit the node
        rend.material.color = startColor;  
    }


}
