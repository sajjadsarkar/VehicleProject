using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    public bool isCar = false;
    public bool isBike = false;
    public bool isTruck = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCar = false;
        isBike = false;
        isTruck = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectCar()
    {
        isCar = true;
        isBike = false;
        isTruck = false;
    }

    public void SelectBike()
    {
        isCar = false;
        isBike = true;
        isTruck = false;
    }

    public void SelectTruck()
    {
        isCar = false;
        isBike = false;
        isTruck = true;
    }
}
