using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__Console
{
    internal class Human : Charactor //human 클래스는 charactor 클래스를 상속 받았다.
    {
        int mp = 100;
        int maxMP = 100;

        public Human() // 상속 받은 부모의 생성자도 같이 실행
        {
            GenerateStatus();// 변수 이용 못하는 이유는 상속받아도 이것이 private 으로 제한 되어있기 때문이다
        }                    // 그러나 protected 면 가능하다, 상속받은 애는 이용가능

        public override void GenerateStatus() //mp 만 추가하고 싶을때 새로운 함수 만들고 추가하기
        {
            base.GenerateStatus(); //base. 써야지 상속받은 기능 쓸수 잇다 이안에서
            maxMP = rand.Next() % 100;
            mp = maxMP;
        }

        public override void TestPrintStatus()
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
                damage *=2; // damage = damage*2;
                Console.WriteLine("크리티컬 히트!");
            }
            target.TakeDamage(damage);
            Console.WriteLine($"{name}이 {target.Name}에게 {damage}만큼의 공격을 합니다.({damage})");

        }
       

    }
}
