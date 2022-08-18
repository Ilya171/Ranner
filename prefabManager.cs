using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabManager : MonoBehaviour
{
    
    [SerializeField] GameObject ObstraclePref;
    [SerializeField] GameObject GatePref;
    [SerializeField] GameObject GateBADPref;
    [SerializeField] GameObject EmenyPref;
    [SerializeField] GameObject EmenyLeftPref;
   

    [SerializeField]lvlController lvlController;
    [SerializeField] boSScript boSScript;
    //[SerializeField] Gate gate;

    Vector3 startPosition;
    Vector3 creatPositionObsracl;
    Vector3 creatPositionGate;
    Vector3 creatPositionEnemy;

    Vector3 secondPosition = new Vector3(12f,0f,293f);


    public float chanceObsracle = 10f;
    public float chanceEnemy = 30f;
    public float chanceGoodGate = 80f;
    
    public float upDistance = 10f;
    public float upDistanceGate = 25f;

    [SerializeField]Gate g;
    private void Start()
    {
        creatPositionObsracl = startPosition;
        creatPositionGate = startPosition;
        creatPositionEnemy = startPosition;

        creatPositionObsracl.z += 40f;
        creatPositionEnemy.z += 30f;
        creatPositionGate.z += 30f;
        EnemyCreator();
        GateCreator();
        endBossCreator();
        
        if (lvlController.Level >= 5)
        {
            ObstracleCreator();
            
        }

    }

    void ObstracleCreator()
    {     
        
        for(int i=0; creatPositionObsracl.z<280; i++)
        {
            if(chanceObsracle>=Rand())
            {
                float R = Random.Range(-5f, 5f);
                creatPositionObsracl.x = R;                    
                Instantiate(ObstraclePref,creatPositionObsracl,Quaternion.identity);
                    
            }                           
            creatPositionObsracl.z += upDistance;                
                
        }
        creatPositionObsracl = secondPosition;
        for (int i = 0; creatPositionObsracl.x < 60f; i++)
        {
           
            if (chanceObsracle >= Rand())
            {
                float R = Random.Range(288f, 298f);

                creatPositionObsracl.z = R;
                Instantiate(ObstraclePref, creatPositionObsracl, new Quaternion(0, 0, 0, 0));             
             
            }
            creatPositionObsracl.x += upDistance / 2;
        }


    }
    void EnemyCreator()
    {
        for (int i = 0; creatPositionEnemy.z < 280; i++)
        {
            if (chanceEnemy >= Rand())
            {
                float R = Random.Range(-5f, 5f);
                creatPositionEnemy.x = R;
                Instantiate(EmenyPref, creatPositionEnemy, new Quaternion(0,180,0,0));

            }

            creatPositionEnemy.z += upDistance/2;

        }
        creatPositionEnemy = secondPosition;
        for(int i=0;creatPositionEnemy.x<60f;i++)
        {
            
            if (chanceEnemy >= Rand())
            {
                float R = Random.Range(1, 3);
                if(R==1)
                {
                    creatPositionEnemy.z = 288f;
                    Instantiate(EmenyLeftPref, creatPositionEnemy, new Quaternion(0, 0, 0, 0));
                }
                else
                {
                    creatPositionEnemy.z = 298f;
                    Instantiate(EmenyLeftPref, creatPositionEnemy, new Quaternion(0, -90, 0, 0));
                }
                
               

            }
            creatPositionEnemy.x += upDistance / 2;
        }
    }
    
    void GateCreator()
    {

              
        for (int i = 0; creatPositionGate.z < 280; i++)
        {
            if (chanceGoodGate > Rand())
            {


                if (Random.Range(1, 3) == 1)
                {
                    float R = Random.Range(-3.5f, 3.5f);
                    creatPositionGate.x = R;
                    if((R>=-3.5f&&R<=-3f)||(R<=3.5f&&R>=3f))
                    {
                        Vector3 oneMore= creatPositionGate;
                        oneMore.x *= -1f;
                        GameObject bad = Instantiate(GateBADPref, oneMore, new Quaternion(0, 0, 0, 0));
                        bad.GetComponent<Gate>().value = Random.Range(-500, 1);
                        bad.GetComponent<Gate>()._type = Gate.gateType.Year;
                    }
                    GameObject g = Instantiate(GatePref, creatPositionGate, new Quaternion(0, 0, 0, 0));
                    g.GetComponent<Gate>().value = Random.Range(1, 10);
                    g.GetComponent<Gate>()._type = Gate.gateType.People;

                }
                else
                {
                    float R = Random.Range(-3.5f, 3.5f);
                    creatPositionGate.x = R;
                    if ((R >= -3.5f && R <= -3f) || (R <= 3.5f && R >= 3f))
                    {
                        Vector3 oneMore = creatPositionGate;
                        oneMore.x *= -1f;
                        GameObject bad = Instantiate(GateBADPref, oneMore, new Quaternion(0, 0, 0, 0));
                        bad.GetComponent<Gate>().value = Random.Range(-500, 1);
                        bad.GetComponent<Gate>()._type = Gate.gateType.Year;
                    }
                    GameObject g = Instantiate(GatePref, creatPositionGate, new Quaternion(0, 0, 0, 0));
                    g.GetComponent<Gate>().value = Random.Range(100, 500);
                    g.GetComponent<Gate>()._type = Gate.gateType.Year;
                }
            }
            else
            {
                float R = Random.Range(-3f, 3f);
                creatPositionGate.x = R;
                GameObject g = Instantiate(GateBADPref, creatPositionGate, new Quaternion(0, 0, 0, 0));
                g.GetComponent<Gate>().value = Random.Range(-500, 1);
                g.GetComponent<Gate>()._type = Gate.gateType.Year;
                
                
            }


            creatPositionGate.z += upDistanceGate;

        }
        creatPositionGate = secondPosition;
        for (int i = 0; creatPositionGate.x < 60; i++)
        {
            if (true)
            {
                float R = Random.Range(288f, 298f);
                creatPositionGate.z = R;
                GameObject g= Instantiate(GatePref, creatPositionGate, Quaternion.Euler(0,90,0));                
                g.GetComponent<Gate>().value = Random.Range(1, 10);
                g.GetComponent<Gate>()._type = Gate.gateType.People;


            }

            creatPositionGate.x += upDistanceGate;

        }
    }

    int Rand()
    {                
        return Random.Range(1, 100);
        
    }
       
    public void endBossCreator()
    {
        //int bossHP = 5;

        //Instantiate(BossPrefab);


    }


    public void UpHard()
    {
        
        if(upDistance>=0) upDistance -= 0.5f;
        if(chanceObsracle<=100) chanceObsracle += 1f;
        if(chanceEnemy <= 100) chanceObsracle += 1f;
        if (chanceGoodGate>=40) chanceGoodGate -= 1f;
        boSScript.Xp += 5;


       
    }
}
