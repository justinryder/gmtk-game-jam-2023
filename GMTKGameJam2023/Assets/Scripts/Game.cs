using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static readonly string AsteroidTag = "Asteroid";
    public static readonly string BulletTag = "Bullet";
    public static readonly string CrosshairTag = "Crosshair";
    public static readonly string HealthBarTag = "HealthBar";
    public static readonly string LoseTag = "Lose";
    public static readonly string ShipTag = "Ship";
    public static readonly string WinTag = "Win";

    public GameObject AsteroidPrefab;

    public int AsteroidSpawnCount = 20;
    public float AsteroidSpawnMinSize = 0.5f;
    public float AsteroidSpawnMaxSize = 2.0f;
    public float AsteroidSpawnMinSpeed = 0.5f;
    public float AsteroidSpawnMaxSpeed = 5.0f;

    private Camera _camera;

    private bool _win;
    private bool _lose;

    public GameObject WinUI;
    public GameObject LoseUI;

    void Awake()
    {
        if (!AsteroidPrefab)
        {
            Debug.LogError("Game requires AsteroidPrefab to be set");
        }
        if (!AsteroidPrefab.GetComponent<Asteroid>())
        {
            Debug.LogError("Game requires AsteroidPrefab to have an Asteroid script");
        }

        if (!WinUI)
        {
            Debug.LogError("Game requires WinUI to be set");
        }

        if (!LoseUI)
        {
            Debug.LogError("Game requires LoseUI to be set");
        }

        _camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        var rand = new System.Random();
        for (var i = 0; i < AsteroidSpawnCount; i++)
        {
            // TODO: don't spawn on top of or near player
            SpawnAsteroid(RandomWorldPositionOnScreen(), rand.Next(Asteroid.MinSize, Asteroid.MaxSize + 1), RandomSpeed());
        }
    }

    Vector2 RandomWorldPositionOnScreen()
    {
        var safeArea = Screen.safeArea;
        var w = safeArea.width;
        var h = safeArea.height;
        var x = Random.Range(safeArea.x, w);
        var y = Random.Range(safeArea.y, h);
        var screenPosition = new Vector3(
            (((x - w/2) * 2/3) % w + w) % w,
            (((y - h/2) * 2/3) % h + h) % h,
            0
        );
        var worldPosition = _camera.ScreenToWorldPoint(screenPosition);
        return new Vector2(
            worldPosition.x,
            worldPosition.y
        );
    }

    Vector2 RandomVectorRangeMagnitude(float minMagnitutde, float maxMagnitude)
    {
        var diff = maxMagnitude - minMagnitutde;
        var rand = Random.insideUnitCircle * diff;
        return rand + (Vector2.one * minMagnitutde);
    }

    Vector2 RandomSpeed()
    {
        return RandomVectorRangeMagnitude(AsteroidSpawnMinSpeed, AsteroidSpawnMaxSpeed);
    }

    Vector2 RandomSize()
    {
        return Vector2.one * Random.Range(AsteroidSpawnMinSize, AsteroidSpawnMaxSize);
    }

    public GameObject SpawnAsteroid(Vector2 position, int size, Vector2 speed)
    {
        var asteroidGameObject = GameObject.Instantiate(AsteroidPrefab);
        asteroidGameObject.transform.position = position;
        var asteroid = asteroidGameObject.GetComponent<Asteroid>();
        asteroid.SetSize(size);
        var rigidbody = asteroidGameObject.GetComponent<Rigidbody2D>();
        rigidbody.velocity = speed;
        asteroid.transform.parent = gameObject.transform;
        return asteroidGameObject;
    }

    public void Win()
    {
        if (_win || _lose)
        {
            return;
        }

        // TODO: implement win screen
        Debug.Log("Win");
        _win = true;
        Time.timeScale = 0;

        // var win = GameObject.FindWithTag(WinTag);
        WinUI.SetActive(true);
    }

    public void Lose()
    {
        if (_win || _lose)
        {
            return;
        }

        // TODO: implement lose screen
        Debug.Log("Lose");
        _lose = true;
        Time.timeScale = 0;

        // var lose = GameObject.FindWithTag(LoseTag);
        LoseUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
