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
    void OnEnable()     // OnEnable : 이벤트가 발생했을 때
    {
        currentTime = 0;

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
            gameObject.SetActive(false);    // 복셀을 비활성화
            
            // 오브젝트 풀에 다시 넣어준다 (나(gameObject)를 넣어준다)
            // VoxelMaker의 오브젝트풀에 자기 자신을 추가
            // 복셀메이커 안에 있는 복셀 풀에 나(게임 오브젝트)를 추가한다
            VoxelMaker.voxelPool.Add(gameObject);

            // Destroy(gameObject);    // 복셀 제거
        }
    }
}
