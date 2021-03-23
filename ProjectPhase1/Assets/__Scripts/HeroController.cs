﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private static HeroController _instance;//Main character singleton
    private Vector3 _lastHeading;//Last movement position

    public float moveSpeed = 3f;//Movement speed.
    public GameObject idleDown, idleSide, idleUp, runDown, runSide, runUp, swordDown, swordSide, swordUp,
        rifleUp, rifleDown, rifleSide;//Action animations

    public static HeroController Instance { get { return _instance; } }//Main character singleton property.

    private void Awake()
    {
        //Creating singleton instance.
        if (_instance != null & _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Create all possible animation gameobjects.
        idleDown = Instantiate(idleDown) as GameObject;
        idleSide = Instantiate(idleSide) as GameObject;
        idleUp = Instantiate(idleUp) as GameObject;
        runDown = Instantiate(runDown) as GameObject;
        runUp = Instantiate(runUp) as GameObject;
        runSide = Instantiate(runSide) as GameObject;
        swordDown = Instantiate(swordDown) as GameObject;
        swordSide = Instantiate(swordSide) as GameObject;
        swordUp = Instantiate(swordUp) as GameObject;
        rifleDown = Instantiate(rifleDown) as GameObject;
        rifleSide = Instantiate(rifleSide) as GameObject;
        rifleUp = Instantiate(rifleUp) as GameObject;

        ClearGameObjects();
        idleDown.SetActive(true);

        idleDown.transform.SetParent(gameObject.transform, false);
        idleSide.transform.SetParent(gameObject.transform, false);
        idleUp.transform.SetParent(gameObject.transform, false);
        runDown.transform.SetParent(gameObject.transform, false);
        runUp.transform.SetParent(gameObject.transform, false);
        runSide.transform.SetParent(gameObject.transform, false);
        swordDown.transform.SetParent(gameObject.transform, false);
        swordUp.transform.SetParent(gameObject.transform, false);
        swordSide.transform.SetParent(gameObject.transform, false);
        rifleDown.transform.SetParent(gameObject.transform, false);
        rifleUp.transform.SetParent(gameObject.transform, false);
        rifleSide.transform.SetParent(gameObject.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate horizontal and vertical movement
        Vector3 hMovement = Vector3.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 vMovement = Vector3.up * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        //Set movement direction
        Vector3 heading = Vector3.Normalize(hMovement + vMovement);
        //Set position
        transform.position += hMovement;
        transform.position += vMovement;

        if (_lastHeading != heading)
            UpdateMovement(heading);//Update animation.

        //Trying to swing sword
        if (Input.GetKeyDown("e"))
        {
            OnSwingSword();
        }

        //Trying to shoot rifle
        if (Input.GetKeyDown("q"))
        {
            OnShootRifle();
        }

        //Update last frame position.
        _lastHeading = heading;
    }

    void OnSwingSword()
    {
       
        //Reset x flip incase previous animation was flipped.
        swordSide.transform.localScale = new Vector3(1f, swordSide.transform.localScale.y, swordSide.transform.localScale.z);

        if (idleUp.activeSelf || runUp.activeSelf)//If facing up
        {
            GameObject activeGO;//The animation gameobject to return to after attack action
            if (idleUp.activeSelf)
                activeGO = idleUp;
            else
                activeGO = runUp;

            ClearGameObjects();//Clear animations
            swordUp.SetActive(true);//Set action animation
           
            StartCoroutine(WaitSeconds(0.50f, activeGO));//Run attack action for 0.5 seconds.
        }
        else if (idleDown.activeSelf || runDown.activeSelf)//If facing down
        {
            GameObject activeGO;
            if (idleDown.activeSelf)
                activeGO = idleDown;
            else
                activeGO = runDown;

            ClearGameObjects();
            swordDown.SetActive(true);

            StartCoroutine(WaitSeconds(0.50f, activeGO));
        }
        else if ((idleSide.activeSelf && idleSide.transform.localScale.x == -1) || (runSide.activeSelf && runSide.transform.localScale.x == -1))//If facing left
        {
            GameObject activeGO;
            if (idleSide.activeSelf)
                activeGO = idleSide;
            else
                activeGO = runSide;

            ClearGameObjects();
            swordSide.transform.localScale = new Vector3(-1f, swordSide.transform.localScale.y, swordSide.transform.localScale.z);
            swordSide.SetActive(true);

            StartCoroutine(WaitSeconds(0.50f, activeGO));
        }
        else if (idleSide.activeSelf || runSide.activeSelf)//If facing right
        {
            GameObject activeGO;
            if (idleSide.activeSelf)
                activeGO = idleSide;
            else
                activeGO = runSide;

            ClearGameObjects();
            swordSide.SetActive(true);

            StartCoroutine(WaitSeconds(0.50f, activeGO));
        }
    }

    void OnShootRifle()
    {
        //Reset x flip incase previous animation was flipped.
        rifleSide.transform.localScale = new Vector3(1f, rifleSide.transform.localScale.y, rifleSide.transform.localScale.z);

        if (idleUp.activeSelf || runUp.activeSelf)//If facing up
        {
            GameObject activeGO;
            if (idleUp.activeSelf)
                activeGO = idleUp;
            else
                activeGO = runUp;

            ClearGameObjects();
            rifleUp.SetActive(true);

            StartCoroutine(WaitSeconds(0.50f, activeGO));
        }
        else if (idleDown.activeSelf || runDown.activeSelf)
        {
            GameObject activeGO;
            if (idleDown.activeSelf)
                activeGO = idleDown;
            else
                activeGO = runDown;

            ClearGameObjects();
            rifleDown.SetActive(true);

            StartCoroutine(WaitSeconds(0.50f, activeGO));
        }
        else if ((idleSide.activeSelf && idleSide.transform.localScale.x == -1) || (runSide.activeSelf && runSide.transform.localScale.x == -1))//If facing left
        {
            GameObject activeGO;
            if (idleSide.activeSelf)
                activeGO = idleSide;
            else
                activeGO = runSide;

            ClearGameObjects();
            rifleSide.transform.localScale = new Vector3(-1f, rifleSide.transform.localScale.y, rifleSide.transform.localScale.z);
            rifleSide.SetActive(true);

            StartCoroutine(WaitSeconds(0.50f, activeGO));
        }
        else if (idleSide.activeSelf || runSide.activeSelf)
        {
            GameObject activeGO;
            if (idleSide.activeSelf)
                activeGO = idleSide;
            else
                activeGO = runSide;

            ClearGameObjects();
            rifleSide.SetActive(true);

            StartCoroutine(WaitSeconds(0.50f, activeGO));
        }
    }

    //Moves the hero.
    void UpdateMovement(Vector3 dir)
    {

        ClearGameObjects();//Reset all gameobject animation

        //If standing still
        if (dir.x == 0f && dir.y == 0f)
        {
            //Reset x flip incase previous animation was flipped.
            idleSide.transform.localScale = new Vector3(1f, idleSide.transform.localScale.y, idleSide.transform.localScale.z);

            if (_lastHeading.y > 0 && Mathf.Abs(_lastHeading.y) > Mathf.Abs(_lastHeading.x))//If facing up
                idleUp.SetActive(true);
            else if (_lastHeading.y < 0 && Mathf.Abs(_lastHeading.y) > Mathf.Abs(_lastHeading.x)) //If facing down
                idleDown.SetActive(true);
            else if (_lastHeading.x > 0 && Mathf.Abs(_lastHeading.y) < Mathf.Abs(_lastHeading.x))//If facing left
            {
                idleSide.transform.localScale = new Vector3(-1f, idleSide.transform.localScale.y, idleSide.transform.localScale.z);
                idleSide.SetActive(true);
            }
            else
                idleSide.SetActive(true);
        }
        else//If moving
        {
            //Reset x flip incase previous animation was flipped.
            runSide.transform.localScale = new Vector3(1f, runSide.transform.localScale.y, runSide.transform.localScale.z);

            if (dir.y > 0 && Mathf.Abs(dir.y) > Mathf.Abs(dir.x))//If running up
                runUp.SetActive(true);
            else if (dir.y < 0 && Mathf.Abs(dir.y) > Mathf.Abs(dir.x))//If running down
                runDown.SetActive(true);
            else if (dir.x > 0 && Mathf.Abs(dir.y) < Mathf.Abs(dir.x))//If facing left
            {
                runSide.transform.localScale = new Vector3(-1f, runSide.transform.localScale.y, runSide.transform.localScale.z);
                runSide.SetActive(true);
            }
            else//If running right
                runSide.SetActive(true);
        }
    }

    //Sets all animation gameobjects to invisible.
    private void ClearGameObjects()
    {
        idleDown.SetActive(false);
        idleSide.SetActive(false);
        idleUp.SetActive(false);
        runDown.SetActive(false);
        runSide.SetActive(false);
        runUp.SetActive(false);
        swordDown.SetActive(false);
        swordSide.SetActive(false);
        swordUp.SetActive(false);
        rifleDown.SetActive(false);
        rifleSide.SetActive(false);
        rifleUp.SetActive(false);
    }
    //Waits a certain number of seconds, then set a new gameobject animation.
    private IEnumerator WaitSeconds(float seconds, GameObject newActive)
    {
        yield return new WaitForSeconds(seconds);

        ClearGameObjects();

        newActive.SetActive(true);
    }

   

}
