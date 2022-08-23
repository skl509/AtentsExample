using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__Console
{
    internal class Human : Charactor //human 클래스는 charactor 클래스를 상속 받았다.
    {
        protected int mp = 100; //휴먼은 mp를 가지고 있다... 추가로
        protected int maxMP = 100;
        protected const int DefenseCount = 3; // 변하지 않는 상수는 const 로 고정시켜주기!
        protected int remainsDefenseCount = 0;

        public Human() // 상속 받은 부모의 생성자도 같이 실행
        {
            //GenerateStatus();// 변수 이용 못하는 이유는 상속받아도 이것이 private 으로 제한 되어있기 때문이다
        }                    // 그러나 protected 면 가능하다, 상속받은 애는 이용가능

        public Human(string newName) : base(newName)  // charactor(string newName) 실행...
        {
        
        }
        public override void GenerateStatus() //mp 만 추가하고 싶을때 새로운 함수 만들고 추가하기
        {
            base.GenerateStatus(); //base. 써야지 상속받은 기능 쓸수 잇다 이안에서
            maxMP = rand.Next() % 100;
            mp = maxMP;
        }

        public override void PrintStatus()
        {
            Console.WriteLine("┌─────────────────┐");
            Console.WriteLine($"이름\t: {name}");
            Console.WriteLine($"HP\t: {hp} / {maxHP}");
            Console.WriteLine($"MP\t: {mp} / {maxMP}");
            Console.WriteLine($"힘\t: {strenth,2}");
            Console.WriteLine($"민첩\t: {dexteriy,2}");
            Console.WriteLine($"지능\t: {intellegence,2}");
            Console.WriteLine("└─────────────────┘");


        }

        public override void Attack(Charactor target)
        {
            int damage = strenth;

            // name 이 this 가 아니라서 읽기전용 name -> Name으로 다시 만들어줌
            int odd = rand.Next(0, 11);  // 다른 방법 rand.NextDouble(0.0 ~ 1.0 출력)
            if (0 < odd && odd < 4)
            {
                damage *= 2; // damage = damage*2;
                Console.WriteLine("크리티컬 히트!");
            }
            target.TakeDamage(damage);
            Console.WriteLine($"{name}이 {target.Name}에게 {damage}만큼의 공격을 합니다.({damage})");

        }
        public void Skill(Charactor target)

        {   // rand.NextDouble() : 0~1
            // rand.NextDouble() * 1.5f : 0~ 1.5
           const int requireMP = 10; //스킬 사용할때 필요한 마나량...

            if (mp - requireMP > 0) // 스킬을 사용할 수있을 만큼 마나가 있으면 작동
            {
                int damage = (int)((rand.NextDouble() * 1.5f) + 1) * intellegence; // 지능을 1~2.5 배 한 결과에서 소수점 제거한 수
                target.TakeDamage(damage);
                Console.WriteLine($"{name}이 {target.Name}에게 {damage}만큼의 스킬을 사용합니다.({damage})");
                target.TakeDamage(damage);
                mp -= requireMP; // mp 감소
            }
            else {

                Console.WriteLine("마나가 부족합니다.");

            }

        }
        public void Defense()
        {
            Console.WriteLine($"3턴간 받는 데미지 반감");
            remainsDefenseCount += DefenseCount; // 상수가 고정되고 결과적으로 remian 값이 올라간다...
        }
        public override void TakeDamage(int damage)
        { // 방어 횟수가 남아있으면
            if (remainsDefenseCount > 0) 
            {   
                Console.WriteLine("방어 발동! 받는 데미지가 절반 감소합니다");
                remainsDefenseCount--; //회수 1차감하고
                damage = damage >> 1;//절반값 2의1승으로 나눠주기, int 타입일때만 가능

            }
            base.TakeDamage(damage); // 나에게 데미지 전달
        }
    }

   }

