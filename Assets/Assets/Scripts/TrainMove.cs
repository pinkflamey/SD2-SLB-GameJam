using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    public List<GameObject> gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in gameObjects)
        {
            MoveToPos(go.transform.position);
            while(go.transform.position != transform.position)
            {
                Debug.Log("Going towards " + go.name + "...");
            }
        }


        /*Vector2 pos = new Vector2(transform.position.x, transform.position.y) + new Vector2(0, 5);
        MoveToPos(pos);*/
    }

    void MoveToPos(Vector2 pos)
    {
        RotateToPos(pos);
        transform.position = Vector2.MoveTowards(transform.position, pos, 0.005f);

    }

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
