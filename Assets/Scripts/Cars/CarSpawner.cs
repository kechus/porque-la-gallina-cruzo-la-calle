using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    public Sprite[] PossibleSprites;

    [SerializeField]
    public Sprite[] PossibleSpritesUp;

    [SerializeField]
    public GameObject CarPrefab;

    float Timer = 0f;
    float SpawnRate = 2.5f;

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
        var speed = Random.Range(0, 2) == 0 ? 6 : 5;

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
        car.GetComponent<CarMovement>().Direction = direction;
        car.GetComponent<CarMovement>().Speed = speed;
        car.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
