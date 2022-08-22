// using : 어떤 추가적인 기능을 사용할 것인지를 표시하는 것 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        protected string name;
        protected int hp = 100;
        protected int maxHP = 100;
        protected int strenth = 0;
        protected int dexteriy = 0;
        protected int intellegence = 0;
        protected int defence = 0;
        protected int healing = 0;
        protected int mp = 0;

        public string Name => name;

        protected bool isDead = false;

        public bool IsDead => isDead; // 읽기전용 프로퍼티 만들기 = public bool IsDead {get => isDead;}


        // 배열 : 같은 종류의 데이터 타입을 
        //int[] intArray; // 인티저를 여러개 가질 수 있는 배열
        //intArray = new int[5]; // 인티저를 5개 가질 수 있도록 할당

        protected string[] nameArray = { "너굴맨", "개굴맨", "벡터맨", "샥샥맨", "사슴맨" }; // nameArray에 기본값 설정(선언과 할당을 동시에)
        protected Random rand;

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
                    Dead();
                }
            }
        }

        private void Dead()
        {
            Console.WriteLine($"{name}이 죽었습니다.");
            isDead = true;
        }

        public Charactor()
        {

            // Console.WriteLine("생성자 호출");
            rand = new Random(DateTime.Now.Millisecond);
            int randomNumber = rand.Next();
            randomNumber %= 5;
            name = nameArray[randomNumber];

            maxHP = rand.Next(100, 201);
            hp = maxHP;
            mp = rand.Next(20) + 1;
            strenth = rand.Next(20) + 1; // 1~20사이를 랜덤하게 선택 , (20) -> 1~19 까지 랜덤 
            dexteriy = rand.Next(20) + 1;
            intellegence = rand.Next(20) + 1;
            defence = rand.Next(20) + 1;
            healing = rand.Next(20) + 1;

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
           
            rand = new Random(DateTime.Now.Millisecond);
            name = newName;
            GenerateStatus();
            TestPrintStatus();

        }


        public virtual void GenerateStatus()
        {

            maxHP = rand.Next(100, 201);
            hp = maxHP;

            strenth = rand.Next(20) + 1; // 1~20사이를 랜덤하게 선택 , (20) -> 1~19 까지 랜덤 
            dexteriy = rand.Next(20) + 1;
            intellegence = rand.Next(20) + 1;

        }
        //멤버 함수 -> 이 클래스가 가지는 기능
        public virtual void Attack(Charactor target)
        {
            int damage = strenth;
            target.TakeDamage(damage);
            Console.WriteLine($"{name}이 {target.name}에게 {damage}만큼의 공격을 합니다.({damage})");
        }
        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
            Console.WriteLine($"{name}이 {damage}만큼의 피해를 입었습니다.");
        }

        public virtual void Defence(Charactor target) // 휴먼의 방어
        {
            int damage = strenth;
            target.TakeDamage(damage);
            Console.WriteLine($"{target.name}이 {name}에게 {damage - defence}만큼의 공격을 막았습니다.({damage - defence})");
        }
        public virtual void TakeDamage1(int defence)
        {
            int damage = strenth;
            damage -= defence;
            Console.WriteLine($"{name}이 {defence}만큼의 대미지를 막았습니다.");
        }

        public virtual void Healing(Charactor target) //휴먼의 스킬
        {
            int Healing = healing;
            healing = rand.Next(20);
            target.TakeHealing(Healing);
            Console.WriteLine($"{target.name}이 {healing}만큼의 체력을 회복했습니다.");
        }
        public void TakeHealing(int healing)
        {
            
            HP += healing;
            mp -= 1;
        }






        public virtual void TestPrintStatus()
        {
            Console.WriteLine("┌─────────────────┐");
            Console.WriteLine($"이름\t: {name}");
            Console.WriteLine($"HP\t: {hp} / {maxHP}");
            Console.WriteLine($"힘\t: {strenth,2}");
            Console.WriteLine($"방어\t: {defence,2}");
            Console.WriteLine($"민첩\t: {dexteriy,2}");
            Console.WriteLine($"지능\t: {intellegence,2}");
            Console.WriteLine("└─────────────────┘");
        }
    }

}
