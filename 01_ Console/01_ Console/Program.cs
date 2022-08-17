using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__Console
{
    internal class Program
    {
        static void Main(string[] args)
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

            for(int i=0; i<3; i++) // i는 0에서 시작해서 3보다 작으면 계속 {}사이의 코드를 실행한다.
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
            Console.WriteLine("레벨업!");3

            Console.ReadKey(); // 키 입력 대기코드
        }
    }
}
