using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    // 복셀이 날아가는 속도 변수 지정
    public float speed = 5;
    // 복셀이 사라지는 시간 변수 지정
    public float destroyTime = 3.0f;
    // 흘러가는 기본 시간 변수 지정
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 랜덤으로 날아갈 방향을 찾는다
        Vector3 direction = Random.insideUnitSphere;    // 크기가 1이고 방향만 존재함

        // 랜덤한 방향으로 날아가는 속도를 준다
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // 시간이 흐르도록 설정
        currentTime = currentTime + Time.deltaTime;
        if(currentTime > destroyTime)   // 시간초과
        {
            Destroy(gameObject);    // 복셀 제거거
        }
    }
}
