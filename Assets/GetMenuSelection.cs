using UnityEngine;

public class GetMenuSelection : MonoBehaviour
{
    private bool isCarSelected;
    private bool isBikeSelected;
    private bool isTruckSelected;

    public GameObject carPrefab;
    public GameObject bikePrefab;
    public GameObject truckPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateVehicleSelection();
    }


    private void UpdateVehicleSelection()
    {
        // Get latest values
        isCarSelected = MenuManager.Instance.isCar;
        isBikeSelected = MenuManager.Instance.isBike;
        isTruckSelected = MenuManager.Instance.isTruck;

        // Enable/disable prefabs
        if (carPrefab != null) carPrefab.SetActive(isCarSelected);
        if (bikePrefab != null) bikePrefab.SetActive(isBikeSelected);
        if (truckPrefab != null) truckPrefab.SetActive(isTruckSelected);

        Debug.Log($"Updated vehicles - Car: {isCarSelected}, Bike: {isBikeSelected}, Truck: {isTruckSelected}");
    }
}
