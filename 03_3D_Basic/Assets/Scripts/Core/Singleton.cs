using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//싱글톤
//1. 디자인 패턴중 하나다
//2. 클래스의 객체를 무조건 하나만 생성하는 디자인 패턴
//3. 데이터를 확신 할 수 있다.
//4. static 멤버를 이용해서 객체에 쉽게 접근 할 수 있도록 해준다.


// Singleton 클래스는 제네릭 타입의 클래스이다.(만들때 타입을 하나 받아야 한다.)
//where 이하에 있는 조건을 만족시켜야 한다.(T는 컴포넌트를 상속받는 타입이어여햔다.)
public class Singleton<T> : MonoBehaviour where T : Component
{ 
    private static T _instance;

    public static T Inst
    {
        get 
        {
            if (_instance == null) 
            {
                //한 번도 호출된 적이 없다는
                var obj = FindObjectOfType<T>();
                if (obj != null) 
                {   
                    // 이미 다른 객체가 있으니까 있는 객체를 사용한다.
                   _instance = obj;
                }

                else
                {  // 다른 객체가 없다. -> 그래서 새로 만들어 준다
                    GameObject gameObj = new GameObject();
                    gameObj.name = $"{typeof(T).Name}";
                    _instance = gameObj.AddComponent<T>(); // 없는컴퍼넌트를 추가해주기
                }


            }
            return _instance;
        }
    
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T; // as 키워드
                                   // ex) a as b -> a를 b타입으로 캐스팅을 시도 한 후 실패하면 null 아니면 b 타입으로 변경

            DontDestroyOnLoad(this.gameObject);// 씬이 사라지더라도 게임 오브젝트를 삭제하지 않게 하는 코드

        }
        else 
        {
            if (_instance != this) 
            {
                Destroy(this.gameObject); // 내가 아닌 같은 종류의 오브젝트가 있으면 바로삭제
            }
        }
   }


}


//static 키워드
//실행 시점에서 메모리에 이미 메모리에 위치가 고정되게 하는 한정자 키워드
//타입 이름을 통해서만 멤버에 접근이 가능하다.
//모든 객체(instance)가 같은 값을 가진다.