using UnityEngine;

public class Shop : MonoBehaviour{

    PlaceTurret placeTurret;
    void Start(){
        placeTurret = PlaceTurret.instance;
    }
    public void Purchase(){
        Debug.Log("Turret Selected");
        placeTurret.setTurretToBuild(placeTurret.turretPrefab);
    }
    public void Purchase2(){
        Debug.Log("Turret Selected 2");
        placeTurret.setTurretToBuild(placeTurret.other_Turret_Prefab);

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}