using UnityEngine;
using System.Collections;

public class Pit : MonoBehaviour {



    //[SerializeField]
    // private Transform endTarget;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float activationDelay = 0;
    private bool delayActivation = false;
    [SerializeField]
    private bool resetSecondActivation = false;
    [SerializeField]
    private float loopDelay = 0;
    private bool delayLoop = false;

    [Header("Move Using Horizontal or Vertical Increment")]
    [SerializeField]
    private bool isVertical = false;
    [SerializeField]
    private bool isHorizontalX = false;
    [SerializeField]
    private bool isHorizontalZ = false;
    [SerializeField]
    private float incrementValue = 0;
    [SerializeField]
    private bool isLooping = false;
    [SerializeField]
    private bool loopPastStartPosition = true;
    [SerializeField]
    private bool moveOpposite = false;
    private bool startRegular = false;
    private bool m_wasActivated = false;
    private bool firstActivation = true;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 loopEndPosition;

    private float timer;

    [SerializeField]
    private bool active = false;


    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;

        if (!moveOpposite)
            startRegular = true;
        else
            startRegular = false;

        //Check if Activation or Loop or both are being delayed
        if (activationDelay != 0 && !isLooping)
        {
            timer = activationDelay;
            delayActivation = true;
        }
        else if (loopDelay != 0 && isLooping && activationDelay == 0)
        {
            timer = loopDelay;
            delayLoop = true;
        }
        else if (loopDelay != 0 && isLooping && activationDelay != 0)
        {
            timer = activationDelay;
            delayActivation = true;
            delayLoop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (!isLooping)
            {
                if (delayActivation == true)
                {
                    DelayMovement();
                }
                else
                    OneTimeMovement();
            }
            else
            {
                if (delayActivation == true && firstActivation == true)
                {
                    timer = activationDelay;
                    DelayMovement();
                    firstActivation = false;
                    timer = loopDelay;
                }

                if (delayLoop == true)
                {
                    DelayMovement();
                }
                else
                    LoopMovement();
            }
        }
    }

    private void DelayMovement()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (delayActivation == true)
            {
                timer = activationDelay;
                delayActivation = false;
            }
            else if (delayLoop == true)
            {
                timer = loopDelay;
                delayLoop = false;
            }
        }
    }

    private void OneTimeMovement()
    {
        // Alternative way to move objects without a Transform variable but a distance variable - Omer
        if ((isVertical || isHorizontalX || isHorizontalZ) && !isLooping)
        {
            if (isVertical && startRegular && transform.position.y <= startPosition.y + incrementValue)
            {
                Vector3 vertPos = transform.position;
                vertPos.y += Time.deltaTime * speed;
                transform.position = vertPos;

                //Set to inactive once reached target distance
                if (transform.position.y >= startPosition.y + incrementValue)
                {
                    ResetObject();
                }

            }
            else if (isVertical && !startRegular && transform.position.y >= startPosition.y - incrementValue)
            {
                Vector3 vertPos = transform.position;
                vertPos.y -= Time.deltaTime * speed;
                transform.position = vertPos;

                if (transform.position.y <= startPosition.y - incrementValue)
                {
                    ResetObject();
                }
            }
            else if (isHorizontalX && startRegular && transform.position.x <= startPosition.x + incrementValue)
            {
                Vector3 vertPos = transform.position;
                vertPos.x += Time.deltaTime * speed;
                transform.position = vertPos;

                if (transform.position.x >= startPosition.x + incrementValue)
                {
                    ResetObject();
                }
            }
            else if (isHorizontalX && !startRegular && transform.position.x >= startPosition.x - incrementValue)
            {
                Vector3 vertPos = transform.position;
                vertPos.x -= Time.deltaTime * speed;
                transform.position = vertPos;

                if (transform.position.x <= startPosition.x - incrementValue)
                {
                    ResetObject();
                }
            }
            else if (isHorizontalZ && startRegular && transform.position.z <= startPosition.z + incrementValue)
            {
                Vector3 vertPos = transform.position;
                vertPos.z += Time.deltaTime * speed;
                transform.position = vertPos;

                if (transform.position.z >= startPosition.z + incrementValue)
                {
                    ResetObject();
                }
            }
            else if (isHorizontalZ && !startRegular && transform.position.z >= startPosition.z - incrementValue)
            {
                Vector3 vertPos = transform.position;
                vertPos.z -= Time.deltaTime * speed;
                transform.position = vertPos;

                if (transform.position.z <= startPosition.z - incrementValue)
                {
                    ResetObject();
                }
            }
        }
    }

    public void ResetObject()
    {
        active = false;
        startPosition = transform.position;
    }

    private void LoopMovement()
    {
        if (isVertical)
        {
            if (loopPastStartPosition)
                MoveVerticalLoop(startPosition.y, incrementValue);
            else
            {
                if (startRegular)
                {
                    if (!moveOpposite)
                        MoveVerticalLoop(startPosition.y, incrementValue);
                    else
                        MoveVerticalLoop(loopEndPosition.y, incrementValue);
                }
                else
                {
                    if (!moveOpposite)
                        MoveVerticalLoop(loopEndPosition.y, incrementValue);
                    else
                        MoveVerticalLoop(startPosition.y, incrementValue);
                }
            }

        }
        else if (isHorizontalZ)
        {
            if (loopPastStartPosition)
                MoveHorizontalZLoop(startPosition.z, incrementValue);
            else
            {
                if (startRegular)
                {
                    if (!moveOpposite)
                        MoveHorizontalZLoop(startPosition.z, incrementValue);
                    else
                        MoveHorizontalZLoop(loopEndPosition.z, incrementValue);
                }
                else
                {
                    if (!moveOpposite)
                        MoveHorizontalZLoop(loopEndPosition.z, incrementValue);
                    else
                        MoveHorizontalZLoop(startPosition.z, incrementValue);
                }
            }
        }
        else if (isHorizontalX)
        {
            if (loopPastStartPosition)
                MoveHorizontalXLoop(startPosition.x, incrementValue);
            else
            {
                if (startRegular)
                {
                    if (!moveOpposite)
                        MoveHorizontalXLoop(startPosition.x, incrementValue);
                    else
                        MoveHorizontalXLoop(loopEndPosition.x, incrementValue);
                }
                else
                {
                    if (!moveOpposite)
                        MoveHorizontalXLoop(loopEndPosition.x, incrementValue);
                    else
                        MoveHorizontalXLoop(startPosition.x, incrementValue);
                }
            }
        }
    }

    private void MoveVerticalLoop(float value, float value2)
    {
        if (!moveOpposite)
        {
            if (transform.position.y < value + value2)
            {
                Vector3 vertPos = transform.position;
                vertPos.y += Time.deltaTime * speed;
                transform.position = vertPos;
            }
            else
            {
                delayLoop = true;
                moveOpposite = true;

                if (!loopPastStartPosition)
                    loopEndPosition = transform.position;
            }
        }
        else
        {
            if (transform.position.y > value - value2)
            {
                Vector3 vertPos = transform.position;
                vertPos.y -= Time.deltaTime * speed;
                transform.position = vertPos;
            }
            else
            {
                delayLoop = true;
                moveOpposite = false;

                if (!loopPastStartPosition)
                    loopEndPosition = transform.position;
            }
        }
    }

    private void MoveHorizontalZLoop(float value, float value2)
    {
        if (!moveOpposite)
        {
            if (transform.position.z < value + value2)
            {
                Vector3 vertPos = transform.position;
                vertPos.z += Time.deltaTime * speed;
                transform.position = vertPos;
            }
            else
            {
                delayLoop = true;
                moveOpposite = true;

                if (!loopPastStartPosition)
                    loopEndPosition = transform.position;
            }
        }
        else
        {
            if (transform.position.z > value - value2)
            {
                Vector3 vertPos = transform.position;
                vertPos.z -= Time.deltaTime * speed;
                transform.position = vertPos;
            }
            else
            {
                delayLoop = true;
                moveOpposite = false;

                if (!loopPastStartPosition)
                    loopEndPosition = transform.position;
            }
        }
    }

    private void MoveHorizontalXLoop(float value, float value2)
    {
        if (!moveOpposite)
        {
            if (transform.position.x < value + value2)
            {
                Vector3 vertPos = transform.position;
                vertPos.x += Time.deltaTime * speed;
                transform.position = vertPos;
            }
            else
            {
                delayLoop = true;
                moveOpposite = true;

                if (!loopPastStartPosition)
                    loopEndPosition = transform.position;
            }
        }
        else
        {
            if (transform.position.x > value - value2)
            {
                Vector3 vertPos = transform.position;
                vertPos.x -= Time.deltaTime * speed;
                transform.position = vertPos;
            }
            else
            {
                delayLoop = true;
                moveOpposite = false;

                if (!loopPastStartPosition)
                    loopEndPosition = transform.position;
            }
        }
    }

    public void OnPortTriggerable()
    {

        if (m_wasActivated && resetSecondActivation == true)
        {
            MoveToStart();
            active = false;
            m_wasActivated = false;
        }
        else
        {
            active = true;
            m_wasActivated = true;
        }
    }

    public void OnPortTriggerableDeactivate()
    {
        active = false;
    }

    public void ToggleMoveOpposite()
    {
        if (moveOpposite)
        {
            moveOpposite = false;
            startRegular = true;
        }
        else
        {
            moveOpposite = true;
            startRegular = false;
        }
    }

    public void MoveToStart()
    {
        transform.position = startPosition;
    }
}

