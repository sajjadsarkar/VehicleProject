using UnityEngine;

public class MenuConnector : MonoBehaviour
{
    public void SelectCar()
    {
        MenuManager.Instance.SelectCar();
    }
    public void SelectBike()
    {
        MenuManager.Instance.SelectBike();
    }
    public void SelectTruck()
    {
        MenuManager.Instance.SelectTruck();
    }
}
