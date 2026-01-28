using System;
using UnityEngine;
public class Shoot : MonoBehaviour
{

    //snelheid waarmee de lijn groeit
    [SerializeField] private float lineSpeed = 10f;
    //verwijzing naar de linerenderer
    private LineRenderer _line;
    //we houden hiermee bij of de lijn actief is of niet
    private bool _lineActive = false;
    //Maak een nieuw Action Event
    public static event Action onShootBall;

    [SerializeField] private GameObject prefab;
    [SerializeField] private float forceBuild = 20f;
    [SerializeField] private float maximumHoldTime = 5f;
    private float _pressTimer = 0f;
    private float _launchForce = 0f;
    private bool _shotEnabled = true;


    private void Start()
    {
        CountBalls.onBallsDepleted += DisableShot;
        //we vragen het Line Renderer component op en slaan deze op in een variabele zodat we er later dingen mee kunnen doen
        _line = GetComponent<LineRenderer>();
        //We pakken het eindpunt van de lijn en zetten deze op positie 0,0,0 (zelfde plek als het beginpunt). Hierdoor word de lijn onzichtbaar. Punt 0 is het beginpunt en punt 1 het eindpunt.
        _line.SetPosition(1, Vector3.zero);
        //_line.SetPosition(0,Vector3.one); zou het beginpunt aanpassen. Maar dat is niet nodig nu.

    }
        //Verwijder altijd netjes alle events weer
    private void OnDisable(){
        CountBalls.onBallsDepleted -= DisableShot;
    }

    //Elk frame voeren we een functie HandleShot uit
    private void Update()
    {
         //Zorg dat je alleen kunt schieten als _shotEnabled true is
        if(_shotEnabled)HandleShot();
    }
    //Die functie scrijven we zelf
    private void HandleShot()
    {


        //Check of de linkermuisknop word ingedrukt (alleen het eerste moment van indrukken)
        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0; //reset de timer weer op 0. Verderop gaan we de tijd hierin bijhouden hoe lang we de knop hebben ingehouden
            _pressTimer = 0f;
            _lineActive = true;
        }
        //Check of je de linkermuisknop loslaat.
        if (Input.GetMouseButtonUp(0))
        {
            _launchForce = _pressTimer * forceBuild;
            GameObject ball = Instantiate(prefab, transform.parent);
            ball.transform.rotation = transform.rotation;
            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse);
            ball.transform.position = transform.position;

            onShootBall?.Invoke();

           
            _lineActive = false;
            _line.SetPosition(1, Vector3.zero);
        }
        if(_pressTimer < maximumHoldTime){
            _pressTimer += Time.deltaTime;
        }

        if (_lineActive)
        {
            _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
        }
    }
    private void DisableShot(){
        _shotEnabled = false;
    }
}