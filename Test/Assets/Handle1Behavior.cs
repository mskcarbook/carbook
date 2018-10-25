using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle1Behavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount>0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos;
            Ray ray;
            RaycastHit hit;

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    // 터치 시작 시
                    Debug.Log("터치 시작");

                    Vector3 touchPosToVector3 = new Vector3(touch.position.x, touch.position.y, 100);
                    touchPos = Camera.main.ScreenToWorldPoint(touchPosToVector3);
                    ray = Camera.main.ScreenPointToRay(touchPosToVector3);
                    GameObject handle1_explain = GameObject.Find("handle1_explain");

                    if(Physics.Raycast(ray,out hit,100)){
                        Debug.DrawLine(ray.origin, hit.point, Color.red, 1.5f);

                        if (hit.collider.tag == "handle1_explain")
                        {
                            Debug.Log("Child 터치 ! ");
                            handle1_explain.GetComponent<Rigidbody>().isKinematic = false;
                            if (handle1_explain.GetComponent<Transform>().parent != null)
                            {
                                handle1_explain.GetComponent<Transform>().parent = null;
                            }
                        }
                        else if (hit.collider.tag == "handle1")
                        {
                            Debug.Log("Parents 터치 ! ");
                        }

                    }else {
                        Debug.DrawLine(ray.origin, touchPos, Color.yellow, 1.5f);

                    } break;

                case TouchPhase.Ended: //터치 종료 시

                    break;

            }
        }
	}
}
