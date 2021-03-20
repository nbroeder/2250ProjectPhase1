using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private static MainCharacter _instance;//Main character singleton.
    private Animator _thisAnim;//The animator component
    private float _lastH, _lastV;//The previous movement directions

    public float moveSpeed = 3f;//Movement speed.
    public RuntimeAnimatorController idleNorth, idleWest, idleSouth, runNorth, runSouth, runWest;//Animations

    public static MainCharacter Instance { get { return _instance; } }//Main character singleton property.

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
        _thisAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAnimatorMove()
    {
        //Calculate horizontal and vertical movement
        Vector3 hMovement = Vector3.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 vMovement = Vector3.up * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        //Set movement direction
        Vector3 heading = Vector3.Normalize(hMovement + vMovement);
        //Set position
        transform.position += hMovement;
        transform.position += vMovement;
        //If just stopped moving in the last frame.
        if ((heading.x == 0 || heading.y == 0) && (_lastH != 0 || _lastV != 0))
            UpdateAnimation(heading);//Update animation.

        //Set current movement values for reference in next frame.
        _lastH = heading.x;
        _lastV = heading.y;
    }

    void UpdateAnimation(Vector3 dir)
    {
        //Reset x flip incase previous animation was flipped.
        transform.localScale = new Vector3(0.6655f, transform.localScale.y, transform.localScale.z);
        //If standing still
        if (dir.x == 0f && dir.y == 0f)
        {
            if (_lastV > 0 && Mathf.Abs(_lastV) > Mathf.Abs(_lastH))//If facing up
                _thisAnim.runtimeAnimatorController = idleNorth;
            else if (_lastV < 0 && Mathf.Abs(_lastV) > Mathf.Abs(_lastH))//If facing down
                _thisAnim.runtimeAnimatorController = idleSouth;
            else if (_lastH > 0 && Mathf.Abs(_lastV) < Mathf.Abs(_lastH))//If facing left
            {
               //If facing right animation
                transform.localScale = new Vector3(-0.6655f, transform.localScale.y, transform.localScale.z);

                _thisAnim.runtimeAnimatorController = idleWest;
            } 
            else// If facing right
                 _thisAnim.runtimeAnimatorController = idleWest;

           
        } else//If moving
        {
            if (_lastV > 0 && Mathf.Abs(_lastV) > Mathf.Abs(_lastH))//If facing up
                _thisAnim.runtimeAnimatorController = runNorth;
            else if (_lastV < 0 && Mathf.Abs(_lastV) > Mathf.Abs(_lastH))//If facing down
                _thisAnim.runtimeAnimatorController = runSouth;
            else if (_lastH > 0 && Mathf.Abs(_lastV) < Mathf.Abs(_lastH))//If facing left
            {
                //Flip facing right animation
                transform.localScale = new Vector3(-0.6655f, transform.localScale.y, transform.localScale.z);

                _thisAnim.runtimeAnimatorController = runWest;
            }
            else//If facing right
                _thisAnim.runtimeAnimatorController = runWest;
        }
    }
}
