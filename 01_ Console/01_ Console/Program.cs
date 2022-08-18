using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _01__Console
{
    internal class Program
    {
        // 스코프(Scope) : 변수나 함수를 사용할 수 있는 범위. 변수를 선언한 지점에서 해당 변수가 중괄호가 끝나는 구간 까지
        static void Main(string[] args)
        {
            //int sumResult = Sum(10, 20); // break point(단축키 F9) , f10, f11 도 요긴하다 디버깅 기능
            //Console.WriteLine($"SumResult : {sumResult}");

            //Print();
            //Test_Function();

            //실습 
            //1. int 타입의 파라메터를 하나 받아서 그 숫자에 해당하는 구구단을 출력해주는 함수 만들기
            //2. 1번에서 만드는 함수는 2~9까지 입력이 들어오면 해당 구구단 출력, 그 외 숫자는 "잘못된 입력입니다" 라고 출력해야된다.
            //3. 메인 함수에서 입력받는 코드가 따로 있어야한다.
            int n = 0;

            Console.Write("2~9사이 중 한 숫자를 입력해 주세요 : ");
            string temp = Console.ReadLine();
            int.TryParse(temp, out n);
            Multfly(n);

            Console.ReadKey(); // 키 입력 대기코드
        }

        private static void Multfly(int n)
        {

            if (1 < n && n < 10)
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
        //함수의 기본 요소 -> 함수는 특정 기능을 하도록 하는 코드덩어리
        //이름 : 함수들을 구분하기 위한 이름 (예제의 Sum)
        //리턴타입 : 함수의 실행 결과로 돌려주는 데이터의 타입(int, 함수의 이름앞에 표시된다.)
        //파라메터(매개변수) : 함수가 실행 될 때 외부에서 받는 값 (int a, int b 두개의 파라매터가 있다.)
        // 함수바디 : 함수가 호출 될 때 실행될 코드들(예제의 222~225라인)

        //함수의 이름, 리턴타입, 파라메터를 합쳐서 함수 프로토타입이라고 한다. 절대로 하나의 프로그램안에서 겹치지 않는다

        static int Sum(int a, int b)
        {
            int result = a + b;
            return result;
        }
            static void Print() // 리턴해주는 값이 없고, 파라메터도 없는 경우
            {
                Console.WriteLine("Print");
            
            }
        void Test()
        {
            Console.WriteLine("송경일"); // 출력
            //string str = Console.ReadLine(); // 키보드 입력을 받아서 str 이라는 string 변수에 저장한다
            //Console.WriteLine(str);
            // 변수:변하는 숫자, 컴퓨터에서 사용할 데이터를 저장할 수 있는 곳
            // 변수의 종류 : 데이터 타입
            // int : 인티저, 정수, 소수점 없는 숫자. 
            // float : 플로트, 실수, 소수점 있는 숫자. 
            // string : 스트링, 문자열, 글자들을 저장
            // bool : 불리언, true/false 를 저장.

            int a = 10; // a라는 인티저 변수에 10이라는 데이터를 넣는다.
            long b = 5000000000; // 50억은 int에 넣을 수 없다. -> int는 32비트이고 32비트로 표현 할 수 있는 숫자의 개수는 약 42억개(+ - 나누면 약 21억개)
            int c = -100;
            int d = 2000000000;
            int e = 2000000000;
            int f = d + e; // 표현 범위가 넘쳐버리기 때문에 오버플로우 현상 일어난다, 0 또는 - 로넘어감

            Console.WriteLine(f);

            //float 의 단점 : 태생적으로 오차가 존재
            float aa = 0.000123f;
            float ab = 0.9999999999999f; // 계산결과 1이 들어 있을 수 도 있음.
            float ac = 0.0000000000001f;

            float ad = ab + ac; // 결과가 1이 아닐 수도 있다.

            Console.WriteLine(ad);

            string str1 = "Hello";
            string str2 = "안녕!";
            string str3 = $"Hello {a}"; //Hello 10 -> 나중에 숫자 부분이나 글자 부분을 효율적으로 다루기 위해 일부러 분리해서 작성
            Console.WriteLine(str3);
            string str4 = str1 + str2; //"Hello안녕!"
            Console.WriteLine(str4);

            bool b1 = true;
            bool b2 = false;


            int level = 1;
            int hp = 11;
            float exp = 0.1f;
            string name = "너굴맨";
            //string result = $"{name}의 레벨은 {level}이고 HP는 {HP}이고 exp는 {exp}다. \n";

            ////너굴맨의 레벨은 1이고 HP는 10이고 exp는 0.9다.

            //Console.WriteLine(result);
            ////강사님이 한것 1
            //Console.WriteLine($"이름 : {name}\n레벨 : {level}\nHP : {HP}\nexp : {exp}");
            ////강사님이 한것 2
            //Console.WriteLine(name + "의 레벨은" + level + " 이고 HP는 " + HP + "이고 exp는" + exp + " 이다");
            ////내가한것

            //Console.Write("이름을 입력하세요 : ");
            //name = Console.ReadLine();
            //Console.Write($"{name}의 레벨을 입력하세요 : ");
            //string temp = Console.ReadLine();
            //// Console 같은 함수기능은 string 만 받아서 int형 이용 할려면 변형해야된다.
            ////level = int.Parse(temp);// string을 int로 변경해주는 함수(숫자로 바꿀 수 있을 때만 가능)
            ////int.TryParse{temp, out level}; // string을 int로 변경해주는 코드 (숫자를 바꿀 수없으면 0으로 만든다)
            //// 안전하게 이용 가능한 함수 -> 이걸로 이용 추천!
            ////level = Convert.ToInt32(temp); // string을 int로 변경해주는 코드(숫자로 바꿀 수 있을때만 가능)
            //int.TryParse(temp, out level);
            //Console.Write($"{name}를 HP를 입력하세요 : ");
            //string temp2 = Console.ReadLine();
            //int.TryParse(temp2, out HP);
            //Console.Write($"{name}를 exp를 입력하세요 : ");
            //string temp3 = Console.ReadLine();
            //float.TryParse(temp3, out exp);

            //result = $"{name}의 레벨은 {level}이고 HP는 {HP}이고 exp는 {exp * 100:F3}%다. \n";
            //Console.WriteLine(result);

            ////이름, 레벨, hp, 경험치를 각각 입력 받고 출력하는 코드 만들기

            //exp = 0.959595f;
            //result = $"{name}의 레벨은 {level}이고 HP는 {HP}이고 exp는 {exp*100:F3}다. \n"; //:F3는 소수좀 3자리까지만 춢력하라는 것
            //Console.WriteLine(result);

            //변수 종료----------------------------------------------------------------------------------------------------

            // 제어문(Control state) - 조건문(if, switch), 반복문
            // 실행되는 코드 라인을 변경할 수 있는 코드
            hp = 10;
            if (hp < 3) // HP가 2이기 때문에 참이다
            {
                Console.WriteLine("HP가 부족합니다"); // 참이라서 아래코드가 실행! 
            }
            else if (hp < 10)
            {
                Console.WriteLine("HP가 적당합니다");
            }
            else
            {
                Console.WriteLine("HP가 충분합니다");
            }

            switch (hp)
            {
                case 0: //HP가 0일때
                    Console.WriteLine("HP가 0입니다");
                    break;
                case 5:  //HP가 5일때
                    Console.WriteLine("HP가 5입니다");
                    break;
                default:  // 위에 설정되지 않은 모든 경우
                    Console.WriteLine("HP가 0과 5가 아닙니다.");
                    break;
            }


            // 조건문 실습
            //Console.WriteLine("현재 경험치는 " + exp + " 입니다!\n");
            //Console.WriteLine("경험치를 추가합니다.");
            //Console.Write("추가할 경험치 : "); // 이전의 exp 값이 안 덮여 쓰도록 이전 값의 저장할 수 있도록
            //                             // 변수를 새로 만들어준다
            //float floatTemp = 0.0f; // 새로 입력 받는 경험치 저장하는 변수
            //string temp = Console.ReadLine(); // 추가 경험치 입력받는 것1
            //float.TryParse(temp, out floatTemp);// 추가 경험치 입력받는 것2
            //exp = exp + floatTemp; // 이전에 있는 exp 값 에다가 새로 입력하는 floatTemp 를 더해주기!
            //if (exp >= 1)
            //{
            //    Console.WriteLine("레벨 업!");
            //}
            //else
            //{
            //    Console.WriteLine($"현재 경험치는 : {exp} "); // 변수 들어가는거 출력할려면 앞에다 $ 써줘야된다. 

            //}

            //실습 : exp의 값과 추가로 입력받은 경험치의 합이 1 이상이면 레벨 업 이라고 출력하고
            //       1 미만이면 현재 경험치 합계를 출력하는 코드 작성하기

            while (level < 3) // 소괄호 안의 조건이 참이면 중괄호{} 사이의 코드를 실행하는 statement 
            {
                Console.WriteLine($"현재 레벨 : {level}");
                level++; // => level = level + 1 == level += 1;
            }

            for (int i = 0; i < 3; i++) // i는 0에서 시작해서 3보다 작으면 계속 {}사이의 코드를 실행한다.
                                        //  {} 사이의 코드가 실행 될때 마다 1 씩 증가한다.
            {
                Console.WriteLine($"현재 HP : {hp}");
                hp += 10;

            }
            Console.WriteLine($"최종 HP : {hp}");
            level = 1;
            do

            {
                Console.WriteLine($"현제 레벨 : {level}");

                if (level == 2) // 1+1 == 2 ...............  == 은 양쪽이 같다라는 의미
                {
                    break;

                }

                level++;
            }
            while (level < 10);
            Console.WriteLine($"최종 level : {level}");


            // 실습 :  exp가 1을 넘어 레벨업을 할 때 까지 계속 추가 경험치를 입력하도록 하는 코드를 작성하기
            exp = 0.0f;
            Console.WriteLine("현재 경험치는 " + exp + " 입니다!\n");
            Console.WriteLine("경험치를 추가합니다.");
            Console.Write("추가할 경험치 : ");
            float floatTemp = 0.0f; // 새로 입력 받는 경험치 저장하는 변수
            string temp = Console.ReadLine(); // 추가 경험치 입력받는 것1
            float.TryParse(temp, out floatTemp);// 추가 경험치 입력받는 것2
            exp = exp + floatTemp;
            do
            {
                Console.WriteLine($"현재 경험치 : {exp}");
                if (exp == 1)
                {
                    break;
                }
                Console.Write("추가할 경험치 : "); // 안에서도 새로 저장 공간을 만들어줘야 갱신이 가능하다!
                float floatTemp2 = 0.0f; // 새로 입력 받는 경험치 저장하는 변수
                string temp2 = Console.ReadLine(); // 추가 경험치 입력받는 것1
                float.TryParse(temp2, out floatTemp2);// 추가 경험치 입력받는 것2
                exp = exp + floatTemp2;
            }

            while (exp < 1);
            Console.WriteLine("레벨업!");
            // 강사님이 코딩한것!
            //while (1.0f > exp)
            //{
            //    Console.WriteLine($"경험치를 추가 해야합니다, 현재 경험치 : {exp}");
            //    Console.Write("추가할 경험치 : ");
            //    string temp2 = Console.ReadLine();
            //    float tempFloat2 = 0.0f;
            //    float.TryParse(temp2, out tempFloat2);
            //    exp += tempFloat2;
            //}
            //Console.WriteLine("레벨업!");



        }
    }
    }

