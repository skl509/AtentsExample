// using : 어떤 추가적인 기능을 사용할 것인지를 표시하는 것 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace : 이름이 겹치는 것을 방지하기 위해 구분지어 놓는 용도
namespace _01__Console
{
    
    // 접근제한자(Access Modifier)
    // public : 누구든지 접근할 수 있다.
    // private : 자기 자신만 사용 가능
    // protected : 자신과 자신을 상속받은 자식만 접근할 수 있다.
    // internal : 같은 어셈블리안에서는 pbulic, 다른 어셈블리면 private

    // 클래스 : 특정한 오브젝트를 표현하기 위해 그 오브젝트가 가져야 할 데이터와 기능을 모아 놓은것
    public class Charactor // Test 라는 클래스를 public으로 선언한다.
    {
        //멤버 변수 -> 이 클래스에서 사용되는 데이터
    private string name;
    private int hp = 100;
    private int maxHP = 100;
    private int strenth = 0;
    private int dexteriy = 0;
    private int intellegence = 0;


        // 배열 : 같은 종류의 데이터 타입을 
        //int[] intArray; // 인티저를 여러개 가질 수 있는 배열
        //intArray = new int[5]; // 인티저를 5개 가질 수 있도록 할당

        string[] nameArray = { "너굴맨", "개굴맨", "벡터맨", "샥샥맨", "사슴맨" }; // nameArray에 기본값 설정(선언과 할당을 동시에)
        Random rand;
        
        public int HP // 프로퍼티 get/set 이용
        {
            get // 이프로퍼티를 읽을 때 호출되는 부분
            {
                return hp;
            }
            private set // 이 프로퍼티에 값을 넣을 때 호출되는 부분
            {
                hp = value;
                if (hp > maxHP)
                {
                    hp = maxHP;

                }
                if (hp <= 0)
                {
                    Console.WriteLine($"{name}이 죽었습니다.");
                }            }
        }

        public Charactor()
        {

           // Console.WriteLine("생성자 호출");
            rand = new Random();
            int randomNumber = rand.Next();
            randomNumber %= 5;
            name = nameArray[randomNumber];

            maxHP = rand.Next(100, 201);
            hp = maxHP;

            strenth = rand.Next(20) + 1; // 1~20사이를 랜덤하게 선택 , (20) -> 1~19 까지 랜덤 
            dexteriy = rand.Next(20) + 1;
            intellegence = rand.Next(20) + 1;

            TestPrintStatus();
            //실습
            //1. 이름이 nameArray에 들어 있는 것 중 하나로 랜덤하게 선택된다.
            //2. maxHP는 100~200 사이로 랜덤하게 선택된다.
            //3. hp는 maxHP와 같은 값이다.
            //4. strenth, dexterity, intellegence은 1~20 사이로 랜덤하게 정해진다.
            //5. TestPrintStatus 함수를 이용해서 최종 상태를 출력한다.
            //시간 : 1시 20분

        }

        public Charactor(string newName)
        {
            Console.WriteLine($"생성자 호출 - {newName}");
            rand = new Random();
            name = newName;
            GenerateStatus();
            TestPrintStatus();
            
        }


        private void GenerateStatus()
        {
           
            maxHP = rand.Next(100, 201);
            hp = maxHP;

            strenth = rand.Next(20) + 1; // 1~20사이를 랜덤하게 선택 , (20) -> 1~19 까지 랜덤 
            dexteriy = rand.Next(20) + 1;
            intellegence = rand.Next(20) + 1;

        }
        //멤버 함수 -> 이 클래스가 가지는 기능
        public void Attack(Charactor target)
        {
            int damage = strenth;
            target.TakeDamage(damage);
            Console.WriteLine($"{name}이 {target.name}에게 {damage}만큼의 공격을 합니다.({damage})");
        }
        public void TakeDamage(int damage)
        {
            HP -= damage;
            Console.WriteLine($"{name}이 {damage}만큼의 피해를 입었습니다.");
        }

        public void TestPrintStatus()
        {
            Console.WriteLine("┌─────────────────┐");
            Console.WriteLine($"이름\t: {name}");
            Console.WriteLine($"HP\t: {hp} / {maxHP}");
            Console.WriteLine($"힘\t: {strenth,2}");
            Console.WriteLine($"민첩\t: {dexteriy,2}");
            Console.WriteLine($"지능\t: {intellegence,2}");
            Console.WriteLine("└─────────────────┘");
        }
    }

}
