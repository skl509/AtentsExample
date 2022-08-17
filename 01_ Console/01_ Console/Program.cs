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
            int HP = 10;
            float exp = 0.9f;
            string name = "너굴맨";
            string result = $"{name}의 레벨은 {level}이고 HP는 {HP}이고 exp는 {exp}다. \n";

            //너굴맨의 레벨은 1이고 HP는 10이고 exp는 0.9다.

            Console.WriteLine(result);
            //강사님이 한것 1
            Console.WriteLine($"이름 : {name}\n레벨 : {level}\nHP : {HP}\nexp : {exp}");
            //강사님이 한것 2
            Console.WriteLine(name + "의 레벨은" + level + " 이고 HP는 " + HP + "이고 exp는" + exp + " 이다");
            //내가한것

            Console.Write("이름을 입력하세요 : ");
            name = Console.ReadLine();
            Console.Write($"{name}의 레벨을 입력하세요 : ");
            string temp = Console.ReadLine();
            // Console 같은 함수기능은 string 만 받아서 int형 이용 할려면 변형해야된다.
            //level = int.Parse(temp);// string을 int로 변경해주는 함수(숫자로 바꿀 수 있을 때만 가능)
            //int.TryParse{temp, out level}; // string을 int로 변경해주는 코드 (숫자를 바꿀 수없으면 0으로 만든다)
            // 안전하게 이용 가능한 함수 -> 이걸로 이용 추천!
            //level = Convert.ToInt32(temp); // string을 int로 변경해주는 코드(숫자로 바꿀 수 있을때만 가능)
            int.TryParse(temp, out level);
            Console.Write($"{name}를 HP를 입력하세요 : ");
            string temp2 = Console.ReadLine();
            int.TryParse(temp2, out HP);
            Console.Write($"{name}를 exp를 입력하세요 : ");
            string temp3 = Console.ReadLine();
            float.TryParse(temp3, out exp);
            
            result = $"{name}의 레벨은 {level}이고 HP는 {HP}이고 exp는 {exp}다. \n";
            Console.WriteLine(result);

            //이름, 레벨, hp, 경험치를 각각 입력 받고 출력하는 코드 만들기

            exp = 0.959595f;
            //result = $"{name}의 레벨은 {level}이고 HP는 {HP}이고 exp는 {exp*100:F3}다. \n"; //:F3는 소수좀 3자리까지만 춢력하라는 것
            //Console.WriteLine(result);


            


            Console.ReadKey(); // 키 입력 대기코드
        }
    }
}
