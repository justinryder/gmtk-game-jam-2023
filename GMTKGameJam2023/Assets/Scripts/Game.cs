using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject AsteroidPrefab;

    public int AsteroidSpawnCount = 20;
    public float AsteroidSpawnMinSize = 0.5f;
    public float AsteroidSpawnMaxSize = 2.0f;
    public float AsteroidSpawnMinSpeed = 0.5f;
    public float AsteroidSpawnMaxSpeed = 5.0f;

    private Camera _camera;

    void Awake()
    {
        if (!AsteroidPrefab)
        {
            Debug.LogError("Game requires AsteroidPrefab to be set");
        }

        _camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < AsteroidSpawnCount; i++)
        {
            SpawnAsteroid(RandomWorldPositionOnScreen(), RandomSpeed());
        }
    }

    Vector2 RandomWorldPositionOnScreen()
    {
        var safeArea = Screen.safeArea;
        var screenPosition = new Vector3(
            Random.Range(safeArea.x, safeArea.width),
            Random.Range(safeArea.y, safeArea.height),
            0
        );
        var worldPosition = _camera.ScreenToWorldPoint(screenPosition);
        return new Vector2(
            worldPosition.x,
            worldPosition.y
        );
    }

    Vector2 RandomSpeed()
    {
        var diff = AsteroidSpawnMaxSpeed - AsteroidSpawnMinSpeed;
        var rand = Random.insideUnitCircle * diff;
        return rand + (Vector2.one * AsteroidSpawnMinSpeed);
    }

    GameObject SpawnAsteroid(Vector2 position, Vector2 speed)
    {
        var asteroid = GameObject.Instantiate(AsteroidPrefab);
        asteroid.transform.position = position;
        var rigidbody = asteroid.GetComponent<Rigidbody2D>();
        rigidbody.velocity = speed;
        return asteroid;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
