using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 1f;

    [Header("Toggles")]
    public bool moving = true;
    public int targetNumber = 0;

    [Header("Information")]
    public List<GameObject> targetList;
    public GameObject target;

    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        target = targetList[targetNumber];

        if (moving)
        {
            RotateToPos(target.transform.position);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        }

        if (transform.position == target.transform.position)
        {

            if(targetNumber + 1 == targetList.Count)
            {
                moving = false;
                target = null;
                
            }
            else
            {
                targetNumber++;
                Debug.Log("New target: " + targetNumber + ", name: " + targetList[targetNumber]);
            }




            

        }

    }

    /*private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Colliding...");

        if(collision.gameObject.tag == "target")
        {
            Debug.Log("Colliding with target...");
            
        }
        
    }*/

    /*void MoveToPos(Vector2 pos)
    {
        RotateToPos(pos);
        transform.position = Vector2.MoveTowards(transform.position, pos, 0.005f);

    }*/

    void RotateToPos(Vector2 pos)
    {
        Vector3 targ = new Vector3(pos.x, pos.y, 0);
        targ.z = 0f;
        Vector3 objectPos = transform.position;

        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

    }
}
