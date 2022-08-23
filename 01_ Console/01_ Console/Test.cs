using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__Console
{
    internal class Test
    {
        private static void Test_Charctor()
        {
            Human human1 = new Human();
            Human human2 = new Human();


            //클래스에 대해서 메모리 할당 완료(Instance화), 객체(Object) 생성완료
            // charactor 타입으로 하나 더 만드는 것, human 1과 human 2 는 서로 다른 개체이다.
            // 생성자 로 변수 호출



            while (!human1.IsDead && !human2.IsDead) //bool 타입으로 해주면 while 이용 용이, human1이 살아있고 human2 도 살아있다
            {
                human1.Attack(human2);
                human1.PrintStatus();
                human2.PrintStatus();
                if (human2.IsDead)
                {
                    break;
                }
                human2.Attack(human1);
                human1.PrintStatus();
                human2.PrintStatus();
            }
            Console.WriteLine("누군가가 사망하였습니다.");
        }
        private static void TESTGUGUDAN()
        {
            int n = 0;

            Console.Write("2~9사이 중 한 숫자를 입력해 주세요 : ");
            string temp = Console.ReadLine();
            int.TryParse(temp, out n);
            Multfly(n);





            Console.ReadKey(); // 키 입력 대기코드
        }
        private static void Multfly(int n)
        {

            if (1 < n && n < 10) // 논리 연산자 and
            {
                for (int i = 1; i < 10; i++)
                {
                    Console.WriteLine($"{n} * {i} = {n * i} ");

                }
            }
            else
                Console.WriteLine("올바른 숫자를 입력하세요");
        }
        private static void Test_Function()
        {
            string name2 = "너굴맨";
            int level = 2;
            int hp = 10;
            int maxHP = 20;
            float exp = 0.1f;
            float maxExp = 1.0f;

            PrintCharacter(name2, 3, 4, 5, 10, 11); // 변수 name2 / name 이 다르다... 변수 스코프가 달라서
                                                    // 그러나 동일하게 매개변수 받아 처리가능 
        }
        private static void PrintCharacter(string name, int level, int hp, int maxHP, float exp, float maxExp)
        {
            string result = name;
            int a = level;
            int b = hp;
            int c = maxHP;
            float A = exp;
            float B = maxExp;
            Console.WriteLine($"이름 : {result}\n레벨 : {a}\n체력 : {b}\n최대체력 : {c}\n경험치 : {A:f3}\n최대 경험치 : {B:f3}");
            //실습 파라메터로 받은 데이터를 적당한 양식으로 출력해 주는 함수 완성하기
        }

    }
}
