using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CircularMovementControll : MonoBehaviour {

    // Use this for initialization
    public GameObject Center;
    public float radio;
    public float sideSpeed;
    public float forwardSpeed;
    float angle;
    float position=6;
    float energy;
    int energyInt;
    //Ui
    public Text EnergyText;
    public Text ScoreText;
    public GameObject winText;
    int score;
    bool win;
    private void Start()
    {
        energy = 100;
        angle = ((3 * Mathf.PI) / 2);
        SetUiText();
        score = 0;
        win = false;
        winText.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate () {

        if (!win)
        {
            angle += Input.GetAxis("Horizontal") * Time.deltaTime * sideSpeed;
            if (energy > -100 && forwardSpeed >= 0)
            {
                position += forwardSpeed;
            }

            if (energy <= 0.0f)
            {
                forwardSpeed -= 0.1f;
            }
            if (energy > 0.0f)
            {
                energy -= 0.2f;
            }
            transform.position = new Vector3(Mathf.Cos(angle) * radio, Mathf.Sin(angle) * radio, position);
            transform.eulerAngles = new Vector3(0, 0, (angle * 180) / Mathf.PI);
            if (forwardSpeed <= 0)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            //UI
            score += 1;
            SetUiText();
            if(transform.position.z>=600)
            {
                win = true;
            }
        }
       else
        {
            winText.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("We hit an obstacle");
            energy = 0;
        }
        if (collision.gameObject.CompareTag("Energy"))
        {
            
            energy += 50;
            if(energy>100)
            {
                energy = 100;
            }
            collision.gameObject.SetActive(false);
           
        }
      
    }
    private void SetUiText()
    {
        energyInt = (int)energy;
        EnergyText.text = "Energy:" +  energyInt.ToString();
       ScoreText.text = "Score:" + score.ToString();
    }
}
