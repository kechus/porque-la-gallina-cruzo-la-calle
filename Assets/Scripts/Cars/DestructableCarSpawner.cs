using UnityEngine;

public class DestructableCarSpawner : MonoBehaviour
{
    [SerializeField]
    public Sprite[] PossibleSprites;

    [SerializeField]
    public Sprite[] PossibleSpritesUp;

    [SerializeField]
    public GameObject CarPrefab;


    int lastDirection;
    float Timer = 0f;
    readonly float SpawnRate = 3f;

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

        int index;
        float y;
        Sprite sprite;
        if (direction == -1)
        {
            index = Random.Range(0, PossibleSprites.Length);
            sprite = PossibleSprites[index];
            y = 6f;
        }
        else
        {
            index = Random.Range(0, PossibleSpritesUp.Length);
            sprite = PossibleSpritesUp[index];
            y = -6.5f;
        }

        GameObject car = Instantiate(CarPrefab, new Vector3(transform.position.x, y, 0), Quaternion.identity);
        car.GetComponent<DestructableCar>().Direction = direction;
        car.GetComponent<DestructableCar>().Speed = speed;
        car.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
