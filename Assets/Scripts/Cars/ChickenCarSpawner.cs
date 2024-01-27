using UnityEngine;

public class ChickenCarSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject CarPrefab;


    int lastDirection;
    float Timer = 0f;
    readonly float SpawnRate = 1.7f;

    void Start()
    {
        CreateCar();
    }

    void Update()
    {
        if (Timer <= SpawnRate)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            Timer = 0;
            CreateCar();
        }
    }

    void CreateCar()
    {
        var direction = Random.Range(0, 2) == 0 ? -1 : 1;
        if(direction != lastDirection)
        {
            direction *= -1;
        }
        lastDirection = direction;

        var speed = Random.Range(0, 2) == 0 ? 6 : 4;

        float y;
        if (direction == -1)
        {
            y = 6f;
        }
        else
        {
            y = -6.5f;
        }

        GameObject car = Instantiate(CarPrefab, new Vector3(transform.position.x, y, 0), Quaternion.identity);
        car.GetComponent<CarMovement>().Direction = direction;
        car.GetComponent<CarMovement>().Speed = speed;
        car.GetComponent<Animator>().enabled = true;
    }
}
